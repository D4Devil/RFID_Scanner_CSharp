using RFID_Printer.Properties;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace RFID_Printer
{
    public partial class RFIDPrinter : Form
    {
        RFIDPrinterControler controler;
        delegate void UpdateTextLabel(string text);
        delegate void UpdatePort(int amount);
        delegate void UpdateConnectionStatus(bool status);

        public RFIDPrinter()
        {
            InitializeComponent();
            controler = new RFIDPrinterControler(this);
        }

        private void form_printQueue_Resize(object sender, EventArgs e)
        {
            
            if (this.WindowState == FormWindowState.Minimized)
            {
                PopNotif("RFID Printer esta minimizado");
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Entro a notifi icon");
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        public void PopNotif(string text, string title = null)
        {
            Scanner.Icon = Resources.MiniIcon;
            Scanner.BalloonTipTitle = (title != null)? title : "Podiumeeting RFID";
            Scanner.BalloonTipText = text;
            Scanner.ShowBalloonTip(500);
            Scanner.Visible = true;
        }

        public void SetWebSocketStatus(bool connected)
        {
            if (lb_status_ws.InvokeRequired)
            {
                var deleg = new UpdateConnectionStatus(SetWebSocketStatus);
                this.lb_status_ws.Invoke(deleg, new object[] { connected });
            }
            else
            {
                if (connected)
                {
                    lb_status_ws.Text = "On";
                    lb_status_ws.ForeColor = Color.Green;
                }
                else
                {
                    lb_status_ws.Text = "Off";
                    lb_status_ws.ForeColor = Color.Red;
                }
            }
        }

        public void SetPortWebSocekt(int port)
        {
            if (this.lb_port_ws.InvokeRequired)
            {
                var deleg = new UpdatePort(SetPortWebSocekt);
                this.lb_port_ws.Invoke(deleg, new object[] { port });
            }
            else
            {
                lb_port_ws.Text = port.ToString();
            }
        }

        public void SetDiveceStatus(bool connected)
        {
            if (lb_status_device.InvokeRequired)
            {
                var deleg = new UpdateConnectionStatus(SetDiveceStatus);
                this.lb_status_device.Invoke(deleg, new object[] { connected });
            }
            else
            {
                if (connected)
                {
                    PopNotif("Device Scanner connected!");
                    lb_status_device.Text = "Connected";
                    lb_status_device.ForeColor = Color.Green;
                }
                else
                {
                    PopNotif("Device Scanner disconnected");
                    lb_status_device.Text = "Disconnected";
                    lb_status_device.ForeColor = Color.Red;
                }
            }
        }
        
        public void SetTagReaded(string tag)
        {
            if (this.lbl_tag_readed.InvokeRequired)
            {
                var deleg = new UpdateTextLabel(SetTagReaded);
                this.lbl_tag_readed.Invoke(deleg, new object[] { tag });
            }
            else
            {
                lb_tag_readed.Text = tag;
            }
        }

        private void RFIDPrinter_FormClosing(object sender, FormClosingEventArgs e)
        {
            Scanner.Dispose();
            controler.Dispose();
        }
    }
}