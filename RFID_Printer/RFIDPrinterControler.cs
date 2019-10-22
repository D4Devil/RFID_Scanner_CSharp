using RFID_Printer.Device;
using RFID_Printer.Websocket;
using System;

namespace RFID_Printer
{
    public class RFIDPrinterControler : IDisposable
    {
        public static RFIDPrinterControler _s;
        public RFIDPrinter view;

        readonly int port = 8083;
        WebsocketWrap ws;
        DeviceManager devMan;

        public RFIDPrinterControler(RFIDPrinter view)
        {
            _s = this;
            this.view = view;
            CreateWebsocket();
            view.SetPortWebSocekt(port);
            StartWs();
            DeviceManager.upDeviceStatus += view.SetDiveceStatus;
            devMan = new DeviceManager();
        }

        void StartWs()
        {
            ws?.Start();
        }

        public void StopWs()
        {
            ws?.Stop();
        }

        void CreateWebsocket()
        {
            ws = new WebsocketWrap(port, HandleMessage);
        }

        public WebsocketMessage HandleMessage(WebsocketMessage message)
        {
            var toReturn = new WebsocketMessage();
            toReturn.command = message.command;

            switch (message.command)
            {
                case "write":
                    Console.WriteLine("<<<<< Comando: Write >>>>>"); 
                    toReturn.success = Write(message.tag);
                    toReturn.tag = message.tag;
                    break;

                case "read":
                    Console.WriteLine("<<<<< Comando: read >>>>>");
                    var result = Read();
                    if(result != "failed")
                    {
                        toReturn.success = true;
                        toReturn.tag = result;
                    }
                    else
                    {
                        toReturn.success = false;
                        toReturn.tag = message.tag;
                    }
                    break;

                default:
                    Console.WriteLine("<<<< Commando desconocido o flatante >>>");
                    break;
            }
            return toReturn;
        }

        public bool Write(string tag)
        {
            bool success = false;
            try
            {
                success = devMan.WriteTag(tag);
                if (success)
                    view.SetTagReaded(tag);
            }
            catch(IndexOutOfRangeException e)
            {
                view.PopNotif($"The string must be 11 characters long.\nError: {tag} is {tag.Length}.");
                success = false;
            }
            return success;
        }
        
        public string Read()
        {
            var tag = devMan.ReadTag();
            view.SetTagReaded(tag);
            return tag;
        }

        public void Dispose()
        {
            ws?.Stop();
            devMan.Dispose();
        }
    }
}
