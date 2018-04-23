namespace DSN_Transmitter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnopenComport = new System.Windows.Forms.Button();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenMQTT = new System.Windows.Forms.Button();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.spRecieve = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // btnopenComport
            // 
            this.btnopenComport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnopenComport.Location = new System.Drawing.Point(320, 5);
            this.btnopenComport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnopenComport.Name = "btnopenComport";
            this.btnopenComport.Size = new System.Drawing.Size(56, 19);
            this.btnopenComport.TabIndex = 0;
            this.btnopenComport.Text = "Connect";
            this.btnopenComport.UseVisualStyleBackColor = true;
            this.btnopenComport.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(98, 4);
            this.comboBoxPorts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(219, 21);
            this.comboBoxPorts.TabIndex = 1;
            this.comboBoxPorts.DropDown += new System.EventHandler(this.comboBoxPorts_DropDown);
            this.comboBoxPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxPorts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Com Port";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnOpenMQTT
            // 
            this.btnOpenMQTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenMQTT.Location = new System.Drawing.Point(320, 29);
            this.btnOpenMQTT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOpenMQTT.Name = "btnOpenMQTT";
            this.btnOpenMQTT.Size = new System.Drawing.Size(56, 19);
            this.btnOpenMQTT.TabIndex = 3;
            this.btnOpenMQTT.Text = "Connect";
            this.btnOpenMQTT.UseVisualStyleBackColor = true;
            this.btnOpenMQTT.Click += new System.EventHandler(this.btnOpenMQTT_Click);
            // 
            // tbxAddress
            // 
            this.tbxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAddress.Location = new System.Drawing.Point(98, 29);
            this.tbxAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(219, 20);
            this.tbxAddress.TabIndex = 4;
            this.tbxAddress.Text = "192.168.1.137";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "MQTT Server";
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.Location = new System.Drawing.Point(11, 64);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(366, 305);
            this.rtbLog.TabIndex = 6;
            this.rtbLog.Text = "";
            this.rtbLog.TextChanged += new System.EventHandler(this.rtbLog_TextChanged);
            // 
            // spRecieve
            // 
            this.spRecieve.BaudRate = 1200;
            this.spRecieve.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spRecieve_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 379);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxAddress);
            this.Controls.Add(this.btnOpenMQTT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPorts);
            this.Controls.Add(this.btnopenComport);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "DSN Transmitter";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnopenComport;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenMQTT;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.IO.Ports.SerialPort spRecieve;
    }
}

