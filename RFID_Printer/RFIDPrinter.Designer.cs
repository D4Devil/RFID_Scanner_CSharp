namespace RFID_Printer
{
    partial class RFIDPrinter
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Scanner = new System.Windows.Forms.NotifyIcon(this.components);
            this.lbl_dev_status = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_tag_readed = new System.Windows.Forms.Label();
            this.lb_status_device = new System.Windows.Forms.Label();
            this.lbl_tag_readed = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_port_ws = new System.Windows.Forms.Label();
            this.lb_status_ws = new System.Windows.Forms.Label();
            this.lbl_port = new System.Windows.Forms.Label();
            this.lb_status_ws_text = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scanner
            // 
            this.Scanner.Text = "notifyIcon";
            this.Scanner.Visible = true;
            this.Scanner.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // lbl_dev_status
            // 
            this.lbl_dev_status.AutoSize = true;
            this.lbl_dev_status.Location = new System.Drawing.Point(6, 25);
            this.lbl_dev_status.Name = "lbl_dev_status";
            this.lbl_dev_status.Size = new System.Drawing.Size(51, 13);
            this.lbl_dev_status.TabIndex = 2;
            this.lbl_dev_status.Text = "Status: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lb_tag_readed);
            this.groupBox1.Controls.Add(this.lb_status_device);
            this.groupBox1.Controls.Add(this.lbl_tag_readed);
            this.groupBox1.Controls.Add(this.lbl_dev_status);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 128);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device";
            // 
            // lb_tag_readed
            // 
            this.lb_tag_readed.AutoSize = true;
            this.lb_tag_readed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tag_readed.Location = new System.Drawing.Point(82, 41);
            this.lb_tag_readed.Name = "lb_tag_readed";
            this.lb_tag_readed.Size = new System.Drawing.Size(45, 24);
            this.lb_tag_readed.TabIndex = 5;
            this.lb_tag_readed.Text = "-----";
            // 
            // lb_status_device
            // 
            this.lb_status_device.AutoSize = true;
            this.lb_status_device.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status_device.ForeColor = System.Drawing.Color.Red;
            this.lb_status_device.Location = new System.Drawing.Point(82, 20);
            this.lb_status_device.Name = "lb_status_device";
            this.lb_status_device.Size = new System.Drawing.Size(45, 20);
            this.lb_status_device.TabIndex = 4;
            this.lb_status_device.Text = "------";
            // 
            // lbl_tag_readed
            // 
            this.lbl_tag_readed.AutoSize = true;
            this.lbl_tag_readed.Location = new System.Drawing.Point(6, 49);
            this.lbl_tag_readed.Name = "lbl_tag_readed";
            this.lbl_tag_readed.Size = new System.Drawing.Size(81, 13);
            this.lbl_tag_readed.TabIndex = 3;
            this.lbl_tag_readed.Text = "Tag Readed:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_port_ws);
            this.groupBox2.Controls.Add(this.lb_status_ws);
            this.groupBox2.Controls.Add(this.lbl_port);
            this.groupBox2.Controls.Add(this.lb_status_ws_text);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 78);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Websocket";
            // 
            // lb_port_ws
            // 
            this.lb_port_ws.AutoSize = true;
            this.lb_port_ws.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_port_ws.Location = new System.Drawing.Point(83, 48);
            this.lb_port_ws.Name = "lb_port_ws";
            this.lb_port_ws.Size = new System.Drawing.Size(32, 15);
            this.lb_port_ws.TabIndex = 6;
            this.lb_port_ws.Text = "-----";
            // 
            // lb_status_ws
            // 
            this.lb_status_ws.AutoSize = true;
            this.lb_status_ws.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status_ws.ForeColor = System.Drawing.Color.Red;
            this.lb_status_ws.Location = new System.Drawing.Point(82, 20);
            this.lb_status_ws.Name = "lb_status_ws";
            this.lb_status_ws.Size = new System.Drawing.Size(39, 20);
            this.lb_status_ws.TabIndex = 6;
            this.lb_status_ws.Text = "-----";
            // 
            // lbl_port
            // 
            this.lbl_port.AutoSize = true;
            this.lbl_port.Location = new System.Drawing.Point(6, 48);
            this.lbl_port.Name = "lbl_port";
            this.lbl_port.Size = new System.Drawing.Size(34, 13);
            this.lbl_port.TabIndex = 3;
            this.lbl_port.Text = "Port:";
            // 
            // lb_status_ws_text
            // 
            this.lb_status_ws_text.AutoSize = true;
            this.lb_status_ws_text.Location = new System.Drawing.Point(6, 25);
            this.lb_status_ws_text.Name = "lb_status_ws_text";
            this.lb_status_ws_text.Size = new System.Drawing.Size(51, 13);
            this.lb_status_ws_text.TabIndex = 2;
            this.lb_status_ws_text.Text = "Status: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-3, 74);
            this.label1.MaximumSize = new System.Drawing.Size(220, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 45);
            this.label1.TabIndex = 5;
            this.label1.Text = "Al minimizar esta ventana se ocultara la aplicación y se podra visualizar en los " +
    "iconos ocultos. ";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // RFIDPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 227);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RFIDPrinter";
            this.Text = "RFID Printer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RFIDPrinter_FormClosing);
            this.Resize += new System.EventHandler(this.form_printQueue_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon Scanner;
        private System.Windows.Forms.Label lbl_dev_status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_status_ws_text;
        private System.Windows.Forms.Label lbl_port;
        private System.Windows.Forms.Label lbl_tag_readed;
        private System.Windows.Forms.Label lb_tag_readed;
        private System.Windows.Forms.Label lb_status_device;
        private System.Windows.Forms.Label lb_port_ws;
        private System.Windows.Forms.Label lb_status_ws;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

