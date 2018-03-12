using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            // create client instance 
            MqttClient client = new MqttClient(IPAddress.Parse(tbxAddress.Text));

            // register to message received 
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

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
            SetText(e.Topic + " ");
            SetText(Encoding.UTF8.GetString(e.Message,0, e.Message.Length) + Environment.NewLine);


            // handle message received 
        }


        private void button2_Click(object sender, EventArgs e)
        {

            // create client instance 
            MqttClient client = new MqttClient(IPAddress.Parse(tbxAddress.Text));

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            string strValue = Convert.ToString(tbxMessage.Text);

            // publish a message on "/home/temperature" topic with QoS 2 
            client.Publish(tbxTopic.Text, Encoding.UTF8.GetBytes(strValue), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);


        }


    }
}
