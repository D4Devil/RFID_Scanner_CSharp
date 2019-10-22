using System;


namespace RFID_Printer.Exception
{
    class RFIDReadFailed : InvalidOperationException
    {
        public RFIDReadFailed(string message) : base(message)
        {
        }
    }
}
