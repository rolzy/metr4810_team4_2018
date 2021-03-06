﻿namespace BaseStation
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
            this.btnCyclePi = new System.Windows.Forms.Button();
            this.btnControlOff = new System.Windows.Forms.Button();
            this.cbxAutoScroll = new System.Windows.Forms.CheckBox();
            this.cbxControl = new System.Windows.Forms.CheckBox();
            this.cbxPiStatus = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTakePhoto = new System.Windows.Forms.Button();
            this.imageControl1 = new Queens_ImageControl.ImageControl();
            this.button1 = new System.Windows.Forms.Button();
            this.btnWebservice = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.lblGamma = new System.Windows.Forms.Label();
            this.tbGamma = new System.Windows.Forms.TrackBar();
            this.tvPhotos = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCalMag = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.ckbStart = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPidPitch = new System.Windows.Forms.Button();
            this.btnPidYaw = new System.Windows.Forms.Button();
            this.tbxKdPitch = new System.Windows.Forms.TextBox();
            this.tbxKiPitch = new System.Windows.Forms.TextBox();
            this.tbxKpPitch = new System.Windows.Forms.TextBox();
            this.tbxKdYaw = new System.Windows.Forms.TextBox();
            this.tbxKiYaw = new System.Windows.Forms.TextBox();
            this.tbxKpYaw = new System.Windows.Forms.TextBox();
            this.cbxAutoScr = new System.Windows.Forms.CheckBox();
            this.gbxSensors = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.cbxAWB = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxQuality = new System.Windows.Forms.ComboBox();
            this.cbxISO = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxExposure = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbxSetPosY = new System.Windows.Forms.TextBox();
            this.btnSetPos = new System.Windows.Forms.Button();
            this.tbxSetPosX = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.tbGamma)).BeginInit();
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
            this.btnConnect.Location = new System.Drawing.Point(758, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.TabStop = false;
            this.btnConnect.Text = "Subscribe";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(244, 552);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbxMessage
            // 
            this.tbxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxMessage.Location = new System.Drawing.Point(12, 553);
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.Size = new System.Drawing.Size(226, 20);
            this.tbxMessage.TabIndex = 7;
            // 
            // rtbSubscribe
            // 
            this.rtbSubscribe.Location = new System.Drawing.Point(6, 15);
            this.rtbSubscribe.Name = "rtbSubscribe";
            this.rtbSubscribe.Size = new System.Drawing.Size(284, 164);
            this.rtbSubscribe.TabIndex = 3;
            this.rtbSubscribe.TabStop = false;
            this.rtbSubscribe.Text = "";
            this.rtbSubscribe.TextChanged += new System.EventHandler(this.rtbSubscribe_TextChanged);
            // 
            // tbxAddress
            // 
            this.tbxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAddress.Location = new System.Drawing.Point(405, 12);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(347, 20);
            this.tbxAddress.TabIndex = 1;
            this.tbxAddress.TabStop = false;
            this.tbxAddress.Text = "192.168.20.129";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 539);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Message";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Topic";
            // 
            // tbxTopic
            // 
            this.tbxTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxTopic.Location = new System.Drawing.Point(12, 514);
            this.tbxTopic.Name = "tbxTopic";
            this.tbxTopic.Size = new System.Drawing.Size(303, 20);
            this.tbxTopic.TabIndex = 6;
            // 
            // btnCyclePi
            // 
            this.btnCyclePi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCyclePi.Location = new System.Drawing.Point(331, 180);
            this.btnCyclePi.Name = "btnCyclePi";
            this.btnCyclePi.Size = new System.Drawing.Size(98, 23);
            this.btnCyclePi.TabIndex = 9;
            this.btnCyclePi.Text = "Cycle Pi";
            this.btnCyclePi.UseVisualStyleBackColor = true;
            this.btnCyclePi.Click += new System.EventHandler(this.btnLedOn_Click);
            // 
            // btnControlOff
            // 
            this.btnControlOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnControlOff.Location = new System.Drawing.Point(331, 219);
            this.btnControlOff.Name = "btnControlOff";
            this.btnControlOff.Size = new System.Drawing.Size(98, 23);
            this.btnControlOff.TabIndex = 10;
            this.btnControlOff.Text = "Cycle Control";
            this.btnControlOff.UseVisualStyleBackColor = true;
            this.btnControlOff.Click += new System.EventHandler(this.btnLedOff_Click);
            // 
            // cbxAutoScroll
            // 
            this.cbxAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxAutoScroll.AutoSize = true;
            this.cbxAutoScroll.Checked = true;
            this.cbxAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAutoScroll.Location = new System.Drawing.Point(864, 14);
            this.cbxAutoScroll.Name = "cbxAutoScroll";
            this.cbxAutoScroll.Size = new System.Drawing.Size(75, 17);
            this.cbxAutoScroll.TabIndex = 10;
            this.cbxAutoScroll.TabStop = false;
            this.cbxAutoScroll.Text = "Auto scroll";
            this.cbxAutoScroll.UseVisualStyleBackColor = true;
            // 
            // cbxControl
            // 
            this.cbxControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxControl.AutoSize = true;
            this.cbxControl.Location = new System.Drawing.Point(439, 220);
            this.cbxControl.Name = "cbxControl";
            this.cbxControl.Size = new System.Drawing.Size(92, 17);
            this.cbxControl.TabIndex = 11;
            this.cbxControl.Text = "Control Status";
            this.cbxControl.UseVisualStyleBackColor = true;
            // 
            // cbxPiStatus
            // 
            this.cbxPiStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPiStatus.AutoSize = true;
            this.cbxPiStatus.Location = new System.Drawing.Point(439, 185);
            this.cbxPiStatus.Name = "cbxPiStatus";
            this.cbxPiStatus.Size = new System.Drawing.Size(66, 17);
            this.cbxPiStatus.TabIndex = 16;
            this.cbxPiStatus.Text = "Pi status";
            this.cbxPiStatus.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(945, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTakePhoto
            // 
            this.btnTakePhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTakePhoto.Location = new System.Drawing.Point(952, 520);
            this.btnTakePhoto.Name = "btnTakePhoto";
            this.btnTakePhoto.Size = new System.Drawing.Size(75, 53);
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
            this.imageControl1.Location = new System.Drawing.Point(296, 15);
            this.imageControl1.Margin = new System.Windows.Forms.Padding(4);
            this.imageControl1.Name = "imageControl1";
            this.imageControl1.Origin = new System.Drawing.Point(0, 0);
            this.imageControl1.PanButton = System.Windows.Forms.MouseButtons.Left;
            this.imageControl1.PanMode = true;
            this.imageControl1.ScrollbarsVisible = true;
            this.imageControl1.Size = new System.Drawing.Size(728, 469);
            this.imageControl1.StretchImageToFit = false;
            this.imageControl1.TabIndex = 22;
            this.imageControl1.ZoomFactor = 1D;
            this.imageControl1.ZoomOnMouseWheel = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(850, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "WebService Off";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnWebservice
            // 
            this.btnWebservice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWebservice.Location = new System.Drawing.Point(850, 548);
            this.btnWebservice.Name = "btnWebservice";
            this.btnWebservice.Size = new System.Drawing.Size(96, 23);
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
            this.tabControl1.Location = new System.Drawing.Point(12, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1012, 457);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.lblGamma);
            this.tabPage1.Controls.Add(this.tbGamma);
            this.tabPage1.Controls.Add(this.tvPhotos);
            this.tabPage1.Controls.Add(this.rtbSubscribe);
            this.tabPage1.Controls.Add(this.imageControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1004, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 352);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Gamma";
            // 
            // lblGamma
            // 
            this.lblGamma.AutoSize = true;
            this.lblGamma.Location = new System.Drawing.Point(255, 371);
            this.lblGamma.Name = "lblGamma";
            this.lblGamma.Size = new System.Drawing.Size(35, 13);
            this.lblGamma.TabIndex = 36;
            this.lblGamma.Text = "label8";
            // 
            // tbGamma
            // 
            this.tbGamma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbGamma.Location = new System.Drawing.Point(6, 368);
            this.tbGamma.Name = "tbGamma";
            this.tbGamma.Size = new System.Drawing.Size(251, 45);
            this.tbGamma.TabIndex = 24;
            this.tbGamma.Scroll += new System.EventHandler(this.tbGamma_Scroll);
            // 
            // tvPhotos
            // 
            this.tvPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvPhotos.Location = new System.Drawing.Point(6, 185);
            this.tvPhotos.Name = "tvPhotos";
            this.tvPhotos.Size = new System.Drawing.Size(283, 164);
            this.tvPhotos.TabIndex = 23;
            this.tvPhotos.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvPhotos_BeforeExpand);
            this.tvPhotos.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPhotos_NodeMouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCalMag);
            this.tabPage2.Controls.Add(this.btnRead);
            this.tabPage2.Controls.Add(this.btnCalibrate);
            this.tabPage2.Controls.Add(this.ckbStart);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.btnPidPitch);
            this.tabPage2.Controls.Add(this.btnPidYaw);
            this.tabPage2.Controls.Add(this.tbxKdPitch);
            this.tabPage2.Controls.Add(this.tbxKiPitch);
            this.tabPage2.Controls.Add(this.tbxKpPitch);
            this.tabPage2.Controls.Add(this.tbxKdYaw);
            this.tabPage2.Controls.Add(this.tbxKiYaw);
            this.tabPage2.Controls.Add(this.tbxKpYaw);
            this.tabPage2.Controls.Add(this.cbxAutoScr);
            this.tabPage2.Controls.Add(this.gbxSensors);
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1004, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PID Setings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCalMag
            // 
            this.btnCalMag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalMag.Location = new System.Drawing.Point(589, 379);
            this.btnCalMag.Name = "btnCalMag";
            this.btnCalMag.Size = new System.Drawing.Size(85, 23);
            this.btnCalMag.TabIndex = 50;
            this.btnCalMag.Text = "Magnetometer";
            this.btnCalMag.UseVisualStyleBackColor = true;
            this.btnCalMag.Click += new System.EventHandler(this.btnCalMag_Click);
            // 
            // btnRead
            // 
            this.btnRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRead.Location = new System.Drawing.Point(589, 349);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(85, 23);
            this.btnRead.TabIndex = 49;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalibrate.Location = new System.Drawing.Point(589, 320);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(85, 23);
            this.btnCalibrate.TabIndex = 48;
            this.btnCalibrate.Text = "Calibrate";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // ckbStart
            // 
            this.ckbStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbStart.AutoSize = true;
            this.ckbStart.Location = new System.Drawing.Point(589, 298);
            this.ckbStart.Name = "ckbStart";
            this.ckbStart.Size = new System.Drawing.Size(48, 17);
            this.ckbStart.TabIndex = 47;
            this.ckbStart.Text = "Start";
            this.ckbStart.UseVisualStyleBackColor = true;
            this.ckbStart.CheckedChanged += new System.EventHandler(this.ckbStart_CheckedChanged);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(284, 388);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 13);
            this.label14.TabIndex = 46;
            this.label14.Text = "Kd:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(152, 388);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "Ki:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 388);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Kp:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(284, 357);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Kd:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(152, 357);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Ki:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 357);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Kp:";
            // 
            // btnPidPitch
            // 
            this.btnPidPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPidPitch.Location = new System.Drawing.Point(433, 383);
            this.btnPidPitch.Name = "btnPidPitch";
            this.btnPidPitch.Size = new System.Drawing.Size(75, 25);
            this.btnPidPitch.TabIndex = 40;
            this.btnPidPitch.Text = "Set Pitch";
            this.btnPidPitch.UseVisualStyleBackColor = true;
            this.btnPidPitch.Click += new System.EventHandler(this.btnPidPitch_Click);
            // 
            // btnPidYaw
            // 
            this.btnPidYaw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPidYaw.Location = new System.Drawing.Point(433, 350);
            this.btnPidYaw.Name = "btnPidYaw";
            this.btnPidYaw.Size = new System.Drawing.Size(75, 25);
            this.btnPidYaw.TabIndex = 39;
            this.btnPidYaw.Text = "Set Yaw";
            this.btnPidYaw.UseVisualStyleBackColor = true;
            this.btnPidYaw.Click += new System.EventHandler(this.btnPidYaw_Click);
            // 
            // tbxKdPitch
            // 
            this.tbxKdPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxKdPitch.Location = new System.Drawing.Point(310, 385);
            this.tbxKdPitch.Name = "tbxKdPitch";
            this.tbxKdPitch.Size = new System.Drawing.Size(100, 20);
            this.tbxKdPitch.TabIndex = 38;
            // 
            // tbxKiPitch
            // 
            this.tbxKiPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxKiPitch.Location = new System.Drawing.Point(174, 385);
            this.tbxKiPitch.Name = "tbxKiPitch";
            this.tbxKiPitch.Size = new System.Drawing.Size(100, 20);
            this.tbxKiPitch.TabIndex = 37;
            // 
            // tbxKpPitch
            // 
            this.tbxKpPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxKpPitch.Location = new System.Drawing.Point(32, 385);
            this.tbxKpPitch.Name = "tbxKpPitch";
            this.tbxKpPitch.Size = new System.Drawing.Size(101, 20);
            this.tbxKpPitch.TabIndex = 36;
            // 
            // tbxKdYaw
            // 
            this.tbxKdYaw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxKdYaw.Location = new System.Drawing.Point(310, 353);
            this.tbxKdYaw.Name = "tbxKdYaw";
            this.tbxKdYaw.Size = new System.Drawing.Size(100, 20);
            this.tbxKdYaw.TabIndex = 35;
            // 
            // tbxKiYaw
            // 
            this.tbxKiYaw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxKiYaw.Location = new System.Drawing.Point(174, 353);
            this.tbxKiYaw.Name = "tbxKiYaw";
            this.tbxKiYaw.Size = new System.Drawing.Size(100, 20);
            this.tbxKiYaw.TabIndex = 34;
            // 
            // tbxKpYaw
            // 
            this.tbxKpYaw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxKpYaw.Location = new System.Drawing.Point(32, 353);
            this.tbxKpYaw.Name = "tbxKpYaw";
            this.tbxKpYaw.Size = new System.Drawing.Size(101, 20);
            this.tbxKpYaw.TabIndex = 33;
            // 
            // cbxAutoScr
            // 
            this.cbxAutoScr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxAutoScr.AutoSize = true;
            this.cbxAutoScr.Location = new System.Drawing.Point(431, 302);
            this.cbxAutoScr.Name = "cbxAutoScr";
            this.cbxAutoScr.Size = new System.Drawing.Size(77, 17);
            this.cbxAutoScr.TabIndex = 2;
            this.cbxAutoScr.Text = "Auto Scroll";
            this.cbxAutoScr.UseVisualStyleBackColor = true;
            // 
            // gbxSensors
            // 
            this.gbxSensors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxSensors.Location = new System.Drawing.Point(553, 7);
            this.gbxSensors.Name = "gbxSensors";
            this.gbxSensors.Size = new System.Drawing.Size(412, 266);
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
            this.chart1.Location = new System.Drawing.Point(6, 7);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(540, 266);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.cbxAWB);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.cbxQuality);
            this.tabPage3.Controls.Add(this.cbxISO);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.cbxExposure);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1004, 431);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Camera Config";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(50, 156);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "White Balance:";
            // 
            // cbxAWB
            // 
            this.cbxAWB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAWB.FormattingEnabled = true;
            this.cbxAWB.Items.AddRange(new object[] {
            "Auto",
            "Sun",
            "Cloud",
            "Shade",
            "Tungsten",
            "Fluorescent",
            "Incandescent",
            "Flash",
            "Horizon"});
            this.cbxAWB.Location = new System.Drawing.Point(153, 153);
            this.cbxAWB.Margin = new System.Windows.Forms.Padding(2);
            this.cbxAWB.Name = "cbxAWB";
            this.cbxAWB.Size = new System.Drawing.Size(92, 21);
            this.cbxAWB.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Quality:";
            // 
            // cbxQuality
            // 
            this.cbxQuality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxQuality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuality.FormattingEnabled = true;
            this.cbxQuality.Items.AddRange(new object[] {
            "100",
            "90",
            "80",
            "70",
            "60",
            "50",
            "40"});
            this.cbxQuality.Location = new System.Drawing.Point(153, 47);
            this.cbxQuality.Margin = new System.Windows.Forms.Padding(2);
            this.cbxQuality.Name = "cbxQuality";
            this.cbxQuality.Size = new System.Drawing.Size(92, 21);
            this.cbxQuality.TabIndex = 5;
            // 
            // cbxISO
            // 
            this.cbxISO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxISO.FormattingEnabled = true;
            this.cbxISO.Items.AddRange(new object[] {
            "40",
            "60",
            "80",
            "100",
            "200",
            "500",
            "800"});
            this.cbxISO.Location = new System.Drawing.Point(153, 116);
            this.cbxISO.Margin = new System.Windows.Forms.Padding(2);
            this.cbxISO.Name = "cbxISO";
            this.cbxISO.Size = new System.Drawing.Size(92, 21);
            this.cbxISO.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 119);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "ISO:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Exposure Mode:";
            // 
            // cbxExposure
            // 
            this.cbxExposure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxExposure.FormattingEnabled = true;
            this.cbxExposure.Items.AddRange(new object[] {
            "Auto",
            "Night",
            "Backlight",
            "Spotlight",
            "Sports",
            "Snow",
            "Beach",
            "Antishake"});
            this.cbxExposure.Location = new System.Drawing.Point(153, 82);
            this.cbxExposure.Margin = new System.Windows.Forms.Padding(2);
            this.cbxExposure.Name = "cbxExposure";
            this.cbxExposure.Size = new System.Drawing.Size(92, 21);
            this.cbxExposure.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbxSetPosY);
            this.tabPage4.Controls.Add(this.btnSetPos);
            this.tabPage4.Controls.Add(this.tbxSetPosX);
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
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1004, 431);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Orentation";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tbxSetPosY
            // 
            this.tbxSetPosY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSetPosY.Location = new System.Drawing.Point(865, 25);
            this.tbxSetPosY.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSetPosY.Name = "tbxSetPosY";
            this.tbxSetPosY.Size = new System.Drawing.Size(64, 20);
            this.tbxSetPosY.TabIndex = 27;
            // 
            // btnSetPos
            // 
            this.btnSetPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetPos.Location = new System.Drawing.Point(590, 21);
            this.btnSetPos.Name = "btnSetPos";
            this.btnSetPos.Size = new System.Drawing.Size(133, 28);
            this.btnSetPos.TabIndex = 28;
            this.btnSetPos.Text = "Go To";
            this.btnSetPos.UseVisualStyleBackColor = true;
            this.btnSetPos.Click += new System.EventHandler(this.btnSetPos_Click);
            // 
            // tbxSetPosX
            // 
            this.tbxSetPosX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSetPosX.Location = new System.Drawing.Point(796, 25);
            this.tbxSetPosX.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSetPosX.Name = "tbxSetPosX";
            this.tbxSetPosX.Size = new System.Drawing.Size(61, 20);
            this.tbxSetPosX.TabIndex = 26;
            // 
            // lbxTargets
            // 
            this.lbxTargets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxTargets.FormattingEnabled = true;
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
            this.lbxTargets.Location = new System.Drawing.Point(479, 4);
            this.lbxTargets.Name = "lbxTargets";
            this.lbxTargets.Size = new System.Drawing.Size(119, 251);
            this.lbxTargets.TabIndex = 25;
            // 
            // btnYneg10
            // 
            this.btnYneg10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYneg10.Location = new System.Drawing.Point(737, 276);
            this.btnYneg10.Name = "btnYneg10";
            this.btnYneg10.Size = new System.Drawing.Size(35, 23);
            this.btnYneg10.TabIndex = 24;
            this.btnYneg10.Text = "-5";
            this.btnYneg10.UseVisualStyleBackColor = true;
            this.btnYneg10.Click += new System.EventHandler(this.btnYneg10_Click);
            // 
            // btnYpos10
            // 
            this.btnYpos10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYpos10.Location = new System.Drawing.Point(737, 159);
            this.btnYpos10.Name = "btnYpos10";
            this.btnYpos10.Size = new System.Drawing.Size(35, 23);
            this.btnYpos10.TabIndex = 23;
            this.btnYpos10.Text = "+5";
            this.btnYpos10.UseVisualStyleBackColor = true;
            this.btnYpos10.Click += new System.EventHandler(this.btnYpos10_Click);
            // 
            // btnXneg10
            // 
            this.btnXneg10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXneg10.Location = new System.Drawing.Point(657, 218);
            this.btnXneg10.Name = "btnXneg10";
            this.btnXneg10.Size = new System.Drawing.Size(35, 23);
            this.btnXneg10.TabIndex = 22;
            this.btnXneg10.Text = "-5";
            this.btnXneg10.UseVisualStyleBackColor = true;
            this.btnXneg10.Click += new System.EventHandler(this.btnXneg10_Click);
            // 
            // btnXpos10
            // 
            this.btnXpos10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXpos10.Location = new System.Drawing.Point(814, 218);
            this.btnXpos10.Name = "btnXpos10";
            this.btnXpos10.Size = new System.Drawing.Size(37, 23);
            this.btnXpos10.TabIndex = 21;
            this.btnXpos10.Text = "+5";
            this.btnXpos10.UseVisualStyleBackColor = true;
            this.btnXpos10.Click += new System.EventHandler(this.btnXpos10_Click);
            // 
            // tbTargetX
            // 
            this.tbTargetX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTargetX.Location = new System.Drawing.Point(479, 344);
            this.tbTargetX.Maximum = 45;
            this.tbTargetX.Minimum = -45;
            this.tbTargetX.Name = "tbTargetX";
            this.tbTargetX.Size = new System.Drawing.Size(442, 45);
            this.tbTargetX.TabIndex = 20;
            this.tbTargetX.Scroll += new System.EventHandler(this.tbCurrentX_Scroll);
            // 
            // tbTargetY
            // 
            this.tbTargetY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTargetY.Location = new System.Drawing.Point(894, 14);
            this.tbTargetY.Maximum = 45;
            this.tbTargetY.Minimum = -45;
            this.tbTargetY.Name = "tbTargetY";
            this.tbTargetY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbTargetY.Size = new System.Drawing.Size(45, 305);
            this.tbTargetY.TabIndex = 19;
            this.tbTargetY.Scroll += new System.EventHandler(this.tbCurrentY_Scroll);
            // 
            // btnXneg1
            // 
            this.btnXneg1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXneg1.Location = new System.Drawing.Point(698, 218);
            this.btnXneg1.Name = "btnXneg1";
            this.btnXneg1.Size = new System.Drawing.Size(35, 23);
            this.btnXneg1.TabIndex = 18;
            this.btnXneg1.Text = "-1";
            this.btnXneg1.UseVisualStyleBackColor = true;
            this.btnXneg1.Click += new System.EventHandler(this.btnXneg1_Click);
            // 
            // btnXpos1
            // 
            this.btnXpos1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXpos1.Location = new System.Drawing.Point(771, 218);
            this.btnXpos1.Name = "btnXpos1";
            this.btnXpos1.Size = new System.Drawing.Size(37, 23);
            this.btnXpos1.TabIndex = 17;
            this.btnXpos1.Text = "+1";
            this.btnXpos1.UseVisualStyleBackColor = true;
            this.btnXpos1.Click += new System.EventHandler(this.btnXpos1_Click);
            // 
            // btnYpos1
            // 
            this.btnYpos1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYpos1.Location = new System.Drawing.Point(737, 188);
            this.btnYpos1.Name = "btnYpos1";
            this.btnYpos1.Size = new System.Drawing.Size(35, 23);
            this.btnYpos1.TabIndex = 16;
            this.btnYpos1.Text = "+1";
            this.btnYpos1.UseVisualStyleBackColor = true;
            this.btnYpos1.Click += new System.EventHandler(this.btnYpos1_Click);
            // 
            // btnYneg1
            // 
            this.btnYneg1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYneg1.Location = new System.Drawing.Point(737, 247);
            this.btnYneg1.Name = "btnYneg1";
            this.btnYneg1.Size = new System.Drawing.Size(35, 23);
            this.btnYneg1.TabIndex = 15;
            this.btnYneg1.Text = "-1";
            this.btnYneg1.UseVisualStyleBackColor = true;
            this.btnYneg1.Click += new System.EventHandler(this.btnYneg1_Click);
            // 
            // btnHome
            // 
            this.btnHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHome.Location = new System.Drawing.Point(711, 78);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 23);
            this.btnHome.TabIndex = 14;
            this.btnHome.Text = "Home (0,0)";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnTarget4
            // 
            this.btnTarget4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTarget4.Location = new System.Drawing.Point(792, 50);
            this.btnTarget4.Name = "btnTarget4";
            this.btnTarget4.Size = new System.Drawing.Size(75, 23);
            this.btnTarget4.TabIndex = 13;
            this.btnTarget4.Text = "Target4";
            this.btnTarget4.UseVisualStyleBackColor = true;
            this.btnTarget4.Click += new System.EventHandler(this.btnTarget4_Click);
            // 
            // btnTarget3
            // 
            this.btnTarget3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTarget3.Location = new System.Drawing.Point(711, 50);
            this.btnTarget3.Name = "btnTarget3";
            this.btnTarget3.Size = new System.Drawing.Size(75, 23);
            this.btnTarget3.TabIndex = 12;
            this.btnTarget3.Text = "Target3";
            this.btnTarget3.UseVisualStyleBackColor = true;
            this.btnTarget3.Click += new System.EventHandler(this.btnTarget3_Click);
            // 
            // btnTarget2
            // 
            this.btnTarget2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTarget2.Location = new System.Drawing.Point(792, 20);
            this.btnTarget2.Name = "btnTarget2";
            this.btnTarget2.Size = new System.Drawing.Size(75, 23);
            this.btnTarget2.TabIndex = 11;
            this.btnTarget2.Text = "Target2";
            this.btnTarget2.UseVisualStyleBackColor = true;
            this.btnTarget2.Click += new System.EventHandler(this.btnTarget2_Click);
            // 
            // btnTarget1
            // 
            this.btnTarget1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTarget1.Location = new System.Drawing.Point(711, 20);
            this.btnTarget1.Name = "btnTarget1";
            this.btnTarget1.Size = new System.Drawing.Size(75, 23);
            this.btnTarget1.TabIndex = 10;
            this.btnTarget1.Text = "Target1";
            this.btnTarget1.UseVisualStyleBackColor = true;
            this.btnTarget1.Click += new System.EventHandler(this.btnTarget1_Click);
            // 
            // btnNextTarget
            // 
            this.btnNextTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextTarget.Location = new System.Drawing.Point(479, 279);
            this.btnNextTarget.Name = "btnNextTarget";
            this.btnNextTarget.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNextTarget.Size = new System.Drawing.Size(119, 23);
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
            this.tbCurrentY.Location = new System.Drawing.Point(873, 14);
            this.tbCurrentY.Maximum = 45;
            this.tbCurrentY.Minimum = -45;
            this.tbCurrentY.Name = "tbCurrentY";
            this.tbCurrentY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbCurrentY.Size = new System.Drawing.Size(45, 305);
            this.tbCurrentY.TabIndex = 4;
            // 
            // tbCurrentX
            // 
            this.tbCurrentX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCurrentX.Enabled = false;
            this.tbCurrentX.Location = new System.Drawing.Point(478, 324);
            this.tbCurrentX.Maximum = 45;
            this.tbCurrentX.Minimum = -45;
            this.tbCurrentX.Name = "tbCurrentX";
            this.tbCurrentX.Size = new System.Drawing.Size(442, 45);
            this.tbCurrentX.TabIndex = 3;
            // 
            // pbxLiveFeed
            // 
            this.pbxLiveFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxLiveFeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxLiveFeed.Location = new System.Drawing.Point(3, 3);
            this.pbxLiveFeed.Name = "pbxLiveFeed";
            this.pbxLiveFeed.Size = new System.Drawing.Size(469, 316);
            this.pbxLiveFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLiveFeed.TabIndex = 2;
            this.pbxLiveFeed.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 340);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Live feed";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnControlOff);
            this.tabPage5.Controls.Add(this.btnCyclePi);
            this.tabPage5.Controls.Add(this.cbxControl);
            this.tabPage5.Controls.Add(this.cbxPiStatus);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1004, 431);
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
            this.lblTargetRoll.Location = new System.Drawing.Point(639, 539);
            this.lblTargetRoll.Name = "lblTargetRoll";
            this.lblTargetRoll.Size = new System.Drawing.Size(62, 13);
            this.lblTargetRoll.TabIndex = 28;
            this.lblTargetRoll.Text = "Target Roll:";
            // 
            // lblTargetPitch
            // 
            this.lblTargetPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTargetPitch.AutoSize = true;
            this.lblTargetPitch.Location = new System.Drawing.Point(639, 526);
            this.lblTargetPitch.Name = "lblTargetPitch";
            this.lblTargetPitch.Size = new System.Drawing.Size(68, 13);
            this.lblTargetPitch.TabIndex = 27;
            this.lblTargetPitch.Text = "Target Pitch:";
            // 
            // lblCurrentYaw
            // 
            this.lblCurrentYaw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentYaw.AutoSize = true;
            this.lblCurrentYaw.Location = new System.Drawing.Point(741, 552);
            this.lblCurrentYaw.Name = "lblCurrentYaw";
            this.lblCurrentYaw.Size = new System.Drawing.Size(68, 13);
            this.lblCurrentYaw.TabIndex = 31;
            this.lblCurrentYaw.Text = "Current Yaw:";
            // 
            // lblCurrentPitch
            // 
            this.lblCurrentPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentPitch.AutoSize = true;
            this.lblCurrentPitch.Location = new System.Drawing.Point(741, 526);
            this.lblCurrentPitch.Name = "lblCurrentPitch";
            this.lblCurrentPitch.Size = new System.Drawing.Size(71, 13);
            this.lblCurrentPitch.TabIndex = 30;
            this.lblCurrentPitch.Text = "Current Pitch:";
            // 
            // lblCurrentRoll
            // 
            this.lblCurrentRoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentRoll.AutoSize = true;
            this.lblCurrentRoll.Location = new System.Drawing.Point(741, 539);
            this.lblCurrentRoll.Name = "lblCurrentRoll";
            this.lblCurrentRoll.Size = new System.Drawing.Size(65, 13);
            this.lblCurrentRoll.TabIndex = 29;
            this.lblCurrentRoll.Text = "Current Roll:";
            // 
            // lblBatVoltage
            // 
            this.lblBatVoltage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBatVoltage.AutoSize = true;
            this.lblBatVoltage.Location = new System.Drawing.Point(475, 526);
            this.lblBatVoltage.Name = "lblBatVoltage";
            this.lblBatVoltage.Size = new System.Drawing.Size(82, 13);
            this.lblBatVoltage.TabIndex = 32;
            this.lblBatVoltage.Text = "Battery Voltage:";
            // 
            // cbxPorts
            // 
            this.cbxPorts.FormattingEnabled = true;
            this.cbxPorts.Location = new System.Drawing.Point(16, 13);
            this.cbxPorts.Name = "cbxPorts";
            this.cbxPorts.Size = new System.Drawing.Size(146, 21);
            this.cbxPorts.TabIndex = 33;
            this.cbxPorts.TabStop = false;
            this.cbxPorts.DropDown += new System.EventHandler(this.comboBoxPorts_DropDown);
            // 
            // btnDSN
            // 
            this.btnDSN.Location = new System.Drawing.Point(169, 12);
            this.btnDSN.Name = "btnDSN";
            this.btnDSN.Size = new System.Drawing.Size(75, 23);
            this.btnDSN.TabIndex = 34;
            this.btnDSN.TabStop = false;
            this.btnDSN.Text = "Connect";
            this.btnDSN.UseVisualStyleBackColor = true;
            this.btnDSN.Click += new System.EventHandler(this.btnDSN_Click);
            // 
            // cbxUseDSN
            // 
            this.cbxUseDSN.AutoSize = true;
            this.cbxUseDSN.Location = new System.Drawing.Point(250, 14);
            this.cbxUseDSN.Margin = new System.Windows.Forms.Padding(2);
            this.cbxUseDSN.Name = "cbxUseDSN";
            this.cbxUseDSN.Size = new System.Drawing.Size(73, 17);
            this.cbxUseDSN.TabIndex = 35;
            this.cbxUseDSN.TabStop = false;
            this.cbxUseDSN.Text = "Use Dsn?";
            this.cbxUseDSN.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 592);
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
            this.Name = "Form1";
            this.Text = "Team 4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGamma)).EndInit();
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
        private System.Windows.Forms.Button btnCyclePi;
        private System.Windows.Forms.Button btnControlOff;
        private System.Windows.Forms.CheckBox cbxAutoScroll;
        private System.Windows.Forms.CheckBox cbxControl;
        private System.Windows.Forms.CheckBox cbxPiStatus;
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
        private System.Windows.Forms.TextBox tbxSetPosX;
        private System.IO.Ports.SerialPort spTransmit;
        private System.Windows.Forms.ComboBox cbxPorts;
        private System.Windows.Forms.Button btnDSN;
        private System.Windows.Forms.CheckBox cbxUseDSN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxSetPosY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblGamma;
        private System.Windows.Forms.TrackBar tbGamma;
        private System.Windows.Forms.TextBox tbxKdPitch;
        private System.Windows.Forms.TextBox tbxKiPitch;
        private System.Windows.Forms.TextBox tbxKpPitch;
        private System.Windows.Forms.TextBox tbxKdYaw;
        private System.Windows.Forms.TextBox tbxKiYaw;
        private System.Windows.Forms.TextBox tbxKpYaw;
        private System.Windows.Forms.Button btnPidPitch;
        private System.Windows.Forms.Button btnPidYaw;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ckbStart;
        private System.Windows.Forms.Button btnCalMag;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnCalibrate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbxAWB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxQuality;
        private System.Windows.Forms.ComboBox cbxISO;
        private System.Windows.Forms.ComboBox cbxExposure;
    }
}

