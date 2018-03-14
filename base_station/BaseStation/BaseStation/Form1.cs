using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace BaseStation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                //btnConnect.Text = "Disconnect";
                btnConnect.Enabled = false;
                // create client instance 
                MqttClient client = new MqttClient(IPAddress.Parse(tbxAddress.Text));

                // register to message received 
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

                string clientId = Guid.NewGuid().ToString();
            try
            {
                client.Connect(clientId);
            }
            catch
            {


            }

                // subscribe to the topic "/home/temperature" with QoS 2 
            client.Subscribe(new string[] { "#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            }


        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.rtbSubscribe.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.rtbSubscribe.AppendText(text);
            }
        }

        

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
          
            if (e.Topic.StartsWith("/pic"))
            {
                SetText(e.Topic + Environment.NewLine);
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(e.Message));
                imageControl1.Image = x;// ResizeImage(x, pictureBox1.Width, pictureBox1.Height);
               
            } else
            {
                SetText(e.Topic + " ");
                SetText(Encoding.UTF8.GetString(e.Message, 0, e.Message.Length) + Environment.NewLine);
            }


            // handle message received 
        }


        private void sendMessage(string topic,string payload)
        {
            // create client instance 
            MqttClient client = new MqttClient(IPAddress.Parse(tbxAddress.Text));

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);


            // publish a message on "/home/temperature" topic with QoS 2 
            client.Publish(topic, Encoding.UTF8.GetBytes(payload), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

        }


        private void button2_Click(object sender, EventArgs e)
        {
            sendMessage(tbxTopic.Text,Convert.ToString(tbxMessage.Text));
        }

        private void btnLedOn_Click(object sender, EventArgs e)
        {
            sendMessage("/arduino/led1","H");
        }

        private void btnLedOff_Click(object sender, EventArgs e)
        {
            sendMessage("/arduino/led1","L");
        }

        private void rtbSubscribe_TextChanged(object sender, EventArgs e)
        {
            if (cbxAutoScroll.Checked)
            {
                rtbSubscribe.ScrollToCaret();
            }
        }

        private void rgb1_payload(object sender, EventArgs e)
        {
            string payload = cbxRGB1R.Checked ? "H" : "L";
            payload += cbxRGB1G.Checked ? "H" : "L";
            payload += cbxRGB1B.Checked ? "H" : "L";

            sendMessage("/arduino/rgb1", payload);
        }


        private void rgb2_payload(object sender, EventArgs e)
        {
            string payload = cbxRGB2R.Checked ? "H" : "L";
            payload += cbxRGB2G.Checked ? "H" : "L";
            payload += cbxRGB2B.Checked ? "H" : "L";
            sendMessage("/arduino/rgb2", payload);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbSubscribe.Clear();
        }

        private void btnTakePhoto_Click(object sender, EventArgs e)
        {
            sendMessage("/camera/takePhoto", "1");
        }

        private void imageControl1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            sendMessage("/webserver/disable", "1");
        }

        private void btnWebservice_Click(object sender, EventArgs e)
        {
            sendMessage("/webserver/enable", "1");
        }
    }
}
