using System;
using System.Management;


namespace RFID_Printer.Device
{
    internal class PnPConnectionListener
    {
        public event EventHandler PnPDeviceDisconected;
        public event EventHandler PnPDeviceConnected;

        public PnPConnectionListener()
        {
            createEventWatcher();
        }

        void createEventWatcher()
        {
            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceOperationEvent WITHIN 2 WHERE " +
                    "TargetInstance ISA 'Win32_PnPEntity'");

            ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += new EventArrivedEventHandler(OnPnPDeviceOperation);
            insertWatcher.Start();
        }

        void OnPnPDeviceOperation(object s, EventArrivedEventArgs e)
        {
            EventHandler handler;
            switch (e.NewEvent.ClassPath.ClassName)
            {
                case "__InstanceDeletionEvent": // Removed
                    handler = PnPDeviceDisconected;
                    handler?.Invoke(this, e);
                    break;

                case "__InstanceCreationEvent": // Inserted
                    handler = PnPDeviceConnected;
                    handler?.Invoke(this, e);
                    break;

                case "__InstanceModificationEvent":
                    Console.WriteLine("Entro: __InstanceModificationEvent ");
                    using (ManagementBaseObject MOBbase = (ManagementBaseObject)(e as EventArrivedEventArgs).NewEvent.Properties["TargetInstance"].Value)
                    {
                        // TO DO: Research the uses of this event
                        Console.WriteLine(MOBbase?.Properties["PNPDeviceID"]?.Value.ToString());
                    }
                    break;
                default:
                    Console.WriteLine(e.NewEvent.ClassPath.ClassName);
                    break;
            }
            
        }
    }
}
