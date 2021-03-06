﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace DSN_Transmitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
                if (comboBoxPorts.SelectedIndex > -1)
                {
                    MessageBox.Show(String.Format("You selected port '{0}'", comboBoxPorts.SelectedItem));
                    Connect(comboBoxPorts.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("Please select a port first");
                }

        }


        private void Connect(string portName)
        {
            //    var port = new SerialPort(portName);
            var port = spRecieve;
            if (!port.IsOpen)
            {
                port.PortName = portName;
                port.BaudRate = 1200;
                port.Open();
                btnopenComport.Text = "Disconnect";
            } else
            {
                port.Close();
                btnopenComport.Text = "Connect";
            }
        }

        //  client;
        MqttClient client;
        private void btnOpenMQTT_Click(object sender, EventArgs e)
        {
            if (btnOpenMQTT.Text.Equals("Disconnect"))
            {
                btnOpenMQTT.Text = "Subscribe";
                client.Disconnect();
            }
            else
            {
                btnOpenMQTT.Text = "Disconnect";
                // btnConnect.Enabled = false;
                // create client instance 
                client = new MqttClient(IPAddress.Parse(tbxAddress.Text));

                string clientId = "DSNtransmit";
                try
                {
                    client.Connect(clientId);
                }
                catch
                {
                    MessageBox.Show("could not connect.");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxPorts.DataSource = SerialPort.GetPortNames();
        }

        private void comboBoxPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPorts_DropDown(object sender, EventArgs e)
        {
            comboBoxPorts.DataSource = SerialPort.GetPortNames();
        }

        
        private void spRecieve_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String Buffer = spRecieve.ReadLine();
        

            int seperatorPos = Buffer.IndexOf(':');

            string topic = Buffer.Substring(0,seperatorPos);
            string payload = Buffer.Substring(seperatorPos+1); /// ignore the seperator

            appendText(rtbLog, topic + "---" + payload + Environment.NewLine);
  
            // publish a message on "topic" topic with QoS 2 
            if (client.IsConnected)
            {
                client.Publish(topic, Encoding.UTF8.GetBytes(payload), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            }
            else
            {
                MessageBox.Show("Not connected to MQTT.");
            }
        }



        delegate void setTextCallback(object obj, string text);
        delegate void appendTextCallback(object obj, string text);


        private void appendText(object obj, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.rtbLog.InvokeRequired)
            {
                appendTextCallback d = new appendTextCallback(appendText);
                this.Invoke(d, new object[] { obj, text });
            }
            else
            {

                if (obj is RichTextBox richTextBox)
                {
                    richTextBox.AppendText(text);
                }
                else if (obj is TextBox textBox)
                {
                    textBox.Text = "I am not rich";
                }

            }
        }

        private void setText(object obj, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.rtbLog.InvokeRequired)
            {
                setTextCallback d = new setTextCallback(setText);
                this.Invoke(d, new object[] { obj, text });
            }
            else
            {

                if (obj is RichTextBox richTextBox)
                {
                    richTextBox.Clear();
                    richTextBox.AppendText(text);
                }
                else if (obj is TextBox textBox)
                {
                    textBox.Text = text;
                }
                else if (obj is Label label)
                {
                    label.Text = text;
                }

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client.IsConnected)
            {
                client.Disconnect();
            }

            if (spRecieve.IsOpen)
            {
                spRecieve.Close();
            }
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
           // if (cbxAutoScroll.Checked)
            {
                rtbLog.ScrollToCaret();
            }
        }
    }
}
