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

using SlimDX;

using SlimDX.D3DCompiler;

using SlimDX.Direct3D11;

using SlimDX.DXGI;

using SlimDX.Windows;

using Device = SlimDX.Direct3D11.Device;

using Resource = SlimDX.Direct3D11.Resource;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace BaseStation
{

 
    public partial class Form1 : Form
    {
        //  MqttClient client;


        public struct Sensor
        {
            public CheckBox enabled;
            public TextBox scale;
            public Queue<PointF> data;
            public Label topic;

        }
        private LinkedList<Sensor> sensors = new LinkedList<Sensor>();


        public Form1()
        {

            InitializeComponent();

            chart1.Series.Clear();

            chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chart1.ChartAreas[0].AxisY2.Title = "Temp";
            chart1.ChartAreas[0].AxisY2.Maximum = 100;

            string[] drives = Environment.GetLogicalDrives();


            TreeNode node = new TreeNode("pic");
            node.Tag = Environment.CurrentDirectory + "\\pic";
            node.Nodes.Add("...");

            tvPhotos.Nodes.Add(node);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text.Equals("Disconnect"))
            {
                btnConnect.Text = "Connect";
            //    client.Disconnect();
            } else 
            {
                btnConnect.Text = "Disconnect";
                // btnConnect.Enabled = false;
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

            }


        delegate void SetTextCallback(string text);
        delegate void addControlCallback(Control obj);

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

        private void addControl(Control obj)
        {
            if (this.InvokeRequired)
            {
                addControlCallback d = new addControlCallback(addControl);
                this.Invoke(d, new object[] { obj });
            }
            else
            {

                obj.Parent = this.gbxSensors;
            }
        }


        private void tvPhotos_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    //get the list of sub direcotires
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    //add files of rootdirectory
                    DirectoryInfo rootDir = new DirectoryInfo(e.Node.Tag.ToString());
                    foreach (var file in rootDir.GetFiles())
                    {
                        TreeNode n = new TreeNode(file.Name, 13, 13);
                        e.Node.Nodes.Add(n);
                    }

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 0, 1);

                        try
                        {
                            //keep the directory's full path in the tag for use later
                            node.Tag = dir;

                            //if the directory has sub directories add the place holder
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);

                            foreach (var file in di.GetFiles())
                            {
                                TreeNode n = new TreeNode(file.Name, 13, 13);
                                node.Nodes.Add(n);
                            }

                        }
                        catch (UnauthorizedAccessException)
                        {
                            //display a locked folder icon
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }



        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {

            string topicGraph = "/graph";
            if (e.Topic.StartsWith("/pic"))
            {
                string name = e.Topic;
                string message = System.Text.Encoding.UTF8.GetString(e.Message);



                SetText(e.Topic + Environment.NewLine);
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(e.Message));
                //  tvPhotos.Nodes.Add(name);

                name = name.Replace('/','\\').Substring(1);

                System.IO.Directory.CreateDirectory(name);
                name += "\\pic1.jpg";


                x.Save(name, ImageFormat.Jpeg);

                imageControl1.Image = x;// ResizeImage(x, pictureBox1.Width, pictureBox1.Height);
               
            }
            else if(e.Topic.StartsWith(topicGraph))
            {
               
                string name = e.Topic.Substring(topicGraph.Length+1); //"/" char
                string message = System.Text.Encoding.UTF8.GetString(e.Message);
                
                var parts = message.Split(',');

                if (parts.Length < 2) return;

                float a = Convert.ToSingle(parts[0]);
                float b = Convert.ToSingle(parts[1]);

                foreach (Sensor sensor in sensors) {
                    if (name.Equals(sensor.topic.Text))
                    {
                        sensor.data.Enqueue(new PointF(a,b));
                        if (sensor.data.Count > 100)
                        {
                         sensor.data.Dequeue();
                        }
                        return; //exit function if found
                    }
                }

                Sensor newSensor;

                timer1.Enabled = true;

                newSensor.data = new Queue<PointF>();
                newSensor.data.Enqueue(new PointF(a, b));

                newSensor.enabled = new CheckBox();
                newSensor.scale = new TextBox();
                newSensor.topic = new Label();



              //  newSensor.enabled.Parent = gbxSensors;


                newSensor.topic.Location = new Point(10,(10 + 50 * sensors.Count));
                newSensor.scale.Location = new Point(150,( 30 +50 * sensors.Count));
                newSensor.enabled.Location = new Point(20,(30 + 50 * sensors.Count));

                newSensor.scale.Text = "1";
  

                newSensor.enabled.Checked = true;
                newSensor.enabled.Text = "Enable";
                newSensor.topic.Text = name;

                addControl(newSensor.enabled);
                addControl(newSensor.scale);
                addControl(newSensor.topic);
                //           this.Controls.Add(newSensor.enabled);
                //           this.Controls.Add(newSensor.scale);
               
                sensors.AddLast(newSensor);



                //only get's here if nothing found



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

   
        Random rnd = new Random(3);
        int indexxxxxx = 0;

        private void button3_Click(object sender, EventArgs e)
        {
          
            string payload = "";
            payload += indexxxxxx++;
            payload += ",";

            sendMessage("/graph/3", payload += rnd.Next(20));
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            string payload = "";
            payload += indexxxxxx++;
            payload += ",";
            sendMessage("/graph/2", payload += rnd.Next(20));
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            string payload ="";
            payload  += indexxxxxx++;
            payload +=  ",";
     
            sendMessage("/graph/1", payload += rnd.Next(20));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cbxAutoScr.Checked)
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Position = chart1.ChartAreas[0].AxisX.Maximum - 15;
                chart1.ChartAreas[0].AxisX.ScaleView.Size = 20;// .Chart1.Series(0)
            }
            for (int i = 0; i < sensors.Count; i++)
            {
                if (i < chart1.Series.Count)
                { //it existes
                    chart1.Series[i].Enabled = sensors.ElementAt(i).enabled.Checked;
                    while (sensors.ElementAt(i).data.Count > 0)
                    { 
                    PointF point = sensors.ElementAt(i).data.Dequeue();
                    chart1.Series[i].Points.AddXY(point.X , point.Y * double.Parse(sensors.ElementAt(i).scale.Text));
              
                 }
 
                }
                else
                {
                    chart1.Series.Add(sensors.ElementAt(i).topic.Text);
                    chart1.Series[sensors.ElementAt(i).topic.Text].ChartType = SeriesChartType.Line;
                }

            }
        }

    }
}
