using System;
using System.Management;

namespace RFID_Printer.Device
{
    public delegate void UpdateDeviceStatus(bool connected);

    public class DeviceManager : IDisposable
    {
        Device device;
        PnPConnectionListener pnpListener;
        public static event UpdateDeviceStatus upDeviceStatus;

        public DeviceManager()
        {
            CheckForConnection();
            SetPnPListener();
        }

        private void SetPnPListener()
        {
            pnpListener = new PnPConnectionListener();
            pnpListener.PnPDeviceConnected += PnPConnection;
            pnpListener.PnPDeviceDisconected += PnPDisconnection;
        }

        public void PnPConnection(object sender, EventArgs e)
        {
            bool connectionSuccessful = TryNewConnection();
            if (connectionSuccessful)
            {
                using (ManagementBaseObject MOBbase = (ManagementBaseObject)(e as EventArrivedEventArgs).NewEvent.Properties["TargetInstance"].Value)
                {
                    device.deviceId = MOBbase?.Properties["PNPDeviceID"]?.Value.ToString();
                    upDeviceStatus?.Invoke(true);
                }
            }
        }

        public void PnPDisconnection(object sender, EventArgs e)
        {
            using (ManagementBaseObject MOBbase = (ManagementBaseObject)(e as EventArrivedEventArgs).NewEvent.Properties["TargetInstance"].Value)
            {
                if(MOBbase?.Properties["PNPDeviceID"]?.Value.ToString() == device.deviceId)
                {
                    device.Dispose();
                    upDeviceStatus?.Invoke(false);
                }
            }
        }

        private void CheckForConnection()
        {
            device = new Device();
            device.Connect();
            if (device.Connected)
            {
                // Sync deviceId with hardware id (type/vendorId/produtId) at port X.
                device.deviceId = getDeviceNameFromWindows(device.port);
                upDeviceStatus?.Invoke(true);
            }
        }

        private string getDeviceNameFromWindows(int port)
        {
            ManagementClass processClass = new ManagementClass("Win32_PnPEntity");

            ManagementObjectCollection Ports = processClass.GetInstances();
            string device = "";
            foreach (ManagementObject property in Ports)
            {
                if (property.GetPropertyValue("Name") != null)
                    if (property.GetPropertyValue("Name").ToString().Contains("USB") &&
                        property.GetPropertyValue("Name").ToString().Contains($"COM{port}"))
                    {
                        device = property.GetPropertyValue("PNPDeviceID").ToString();
                    }
            }
            return device;
        }

        private bool TryNewConnection()
        {
            if (device == null)
                device = new Device();

            device.Connect();
            return device.Connected;
        }

        public bool WriteTag(string tag)
        {
            return device.WriteEPC(tag);
        }

        public string ReadTag()
        {
            return device.Read();
        }

        public void Dispose()
        {
            device?.Dispose();
        }
    }
}
