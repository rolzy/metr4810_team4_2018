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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTakePhoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(333, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(246, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbxMessage
            // 
            this.tbxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMessage.Location = new System.Drawing.Point(12, 333);
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.Size = new System.Drawing.Size(228, 20);
            this.tbxMessage.TabIndex = 7;
            // 
            // rtbSubscribe
            // 
            this.rtbSubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbSubscribe.Location = new System.Drawing.Point(12, 39);
            this.rtbSubscribe.Name = "rtbSubscribe";
            this.rtbSubscribe.Size = new System.Drawing.Size(305, 236);
            this.rtbSubscribe.TabIndex = 3;
            this.rtbSubscribe.TabStop = false;
            this.rtbSubscribe.Text = "";
            this.rtbSubscribe.TextChanged += new System.EventHandler(this.rtbSubscribe_TextChanged);
            // 
            // tbxAddress
            // 
            this.tbxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAddress.Location = new System.Drawing.Point(12, 12);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(315, 20);
            this.tbxAddress.TabIndex = 1;
            this.tbxAddress.Text = "192.168.20.151";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Message";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Topic";
            // 
            // tbxTopic
            // 
            this.tbxTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTopic.Location = new System.Drawing.Point(12, 294);
            this.tbxTopic.Name = "tbxTopic";
            this.tbxTopic.Size = new System.Drawing.Size(305, 20);
            this.tbxTopic.TabIndex = 6;
            // 
            // btnLedOn
            // 
            this.btnLedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLedOn.Location = new System.Drawing.Point(446, 331);
            this.btnLedOn.Name = "btnLedOn";
            this.btnLedOn.Size = new System.Drawing.Size(75, 23);
            this.btnLedOn.TabIndex = 9;
            this.btnLedOn.Text = "Led On";
            this.btnLedOn.UseVisualStyleBackColor = true;
            this.btnLedOn.Click += new System.EventHandler(this.btnLedOn_Click);
            // 
            // btnLedOff
            // 
            this.btnLedOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLedOff.Location = new System.Drawing.Point(446, 302);
            this.btnLedOff.Name = "btnLedOff";
            this.btnLedOff.Size = new System.Drawing.Size(75, 23);
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
            this.cbxAutoScroll.Location = new System.Drawing.Point(439, 14);
            this.cbxAutoScroll.Name = "cbxAutoScroll";
            this.cbxAutoScroll.Size = new System.Drawing.Size(75, 17);
            this.cbxAutoScroll.TabIndex = 10;
            this.cbxAutoScroll.TabStop = false;
            this.cbxAutoScroll.Text = "Auto scroll";
            this.cbxAutoScroll.UseVisualStyleBackColor = true;
            // 
            // cbxRGB1R
            // 
            this.cbxRGB1R.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRGB1R.AutoSize = true;
            this.cbxRGB1R.Location = new System.Drawing.Point(366, 303);
            this.cbxRGB1R.Name = "cbxRGB1R";
            this.cbxRGB1R.Size = new System.Drawing.Size(34, 17);
            this.cbxRGB1R.TabIndex = 11;
            this.cbxRGB1R.Text = "R";
            this.cbxRGB1R.UseVisualStyleBackColor = true;
            this.cbxRGB1R.CheckedChanged += new System.EventHandler(this.rgb1_payload);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "RGB 1";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "RGB 2";
            // 
            // cbxRGB1B
            // 
            this.cbxRGB1B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRGB1B.AutoSize = true;
            this.cbxRGB1B.Location = new System.Drawing.Point(367, 340);
            this.cbxRGB1B.Name = "cbxRGB1B";
            this.cbxRGB1B.Size = new System.Drawing.Size(33, 17);
            this.cbxRGB1B.TabIndex = 14;
            this.cbxRGB1B.Text = "B";
            this.cbxRGB1B.UseVisualStyleBackColor = true;
            this.cbxRGB1B.CheckedChanged += new System.EventHandler(this.rgb1_payload);
            // 
            // cbxRGB1G
            // 
            this.cbxRGB1G.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRGB1G.AutoSize = true;
            this.cbxRGB1G.Location = new System.Drawing.Point(366, 321);
            this.cbxRGB1G.Name = "cbxRGB1G";
            this.cbxRGB1G.Size = new System.Drawing.Size(34, 17);
            this.cbxRGB1G.TabIndex = 15;
            this.cbxRGB1G.Text = "G";
            this.cbxRGB1G.UseVisualStyleBackColor = true;
            this.cbxRGB1G.CheckedChanged += new System.EventHandler(this.rgb1_payload);
            // 
            // cbxRGB2G
            // 
            this.cbxRGB2G.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRGB2G.AutoSize = true;
            this.cbxRGB2G.Location = new System.Drawing.Point(406, 321);
            this.cbxRGB2G.Name = "cbxRGB2G";
            this.cbxRGB2G.Size = new System.Drawing.Size(34, 17);
            this.cbxRGB2G.TabIndex = 18;
            this.cbxRGB2G.Text = "G";
            this.cbxRGB2G.UseVisualStyleBackColor = true;
            this.cbxRGB2G.CheckedChanged += new System.EventHandler(this.rgb2_payload);
            // 
            // cbxRGB2B
            // 
            this.cbxRGB2B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRGB2B.AutoSize = true;
            this.cbxRGB2B.Location = new System.Drawing.Point(406, 340);
            this.cbxRGB2B.Name = "cbxRGB2B";
            this.cbxRGB2B.Size = new System.Drawing.Size(33, 17);
            this.cbxRGB2B.TabIndex = 17;
            this.cbxRGB2B.Text = "B";
            this.cbxRGB2B.UseVisualStyleBackColor = true;
            this.cbxRGB2B.CheckedChanged += new System.EventHandler(this.rgb2_payload);
            // 
            // cbxRGB2R
            // 
            this.cbxRGB2R.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRGB2R.AutoSize = true;
            this.cbxRGB2R.Location = new System.Drawing.Point(405, 303);
            this.cbxRGB2R.Name = "cbxRGB2R";
            this.cbxRGB2R.Size = new System.Drawing.Size(34, 17);
            this.cbxRGB2R.TabIndex = 16;
            this.cbxRGB2R.Text = "R";
            this.cbxRGB2R.UseVisualStyleBackColor = true;
            this.cbxRGB2R.CheckedChanged += new System.EventHandler(this.rgb2_payload);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(521, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(324, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 236);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // btnTakePhoto
            // 
            this.btnTakePhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTakePhoto.Location = new System.Drawing.Point(527, 302);
            this.btnTakePhoto.Name = "btnTakePhoto";
            this.btnTakePhoto.Size = new System.Drawing.Size(75, 51);
            this.btnTakePhoto.TabIndex = 21;
            this.btnTakePhoto.Text = "Cheese";
            this.btnTakePhoto.UseVisualStyleBackColor = true;
            this.btnTakePhoto.Click += new System.EventHandler(this.btnTakePhoto_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 372);
            this.Controls.Add(this.btnTakePhoto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cbxRGB2G);
            this.Controls.Add(this.cbxRGB2B);
            this.Controls.Add(this.cbxRGB2R);
            this.Controls.Add(this.cbxRGB1G);
            this.Controls.Add(this.cbxRGB1B);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxRGB1R);
            this.Controls.Add(this.cbxAutoScroll);
            this.Controls.Add(this.btnLedOff);
            this.Controls.Add(this.btnLedOn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxTopic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxAddress);
            this.Controls.Add(this.rtbSubscribe);
            this.Controls.Add(this.tbxMessage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Base Station";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnTakePhoto;
    }
}

