using System;
using System.Text;
using ReaderB;

namespace RFID_Printer.Device
{
    class Device : IDisposable
    {
        public bool Connected { get; private set; }
        public string deviceId;
        public int port = 0;
        private int portHandle = 0;
        private byte baudRate = Convert.ToByte(5);
        private byte conAdr;

        public void Connect()
        {
            conAdr = Convert.ToByte("FF", 16);
            int result = StaticClassReaderB.AutoOpenComPort(ref port, ref conAdr, baudRate, ref portHandle);
            Connected = (result == 0 && portHandle != -1 && portHandle > 0) ? true : false;
        }

        #region Constants for Writing Process
        readonly byte[] PASSWORD = HexStringToByteArray("00000000");
        #endregion

        public bool WriteEPC(string tag)
        {
            var writeData = HexStringToByteArray(tag);
            byte writeDataLen = Convert.ToByte(tag.Length / 2);
            int errorCode = 0;
            int successCode = -1;

            successCode = StaticClassReaderB.WriteEPC_G2(ref conAdr, PASSWORD, writeData, writeDataLen, ref errorCode, portHandle);

            return (successCode == 0) ? true : false;
        }

        #region Constants for Reading Process
        readonly byte 
            ADR_TID = 0,
            LEN_TID = 0,
            TID_FLAG = 0; 
        #endregion

        public string Read()
        {
            byte[] EPC = new byte[5000];
            int totalLen = 0;
            int cardNum = 0;
            int successCode = StaticClassReaderB.Inventory_G2(ref conAdr, ADR_TID, LEN_TID, TID_FLAG, EPC, ref totalLen, ref cardNum, portHandle);

            string tag = "";
            if(successCode == 1 | successCode == 2 | successCode == 3 | successCode == 4 | successCode == 0xFB)
            {
                byte[] daw = new byte[totalLen];
                Array.Copy(EPC, daw, totalLen);
                tag = ByteArrayToHexString(daw);
            }
            else
            {
                throw new Exception.RFIDReadFailed($"Success Code: {successCode} at attempting to read");
            }
            return tag;
        }

        static byte[] HexStringToByteArray(string s)
        {
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();
        }

        public void Dispose()
        {
            try
            {
                StaticClassReaderB.CloseComPort();
            }
            finally
            {
                Console.WriteLine("Tried to close ComPort. Device already ended");
            }
        }
    }
}
