namespace BaseStation
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnConnect = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.rtbSubscribe = new System.Windows.Forms.RichTextBox();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxTopic = new System.Windows.Forms.TextBox();
            this.btnLedOn = new System.Windows.Forms.Button();
            this.btnLedOff = new System.Windows.Forms.Button();
            this.cbxAutoScroll = new System.Windows.Forms.CheckBox();
            this.cbxRGB1R = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxRGB1B = new System.Windows.Forms.CheckBox();
            this.cbxRGB1G = new System.Windows.Forms.CheckBox();
            this.cbxRGB2G = new System.Windows.Forms.CheckBox();
            this.cbxRGB2B = new System.Windows.Forms.CheckBox();
            this.cbxRGB2R = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTakePhoto = new System.Windows.Forms.Button();
            this.imageControl1 = new Queens_ImageControl.ImageControl();
            this.button1 = new System.Windows.Forms.Button();
            this.btnWebservice = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tvPhotos = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cbxAutoScr = new System.Windows.Forms.CheckBox();
            this.gbxSensors = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxQuality = new System.Windows.Forms.ComboBox();
            this.cbxISO = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxExposure = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnSetPos = new System.Windows.Forms.Button();
            this.tbxSetPos = new System.Windows.Forms.TextBox();
            this.lbxTargets = new System.Windows.Forms.ListBox();
            this.btnYneg10 = new System.Windows.Forms.Button();
            this.btnYpos10 = new System.Windows.Forms.Button();
            this.btnXneg10 = new System.Windows.Forms.Button();
            this.btnXpos10 = new System.Windows.Forms.Button();
            this.tbTargetX = new System.Windows.Forms.TrackBar();
            this.tbTargetY = new System.Windows.Forms.TrackBar();
            this.btnXneg1 = new System.Windows.Forms.Button();
            this.btnXpos1 = new System.Windows.Forms.Button();
            this.btnYpos1 = new System.Windows.Forms.Button();
            this.btnYneg1 = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnTarget4 = new System.Windows.Forms.Button();
            this.btnTarget3 = new System.Windows.Forms.Button();
            this.btnTarget2 = new System.Windows.Forms.Button();
            this.btnTarget1 = new System.Windows.Forms.Button();
            this.btnNextTarget = new System.Windows.Forms.Button();
            this.tbCurrentY = new System.Windows.Forms.TrackBar();
            this.tbCurrentX = new System.Windows.Forms.TrackBar();
            this.pbxLiveFeed = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblTargetRoll = new System.Windows.Forms.Label();
            this.lblTargetPitch = new System.Windows.Forms.Label();
            this.lblCurrentYaw = new System.Windows.Forms.Label();
            this.lblCurrentPitch = new System.Windows.Forms.Label();
            this.lblCurrentRoll = new System.Windows.Forms.Label();
            this.lblBatVoltage = new System.Windows.Forms.Label();
            this.spTransmit = new System.IO.Ports.SerialPort(this.components);
            this.cbxPorts = new System.Windows.Forms.ComboBox();
            this.btnDSN = new System.Windows.Forms.Button();
            this.cbxUseDSN = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTargetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTargetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCurrentY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCurrentX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLiveFeed)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(967, 12);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 28);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Subscribe";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(325, 665);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbxMessage
            // 
            this.tbxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxMessage.Location = new System.Drawing.Point(16, 667);
            this.tbxMessage.Margin = new System.Windows.Forms.Padding(4);
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.Size = new System.Drawing.Size(300, 22);
            this.tbxMessage.TabIndex = 7;
            // 
            // rtbSubscribe
            // 
            this.rtbSubscribe.Location = new System.Drawing.Point(8, 18);
            this.rtbSubscribe.Margin = new System.Windows.Forms.Padding(4);
            this.rtbSubscribe.Name = "rtbSubscribe";
            this.rtbSubscribe.Size = new System.Drawing.Size(377, 237);
            this.rtbSubscribe.TabIndex = 3;
            this.rtbSubscribe.TabStop = false;
            this.rtbSubscribe.Text = "";
            this.rtbSubscribe.TextChanged += new System.EventHandler(this.rtbSubscribe_TextChanged);
            // 
            // tbxAddress
            // 
            this.tbxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAddress.Location = new System.Drawing.Point(496, 15);
            this.tbxAddress.Margin = new System.Windows.Forms.Padding(4);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(461, 22);
            this.tbxAddress.TabIndex = 1;
            this.tbxAddress.Text = "192.168.20.129";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 647);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Message";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 599);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Topic";
            // 
            // tbxTopic
            // 
            this.tbxTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxTopic.Location = new System.Drawing.Point(16, 619);
            this.tbxTopic.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTopic.Name = "tbxTopic";
            this.tbxTopic.Size = new System.Drawing.Size(403, 22);
            this.tbxTopic.TabIndex = 6;
            // 
            // btnLedOn
            // 
            this.btnLedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLedOn.Location = new System.Drawing.Point(295, 250);
            this.btnLedOn.Margin = new System.Windows.Forms.Padding(4);
            this.btnLedOn.Name = "btnLedOn";
            this.btnLedOn.Size = new System.Drawing.Size(100, 28);
            this.btnLedOn.TabIndex = 9;
            this.btnLedOn.Text = "Led On";
            this.btnLedOn.UseVisualStyleBackColor = true;
            this.btnLedOn.Click += new System.EventHandler(this.btnLedOn_Click);
            // 
            // btnLedOff
            // 
            this.btnLedOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLedOff.Location = new System.Drawing.Point(295, 214);
            this.btnLedOff.Margin = new System.Windows.Forms.Padding(4);
            this.btnLedOff.Name = "btnLedOff";
            this.btnLedOff.Size = new System.Drawing.Size(100, 28);
            this.btnLedOff.TabIndex = 10;
            this.btnLedOff.Text = "Led Off";
            this.btnLedOff.UseVisualStyleBackColor = true;
            this.btnLedOff.Click += new System.EventHandler(this.btnLedOff_Click);
            // 
            // cbxAutoScroll
            // 
            this.cbxAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxAutoScroll.AutoSize = true;
            this.cbxAutoScroll.Checked = true;
            this.cbxAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAutoScroll.Location = new System.Drawing.Point(1112, 17);
            this.cbxAutoScroll.Margin = new System.Windows.Forms.Padding(4);
            this.cbxAutoScroll.Name = "cbxAutoScroll";
            this.cbxAutoScroll.Size = new System.Drawing.Size(96, 21);
            this.cbxAutoScroll.TabIndex = 10;
            this.cbxAutoScroll.TabStop = false;
            this.cbxAutoScroll.Text = "Auto scroll";
            this.cbxAutoScroll.UseVisualStyleBackColor = true;
            // 
            // cbxRGB1R
            // 
            this.cbxRGB1R.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRGB1R.AutoSize = true;
            this.cbxRGB1R.Location = new System.Drawing.Point(193, 215);
            this.cbxRGB1R.Margin = new System.Windows.Forms.Padding(4);
            this.cbxRGB1R.Name = "cbxRGB1R";
            this.cbxRGB1R.Size = new System.Drawing.Size(40, 21);
            this.cbxRGB1R.TabIndex = 11;
            this.cbxRGB1R.Text = "R";
            this.cbxRGB1R.UseVisualStyleBackColor = true;
            this.cbxRGB1R.CheckedChanged += new System.EventHandler(this.rgb1_payload);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 196);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "RGB 1";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 196);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "RGB 2";
            // 
            // cbxRGB1B
            // 
            this.cbxRGB1B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRGB1B.AutoSize = true;
            this.cbxRGB1B.Location = new System.Drawing.Point(194, 261);
            this.cbxRGB1B.Margin = new System.Windows.Forms.Padding(4);
            this.cbxRGB1B.Name = "cbxRGB1B";
            this.cbxRGB1B.Size = new System.Drawing.Size(39, 21);
            this.cbxRGB1B.TabIndex = 14;
            this.cbxRGB1B.Text = "B";
            this.cbxRGB1B.UseVisualStyleBackColor = true;
            this.cbxRGB1B.CheckedChanged += new System.EventHandler(this.rgb1_payload);
            // 
            // cbxRGB1G
            // 
            this.cbxRGB1G.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRGB1G.AutoSize = true;
            this.cbxRGB1G.Location = new System.Drawing.Point(193, 238);
            this.cbxRGB1G.Margin = new System.Windows.Forms.Padding(4);
            this.cbxRGB1G.Name = "cbxRGB1G";
            this.cbxRGB1G.Size = new System.Drawing.Size(41, 21);
            this.cbxRGB1G.TabIndex = 15;
            this.cbxRGB1G.Text = "G";
            this.cbxRGB1G.UseVisualStyleBackColor = true;
            this.cbxRGB1G.CheckedChanged += new System.EventHandler(this.rgb1_payload);
            // 
            // cbxRGB2G
            // 
            this.cbxRGB2G.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRGB2G.AutoSize = true;
            this.cbxRGB2G.Location = new System.Drawing.Point(246, 238);
            this.cbxRGB2G.Margin = new System.Windows.Forms.Padding(4);
            this.cbxRGB2G.Name = "cbxRGB2G";
            this.cbxRGB2G.Size = new System.Drawing.Size(41, 21);
            this.cbxRGB2G.TabIndex = 18;
            this.cbxRGB2G.Text = "G";
            this.cbxRGB2G.UseVisualStyleBackColor = true;
            this.cbxRGB2G.CheckedChanged += new System.EventHandler(this.rgb2_payload);
            // 
            // cbxRGB2B
            // 
            this.cbxRGB2B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRGB2B.AutoSize = true;
            this.cbxRGB2B.Location = new System.Drawing.Point(246, 261);
            this.cbxRGB2B.Margin = new System.Windows.Forms.Padding(4);
            this.cbxRGB2B.Name = "cbxRGB2B";
            this.cbxRGB2B.Size = new System.Drawing.Size(39, 21);
            this.cbxRGB2B.TabIndex = 17;
            this.cbxRGB2B.Text = "B";
            this.cbxRGB2B.UseVisualStyleBackColor = true;
            this.cbxRGB2B.CheckedChanged += new System.EventHandler(this.rgb2_payload);
            // 
            // cbxRGB2R
            // 
            this.cbxRGB2R.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRGB2R.AutoSize = true;
            this.cbxRGB2R.Location = new System.Drawing.Point(245, 215);
            this.cbxRGB2R.Margin = new System.Windows.Forms.Padding(4);
            this.cbxRGB2R.Name = "cbxRGB2R";
            this.cbxRGB2R.Size = new System.Drawing.Size(40, 21);
            this.cbxRGB2R.TabIndex = 16;
            this.cbxRGB2R.Text = "R";
            this.cbxRGB2R.UseVisualStyleBackColor = true;
            this.cbxRGB2R.CheckedChanged += new System.EventHandler(this.rgb2_payload);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(1216, 12);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 28);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTakePhoto
            // 
            this.btnTakePhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTakePhoto.Location = new System.Drawing.Point(1225, 626);
            this.btnTakePhoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnTakePhoto.Name = "btnTakePhoto";
            this.btnTakePhoto.Size = new System.Drawing.Size(100, 65);
            this.btnTakePhoto.TabIndex = 21;
            this.btnTakePhoto.Text = "Cheese";
            this.btnTakePhoto.UseVisualStyleBackColor = true;
            this.btnTakePhoto.Click += new System.EventHandler(this.btnTakePhoto_Click);
            // 
            // imageControl1
            // 
            this.imageControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageControl1.Image = null;
            this.imageControl1.initialimage = null;
            this.imageControl1.Location = new System.Drawing.Point(395, 18);
            this.imageControl1.Margin = new System.Windows.Forms.Padding(5);
            this.imageControl1.Name = "imageControl1";
            this.imageControl1.Origin = new System.Drawing.Point(0, 0);
            this.imageControl1.PanButton = System.Windows.Forms.MouseButtons.Left;
            this.imageControl1.PanMode = true;
            this.imageControl1.ScrollbarsVisible = true;
            this.imageControl1.Size = new System.Drawing.Size(971, 577);
            this.imageControl1.StretchImageToFit = false;
            this.imageControl1.TabIndex = 22;
            this.imageControl1.ZoomFactor = 1D;
            this.imageControl1.ZoomOnMouseWheel = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1089, 625);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 28);
            this.button1.TabIndex = 24;
            this.button1.Text = "WebService Off";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnWebservice
            // 
            this.btnWebservice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWebservice.Location = new System.Drawing.Point(1089, 661);
            this.btnWebservice.Margin = new System.Windows.Forms.Padding(4);
            this.btnWebservice.Name = "btnWebservice";
            this.btnWebservice.Size = new System.Drawing.Size(128, 28);
            this.btnWebservice.TabIndex = 23;
            this.btnWebservice.Text = "WebService On";
            this.btnWebservice.UseVisualStyleBackColor = true;
            this.btnWebservice.Click += new System.EventHandler(this.btnWebservice_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(16, 48);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1305, 548);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tvPhotos);
            this.tabPage1.Controls.Add(this.rtbSubscribe);
            this.tabPage1.Controls.Add(this.imageControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1297, 519);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tvPhotos
            // 
            this.tvPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvPhotos.Location = new System.Drawing.Point(9, 265);
            this.tvPhotos.Margin = new System.Windows.Forms.Padding(4);
            this.tvPhotos.Name = "tvPhotos";
            this.tvPhotos.Size = new System.Drawing.Size(376, 210);
            this.tvPhotos.TabIndex = 23;
            this.tvPhotos.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvPhotos_BeforeExpand);
            this.tvPhotos.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPhotos_NodeMouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.cbxAutoScr);
            this.tabPage2.Controls.Add(this.gbxSensors);
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1297, 519);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PID Setings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(192, 352);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(173, 28);
            this.button5.TabIndex = 32;
            this.button5.Text = "RandomSensor2";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(373, 352);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 28);
            this.button4.TabIndex = 31;
            this.button4.Text = "RandomSensor3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(4, 352);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 28);
            this.button3.TabIndex = 30;
            this.button3.Text = "RandomSensor1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbxAutoScr
            // 
            this.cbxAutoScr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxAutoScr.AutoSize = true;
            this.cbxAutoScr.Location = new System.Drawing.Point(586, 323);
            this.cbxAutoScr.Margin = new System.Windows.Forms.Padding(4);
            this.cbxAutoScr.Name = "cbxAutoScr";
            this.cbxAutoScr.Size = new System.Drawing.Size(98, 21);
            this.cbxAutoScr.TabIndex = 2;
            this.cbxAutoScr.Text = "Auto Scroll";
            this.cbxAutoScr.UseVisualStyleBackColor = true;
            // 
            // gbxSensors
            // 
            this.gbxSensors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxSensors.Location = new System.Drawing.Point(693, 9);
            this.gbxSensors.Margin = new System.Windows.Forms.Padding(4);
            this.gbxSensors.Name = "gbxSensors";
            this.gbxSensors.Padding = new System.Windows.Forms.Padding(4);
            this.gbxSensors.Size = new System.Drawing.Size(549, 313);
            this.gbxSensors.TabIndex = 1;
            this.gbxSensors.TabStop = false;
            this.gbxSensors.Text = "Sensors";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(8, 7);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(676, 314);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.cbxQuality);
            this.tabPage3.Controls.Add(this.cbxISO);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.cbxExposure);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1297, 519);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Camera Config";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(337, 197);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(264, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Quality";
            // 
            // cbxQuality
            // 
            this.cbxQuality.FormattingEnabled = true;
            this.cbxQuality.Items.AddRange(new object[] {
            "80",
            "70",
            "60",
            "50",
            "40"});
            this.cbxQuality.Location = new System.Drawing.Point(337, 105);
            this.cbxQuality.Name = "cbxQuality";
            this.cbxQuality.Size = new System.Drawing.Size(121, 24);
            this.cbxQuality.TabIndex = 5;
            // 
            // cbxISO
            // 
            this.cbxISO.FormattingEnabled = true;
            this.cbxISO.Location = new System.Drawing.Point(337, 167);
            this.cbxISO.Name = "cbxISO";
            this.cbxISO.Size = new System.Drawing.Size(121, 24);
            this.cbxISO.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "ISO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Exposure";
            // 
            // cbxExposure
            // 
            this.cbxExposure.FormattingEnabled = true;
            this.cbxExposure.Location = new System.Drawing.Point(337, 137);
            this.cbxExposure.Name = "cbxExposure";
            this.cbxExposure.Size = new System.Drawing.Size(121, 24);
            this.cbxExposure.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnSetPos);
            this.tabPage4.Controls.Add(this.tbxSetPos);
            this.tabPage4.Controls.Add(this.lbxTargets);
            this.tabPage4.Controls.Add(this.btnYneg10);
            this.tabPage4.Controls.Add(this.btnYpos10);
            this.tabPage4.Controls.Add(this.btnXneg10);
            this.tabPage4.Controls.Add(this.btnXpos10);
            this.tabPage4.Controls.Add(this.tbTargetX);
            this.tabPage4.Controls.Add(this.tbTargetY);
            this.tabPage4.Controls.Add(this.btnXneg1);
            this.tabPage4.Controls.Add(this.btnXpos1);
            this.tabPage4.Controls.Add(this.btnYpos1);
            this.tabPage4.Controls.Add(this.btnYneg1);
            this.tabPage4.Controls.Add(this.btnHome);
            this.tabPage4.Controls.Add(this.btnTarget4);
            this.tabPage4.Controls.Add(this.btnTarget3);
            this.tabPage4.Controls.Add(this.btnTarget2);
            this.tabPage4.Controls.Add(this.btnTarget1);
            this.tabPage4.Controls.Add(this.btnNextTarget);
            this.tabPage4.Controls.Add(this.tbCurrentY);
            this.tabPage4.Controls.Add(this.tbCurrentX);
            this.tabPage4.Controls.Add(this.pbxLiveFeed);
            this.tabPage4.Controls.Add(this.checkBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1297, 519);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Orentation";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnSetPos
            // 
            this.btnSetPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetPos.Location = new System.Drawing.Point(763, 46);
            this.btnSetPos.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetPos.Name = "btnSetPos";
            this.btnSetPos.Size = new System.Drawing.Size(133, 28);
            this.btnSetPos.TabIndex = 27;
            this.btnSetPos.Text = "button6";
            this.btnSetPos.UseVisualStyleBackColor = true;
            this.btnSetPos.Click += new System.EventHandler(this.btnSetPos_Click);
            // 
            // tbxSetPos
            // 
            this.tbxSetPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSetPos.Location = new System.Drawing.Point(763, 14);
            this.tbxSetPos.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSetPos.Name = "tbxSetPos";
            this.tbxSetPos.Size = new System.Drawing.Size(132, 22);
            this.tbxSetPos.TabIndex = 26;
            // 
            // lbxTargets
            // 
            this.lbxTargets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxTargets.FormattingEnabled = true;
            this.lbxTargets.ItemHeight = 16;
            this.lbxTargets.Items.AddRange(new object[] {
            "12 10",
            "10 -10",
            "25 30",
            "30 30",
            "40 30",
            "45 0",
            "-50 -50",
            "50 -50",
            "50 50",
            "-50 50"});
            this.lbxTargets.Location = new System.Drawing.Point(595, 5);
            this.lbxTargets.Margin = new System.Windows.Forms.Padding(4);
            this.lbxTargets.Name = "lbxTargets";
            this.lbxTargets.Size = new System.Drawing.Size(157, 308);
            this.lbxTargets.TabIndex = 25;
            // 
            // btnYneg10
            // 
            this.btnYneg10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYneg10.Location = new System.Drawing.Point(939, 326);
            this.btnYneg10.Margin = new System.Windows.Forms.Padding(4);
            this.btnYneg10.Name = "btnYneg10";
            this.btnYneg10.Size = new System.Drawing.Size(47, 28);
            this.btnYneg10.TabIndex = 24;
            this.btnYneg10.Text = "-5";
            this.btnYneg10.UseVisualStyleBackColor = true;
            this.btnYneg10.Click += new System.EventHandler(this.btnYneg10_Click);
            // 
            // btnYpos10
            // 
            this.btnYpos10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYpos10.Location = new System.Drawing.Point(939, 182);
            this.btnYpos10.Margin = new System.Windows.Forms.Padding(4);
            this.btnYpos10.Name = "btnYpos10";
            this.btnYpos10.Size = new System.Drawing.Size(47, 28);
            this.btnYpos10.TabIndex = 23;
            this.btnYpos10.Text = "+5";
            this.btnYpos10.UseVisualStyleBackColor = true;
            this.btnYpos10.Click += new System.EventHandler(this.btnYpos10_Click);
            // 
            // btnXneg10
            // 
            this.btnXneg10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXneg10.Location = new System.Drawing.Point(832, 254);
            this.btnXneg10.Margin = new System.Windows.Forms.Padding(4);
            this.btnXneg10.Name = "btnXneg10";
            this.btnXneg10.Size = new System.Drawing.Size(47, 28);
            this.btnXneg10.TabIndex = 22;
            this.btnXneg10.Text = "-5";
            this.btnXneg10.UseVisualStyleBackColor = true;
            this.btnXneg10.Click += new System.EventHandler(this.btnXneg10_Click);
            // 
            // btnXpos10
            // 
            this.btnXpos10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXpos10.Location = new System.Drawing.Point(1041, 254);
            this.btnXpos10.Margin = new System.Windows.Forms.Padding(4);
            this.btnXpos10.Name = "btnXpos10";
            this.btnXpos10.Size = new System.Drawing.Size(49, 28);
            this.btnXpos10.TabIndex = 21;
            this.btnXpos10.Text = "+5";
            this.btnXpos10.UseVisualStyleBackColor = true;
            this.btnXpos10.Click += new System.EventHandler(this.btnXpos10_Click);
            // 
            // tbTargetX
            // 
            this.tbTargetX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTargetX.Location = new System.Drawing.Point(595, 407);
            this.tbTargetX.Margin = new System.Windows.Forms.Padding(4);
            this.tbTargetX.Maximum = 45;
            this.tbTargetX.Minimum = -45;
            this.tbTargetX.Name = "tbTargetX";
            this.tbTargetX.Size = new System.Drawing.Size(589, 56);
            this.tbTargetX.TabIndex = 20;
            this.tbTargetX.Scroll += new System.EventHandler(this.tbCurrentX_Scroll);
            // 
            // tbTargetY
            // 
            this.tbTargetY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTargetY.Location = new System.Drawing.Point(1148, 17);
            this.tbTargetY.Margin = new System.Windows.Forms.Padding(4);
            this.tbTargetY.Maximum = 45;
            this.tbTargetY.Minimum = -45;
            this.tbTargetY.Name = "tbTargetY";
            this.tbTargetY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbTargetY.Size = new System.Drawing.Size(56, 361);
            this.tbTargetY.TabIndex = 19;
            this.tbTargetY.Scroll += new System.EventHandler(this.tbCurrentY_Scroll);
            // 
            // btnXneg1
            // 
            this.btnXneg1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXneg1.Location = new System.Drawing.Point(887, 254);
            this.btnXneg1.Margin = new System.Windows.Forms.Padding(4);
            this.btnXneg1.Name = "btnXneg1";
            this.btnXneg1.Size = new System.Drawing.Size(47, 28);
            this.btnXneg1.TabIndex = 18;
            this.btnXneg1.Text = "-1";
            this.btnXneg1.UseVisualStyleBackColor = true;
            this.btnXneg1.Click += new System.EventHandler(this.btnXneg1_Click);
            // 
            // btnXpos1
            // 
            this.btnXpos1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXpos1.Location = new System.Drawing.Point(984, 254);
            this.btnXpos1.Margin = new System.Windows.Forms.Padding(4);
            this.btnXpos1.Name = "btnXpos1";
            this.btnXpos1.Size = new System.Drawing.Size(49, 28);
            this.btnXpos1.TabIndex = 17;
            this.btnXpos1.Text = "+1";
            this.btnXpos1.UseVisualStyleBackColor = true;
            this.btnXpos1.Click += new System.EventHandler(this.btnXpos1_Click);
            // 
            // btnYpos1
            // 
            this.btnYpos1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYpos1.Location = new System.Drawing.Point(939, 218);
            this.btnYpos1.Margin = new System.Windows.Forms.Padding(4);
            this.btnYpos1.Name = "btnYpos1";
            this.btnYpos1.Size = new System.Drawing.Size(47, 28);
            this.btnYpos1.TabIndex = 16;
            this.btnYpos1.Text = "+1";
            this.btnYpos1.UseVisualStyleBackColor = true;
            this.btnYpos1.Click += new System.EventHandler(this.btnYpos1_Click);
            // 
            // btnYneg1
            // 
            this.btnYneg1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYneg1.Location = new System.Drawing.Point(939, 290);
            this.btnYneg1.Margin = new System.Windows.Forms.Padding(4);
            this.btnYneg1.Name = "btnYneg1";
            this.btnYneg1.Size = new System.Drawing.Size(47, 28);
            this.btnYneg1.TabIndex = 15;
            this.btnYneg1.Text = "-1";
            this.btnYneg1.UseVisualStyleBackColor = true;
            this.btnYneg1.Click += new System.EventHandler(this.btnYneg1_Click);
            // 
            // btnHome
            // 
            this.btnHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHome.Location = new System.Drawing.Point(904, 82);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(100, 28);
            this.btnHome.TabIndex = 14;
            this.btnHome.Text = "Home (0,0)";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnTarget4
            // 
            this.btnTarget4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTarget4.Location = new System.Drawing.Point(1012, 47);
            this.btnTarget4.Margin = new System.Windows.Forms.Padding(4);
            this.btnTarget4.Name = "btnTarget4";
            this.btnTarget4.Size = new System.Drawing.Size(100, 28);
            this.btnTarget4.TabIndex = 13;
            this.btnTarget4.Text = "Target4";
            this.btnTarget4.UseVisualStyleBackColor = true;
            this.btnTarget4.Click += new System.EventHandler(this.btnTarget4_Click);
            // 
            // btnTarget3
            // 
            this.btnTarget3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTarget3.Location = new System.Drawing.Point(904, 47);
            this.btnTarget3.Margin = new System.Windows.Forms.Padding(4);
            this.btnTarget3.Name = "btnTarget3";
            this.btnTarget3.Size = new System.Drawing.Size(100, 28);
            this.btnTarget3.TabIndex = 12;
            this.btnTarget3.Text = "Target3";
            this.btnTarget3.UseVisualStyleBackColor = true;
            this.btnTarget3.Click += new System.EventHandler(this.btnTarget3_Click);
            // 
            // btnTarget2
            // 
            this.btnTarget2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTarget2.Location = new System.Drawing.Point(1012, 11);
            this.btnTarget2.Margin = new System.Windows.Forms.Padding(4);
            this.btnTarget2.Name = "btnTarget2";
            this.btnTarget2.Size = new System.Drawing.Size(100, 28);
            this.btnTarget2.TabIndex = 11;
            this.btnTarget2.Text = "Target2";
            this.btnTarget2.UseVisualStyleBackColor = true;
            this.btnTarget2.Click += new System.EventHandler(this.btnTarget2_Click);
            // 
            // btnTarget1
            // 
            this.btnTarget1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTarget1.Location = new System.Drawing.Point(904, 11);
            this.btnTarget1.Margin = new System.Windows.Forms.Padding(4);
            this.btnTarget1.Name = "btnTarget1";
            this.btnTarget1.Size = new System.Drawing.Size(100, 28);
            this.btnTarget1.TabIndex = 10;
            this.btnTarget1.Text = "Target1";
            this.btnTarget1.UseVisualStyleBackColor = true;
            this.btnTarget1.Click += new System.EventHandler(this.btnTarget1_Click);
            // 
            // btnNextTarget
            // 
            this.btnNextTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextTarget.Location = new System.Drawing.Point(595, 327);
            this.btnNextTarget.Margin = new System.Windows.Forms.Padding(4);
            this.btnNextTarget.Name = "btnNextTarget";
            this.btnNextTarget.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNextTarget.Size = new System.Drawing.Size(159, 28);
            this.btnNextTarget.TabIndex = 6;
            this.btnNextTarget.Text = "Next";
            this.btnNextTarget.UseVisualStyleBackColor = true;
            this.btnNextTarget.Click += new System.EventHandler(this.btnNextTarget_Click);
            // 
            // tbCurrentY
            // 
            this.tbCurrentY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCurrentY.Enabled = false;
            this.tbCurrentY.Location = new System.Drawing.Point(1120, 17);
            this.tbCurrentY.Margin = new System.Windows.Forms.Padding(4);
            this.tbCurrentY.Maximum = 45;
            this.tbCurrentY.Minimum = -45;
            this.tbCurrentY.Name = "tbCurrentY";
            this.tbCurrentY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbCurrentY.Size = new System.Drawing.Size(56, 361);
            this.tbCurrentY.TabIndex = 4;
            // 
            // tbCurrentX
            // 
            this.tbCurrentX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCurrentX.Enabled = false;
            this.tbCurrentX.Location = new System.Drawing.Point(593, 385);
            this.tbCurrentX.Margin = new System.Windows.Forms.Padding(4);
            this.tbCurrentX.Maximum = 45;
            this.tbCurrentX.Minimum = -45;
            this.tbCurrentX.Name = "tbCurrentX";
            this.tbCurrentX.Size = new System.Drawing.Size(589, 56);
            this.tbCurrentX.TabIndex = 3;
            // 
            // pbxLiveFeed
            // 
            this.pbxLiveFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxLiveFeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxLiveFeed.Location = new System.Drawing.Point(4, 4);
            this.pbxLiveFeed.Margin = new System.Windows.Forms.Padding(4);
            this.pbxLiveFeed.Name = "pbxLiveFeed";
            this.pbxLiveFeed.Size = new System.Drawing.Size(581, 374);
            this.pbxLiveFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLiveFeed.TabIndex = 2;
            this.pbxLiveFeed.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(4, 403);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 21);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Live feed";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnLedOff);
            this.tabPage5.Controls.Add(this.btnLedOn);
            this.tabPage5.Controls.Add(this.cbxRGB1R);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.cbxRGB1B);
            this.tabPage5.Controls.Add(this.cbxRGB1G);
            this.tabPage5.Controls.Add(this.cbxRGB2R);
            this.tabPage5.Controls.Add(this.cbxRGB2B);
            this.tabPage5.Controls.Add(this.cbxRGB2G);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1297, 519);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Status";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblTargetRoll
            // 
            this.lblTargetRoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTargetRoll.AutoSize = true;
            this.lblTargetRoll.Location = new System.Drawing.Point(808, 647);
            this.lblTargetRoll.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetRoll.Name = "lblTargetRoll";
            this.lblTargetRoll.Size = new System.Drawing.Size(82, 17);
            this.lblTargetRoll.TabIndex = 28;
            this.lblTargetRoll.Text = "Target Roll:";
            // 
            // lblTargetPitch
            // 
            this.lblTargetPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTargetPitch.AutoSize = true;
            this.lblTargetPitch.Location = new System.Drawing.Point(808, 631);
            this.lblTargetPitch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetPitch.Name = "lblTargetPitch";
            this.lblTargetPitch.Size = new System.Drawing.Size(89, 17);
            this.lblTargetPitch.TabIndex = 27;
            this.lblTargetPitch.Text = "Target Pitch:";
            // 
            // lblCurrentYaw
            // 
            this.lblCurrentYaw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentYaw.AutoSize = true;
            this.lblCurrentYaw.Location = new System.Drawing.Point(944, 663);
            this.lblCurrentYaw.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentYaw.Name = "lblCurrentYaw";
            this.lblCurrentYaw.Size = new System.Drawing.Size(89, 17);
            this.lblCurrentYaw.TabIndex = 31;
            this.lblCurrentYaw.Text = "Current Yaw:";
            // 
            // lblCurrentPitch
            // 
            this.lblCurrentPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentPitch.AutoSize = true;
            this.lblCurrentPitch.Location = new System.Drawing.Point(944, 631);
            this.lblCurrentPitch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentPitch.Name = "lblCurrentPitch";
            this.lblCurrentPitch.Size = new System.Drawing.Size(94, 17);
            this.lblCurrentPitch.TabIndex = 30;
            this.lblCurrentPitch.Text = "Current Pitch:";
            // 
            // lblCurrentRoll
            // 
            this.lblCurrentRoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentRoll.AutoSize = true;
            this.lblCurrentRoll.Location = new System.Drawing.Point(944, 647);
            this.lblCurrentRoll.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentRoll.Name = "lblCurrentRoll";
            this.lblCurrentRoll.Size = new System.Drawing.Size(87, 17);
            this.lblCurrentRoll.TabIndex = 29;
            this.lblCurrentRoll.Text = "Current Roll:";
            // 
            // lblBatVoltage
            // 
            this.lblBatVoltage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBatVoltage.AutoSize = true;
            this.lblBatVoltage.Location = new System.Drawing.Point(589, 631);
            this.lblBatVoltage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBatVoltage.Name = "lblBatVoltage";
            this.lblBatVoltage.Size = new System.Drawing.Size(109, 17);
            this.lblBatVoltage.TabIndex = 32;
            this.lblBatVoltage.Text = "Battery Voltage:";
            // 
            // cbxPorts
            // 
            this.cbxPorts.FormattingEnabled = true;
            this.cbxPorts.Location = new System.Drawing.Point(21, 16);
            this.cbxPorts.Margin = new System.Windows.Forms.Padding(4);
            this.cbxPorts.Name = "cbxPorts";
            this.cbxPorts.Size = new System.Drawing.Size(193, 24);
            this.cbxPorts.TabIndex = 33;
            this.cbxPorts.DropDown += new System.EventHandler(this.comboBoxPorts_DropDown);
            // 
            // btnDSN
            // 
            this.btnDSN.Location = new System.Drawing.Point(225, 15);
            this.btnDSN.Margin = new System.Windows.Forms.Padding(4);
            this.btnDSN.Name = "btnDSN";
            this.btnDSN.Size = new System.Drawing.Size(100, 28);
            this.btnDSN.TabIndex = 34;
            this.btnDSN.Text = "Connect";
            this.btnDSN.UseVisualStyleBackColor = true;
            this.btnDSN.Click += new System.EventHandler(this.btnDSN_Click);
            // 
            // cbxUseDSN
            // 
            this.cbxUseDSN.AutoSize = true;
            this.cbxUseDSN.Location = new System.Drawing.Point(333, 17);
            this.cbxUseDSN.Name = "cbxUseDSN";
            this.cbxUseDSN.Size = new System.Drawing.Size(92, 21);
            this.cbxUseDSN.TabIndex = 35;
            this.cbxUseDSN.Text = "Use Dsn?";
            this.cbxUseDSN.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 715);
            this.Controls.Add(this.cbxUseDSN);
            this.Controls.Add(this.btnDSN);
            this.Controls.Add(this.cbxPorts);
            this.Controls.Add(this.lblBatVoltage);
            this.Controls.Add(this.lblCurrentYaw);
            this.Controls.Add(this.lblCurrentPitch);
            this.Controls.Add(this.lblCurrentRoll);
            this.Controls.Add(this.lblTargetRoll);
            this.Controls.Add(this.lblTargetPitch);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnWebservice);
            this.Controls.Add(this.btnTakePhoto);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cbxAutoScroll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxTopic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxAddress);
            this.Controls.Add(this.tbxMessage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnConnect);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Team 4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTargetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTargetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCurrentY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCurrentX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLiveFeed)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbxMessage;
        private System.Windows.Forms.RichTextBox rtbSubscribe;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxTopic;
        private System.Windows.Forms.Button btnLedOn;
        private System.Windows.Forms.Button btnLedOff;
        private System.Windows.Forms.CheckBox cbxAutoScroll;
        private System.Windows.Forms.CheckBox cbxRGB1R;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxRGB1B;
        private System.Windows.Forms.CheckBox cbxRGB1G;
        private System.Windows.Forms.CheckBox cbxRGB2G;
        private System.Windows.Forms.CheckBox cbxRGB2B;
        private System.Windows.Forms.CheckBox cbxRGB2R;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnTakePhoto;
        private Queens_ImageControl.ImageControl imageControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnWebservice;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox gbxSensors;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbxAutoScr;
        private System.Windows.Forms.TreeView tvPhotos;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pbxLiveFeed;
        private System.Windows.Forms.Button btnNextTarget;
        private System.Windows.Forms.TrackBar tbCurrentY;
        private System.Windows.Forms.TrackBar tbCurrentX;
        private System.Windows.Forms.Button btnTarget1;
        private System.Windows.Forms.Button btnTarget4;
        private System.Windows.Forms.Button btnTarget3;
        private System.Windows.Forms.Button btnTarget2;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label lblTargetRoll;
        private System.Windows.Forms.Label lblTargetPitch;
        private System.Windows.Forms.Label lblCurrentYaw;
        private System.Windows.Forms.Label lblCurrentPitch;
        private System.Windows.Forms.Label lblCurrentRoll;
        private System.Windows.Forms.Label lblBatVoltage;
        private System.Windows.Forms.Button btnYneg10;
        private System.Windows.Forms.Button btnYpos10;
        private System.Windows.Forms.Button btnXneg10;
        private System.Windows.Forms.Button btnXpos10;
        private System.Windows.Forms.TrackBar tbTargetX;
        private System.Windows.Forms.TrackBar tbTargetY;
        private System.Windows.Forms.Button btnXneg1;
        private System.Windows.Forms.Button btnXpos1;
        private System.Windows.Forms.Button btnYpos1;
        private System.Windows.Forms.Button btnYneg1;
        private System.Windows.Forms.ListBox lbxTargets;
        private System.Windows.Forms.Button btnSetPos;
        private System.Windows.Forms.TextBox tbxSetPos;
        private System.IO.Ports.SerialPort spTransmit;
        private System.Windows.Forms.ComboBox cbxPorts;
        private System.Windows.Forms.Button btnDSN;
        private System.Windows.Forms.CheckBox cbxUseDSN;
        private System.Windows.Forms.ComboBox cbxISO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxExposure;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxQuality;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

