﻿using System;
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

using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Ports;

using Emgu;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Util;
using Emgu.CV.Structure;

namespace BaseStation
{

 
    public partial class Form1 : Form
    {
        public struct Sensor
        {
            // initialise the attributes of the sensor struct
            public CheckBox enabled;        
            public TextBox scale;
            public Queue<PointF> data;
            public Label topic;

        }
        // initialise a private list to contain sensor readings for graphing
        private LinkedList<Sensor> sensors = new LinkedList<Sensor>();

        public Form1()
        {
            InitializeComponent();

            // clear the chart at initialisation
            chart1.Series.Clear();

            // initialise chart characteristics
            chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True; 
            chart1.ChartAreas[0].AxisY2.Title = "Temp";             
            chart1.ChartAreas[0].AxisY2.Maximum = 100;              

            // Set up drives for picture saving
            string[] drives = Environment.GetLogicalDrives();

            // nodes for visualisation of pictures relative to the pictures coordinates
            TreeNode node = new TreeNode("pic");
            node.Name = "pic\\";
            node.Tag = Environment.CurrentDirectory + "\\pic";
            node.Nodes.Add("...");

            tvPhotos.Nodes.Add(node);

            // Gamma values for image processing
            tbGamma.Minimum = 5;
            tbGamma.Maximum = 50;

            // Set initial values for camera configuration parameters
            cbxQuality.SelectedIndex = 0;
            cbxExposure.SelectedIndex = 0;
            cbxISO.SelectedIndex = 6;
            cbxAWB.SelectedIndex = 0;
        }

        // variables to store image to be displayed and set initial gamma value for binarization
        Mat imgShow;
        double _gamma = 0.5d;

        // create an Mqtt client
        MqttClient client;

        private void button1_Click(object sender, EventArgs e)
        {
            // Button for subscribing and disconnecting from the pi. Button will initially read 
            // subscribe and once clicked will attempt to connect the GUI to the specified IP 
            // address. Once clicked, the text will change to 'Disconnect' and if clicked while
            // subscribed, it will terminate the connection.

            // if button has just been clicked, disable it until specified
            btnConnect.Enabled = false;

            if (btnConnect.Text.Equals("Disconnect"))
            {
                btnConnect.Text = "Subscribe";
                if(client!= null && client.IsConnected)
                {
                    // attempt the action however if the disconnection fails, catch the error 
                    // without terminating the app.
                    try
                    {
                        client.Disconnect();
                    } 
                    catch
                    {

                    }
                    
                }
               
            } else 
            {
                // case for which a new subscription is to be made

                // create client instance 
                client = new MqttClient(IPAddress.Parse(tbxAddress.Text));

                // register to message received 
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

                string clientId = "BaseStation";

                try
                {
                    client.Connect(clientId);
                    btnConnect.Text = "Disconnect";
                }
                catch
                {
                    MessageBox.Show("Could not connect to Server");
                }

                // subscribe to the topic "/home/temperature" with QoS 2 
                client.Subscribe(new string[] { "#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            }
            btnConnect.Enabled = true;
        }

        // Used for interthread communications
        delegate void setTextCallback(object obj, string text);
        delegate void setTrackBarCallback(object obj, int text);
        delegate void appendTextCallback(object obj, string text);
        delegate void setcheckboxCallback(object obj, bool value);
        delegate void addControlCallback(Control obj);
        delegate void AddnodeTreeviewCallback(string name);

        private void setcheckbox(object obj, bool value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                setcheckboxCallback d = new setcheckboxCallback(setcheckbox);
                this.Invoke(d, new object[] { obj, value });
            }
            else
            {

                if (obj is CheckBox cbx)
                {
                    cbx.Checked = value;
                }
            }
        }


        private void appendText(object obj ,string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.rtbSubscribe.InvokeRequired)
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

        private void setTrackbar(object obj, int value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.tbCurrentY.InvokeRequired)
            {
                setTrackBarCallback d = new setTrackBarCallback(setTrackbar);
                this.Invoke(d, new object[] { obj, value });
            }
            else
            {

                if (obj is TrackBar trackBar)
                {
                    value = Math.Min(value, trackBar.Maximum);
                    value = Math.Max(value, trackBar.Minimum);

                    trackBar.Value= value;
                }

            }
        }

        private void setText(object obj, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.rtbSubscribe.InvokeRequired)
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


        private void addControl(Control obj)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
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


        private static void PopulateTreeView(TreeView treeView, string path, char pathSeparator)
        {
            // Builds tree for the fille display.
            TreeNode lastNode = null;
            string subPathAgg;
            
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            lastNode = treeView.Nodes.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
                lastNode = null; // This is the place code was changed
        }

        private void AddnodeTreeview(string name)
        {
            // function for adding a node to the file tree
            if (this.InvokeRequired)
            {
                AddnodeTreeviewCallback d = new AddnodeTreeviewCallback(AddnodeTreeview);
                this.Invoke(d, new object[] { name });
            }
            else
            {
                PopulateTreeView(tvPhotos, name, '\\');
            }
        }


        private void tvPhotos_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    // get the list of sub directories
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    // add files of rootdirectory
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
                        node.Name = e.Node.Name  + di.Name + e.Node.TreeView.PathSeparator;
                        try
                        {
                            // keep the directory's full path in the tag for use later
                            node.Tag = dir;

                            // if the directory has sub directories add the place holder
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


        string IndexedFilename(string stub, string extension)
        {
            // Creates the next empty filename (in a numeric format).
            int ix = 0;
            string filename = null;
            do
            {
                ix++;
                filename = String.Format("{0}{1}.{2}", stub, ix, extension);
            } while (File.Exists(filename));
            return filename;
        }

        private void tvPhotos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // double clicking on any of the tree nodes will either open the relevant folder or
            // in the case the file double clicked is an image, will process and display the image
            TreeView view = (TreeView)sender;
            if (view.SelectedNode.Nodes.Count == 0)
            { 
                FileStream stream = new FileStream(view.SelectedNode.FullPath, FileMode.Open, FileAccess.Read);
                Bitmap bmpShow = new Bitmap(Image.FromStream(stream));
                Image<Bgr, byte> imageShow = new Image<Bgr, byte>(bmpShow);
                imgShow = imageShow.Mat;
                ProcessFrame();     // Process frame funcion
            }
        }

        public void ProcessFrame()
        {
            // function for processing the image before display in the GUI
            if (imgShow != null)
            {
                Point _Origin = imageControl1.Origin;

                Image<Gray, byte> result = imgShow.ToImage<Gray,byte>();
                result._GammaCorrect(_gamma);   // use gamma correct do darken the image

                imageControl1.Image = result.Bitmap;

                imageControl1.Origin = _Origin;
                lblGamma.Text = _gamma.ToString();  // display gamma value in the GUI
            }
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // Proccesses all messages recieved by the MQTT server
            string topicGraph = "/graph";
            string topicStatus = "/status";
            string topicLastWill = "/lastWill";

            if (e.Topic.StartsWith("/pic"))
            {
                string name = e.Topic;
                string message = System.Text.Encoding.UTF8.GetString(e.Message);

                appendText(rtbSubscribe, e.Topic + Environment.NewLine);
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(e.Message));

                name = name.Replace('/','\\').Substring(1);
                name += "\\"+(int)targetPos.X + " " + (int)targetPos.Y;
                System.IO.Directory.CreateDirectory(name);

                name = IndexedFilename(Path.Combine(name, "pic_"), "jpg");
                x.Save(name, ImageFormat.Jpeg);
                AddnodeTreeview(name);

                imageControl1.Image = x;
                imageControl1.ZoomFactor = (float)imageControl1.Height / x.Height;
            }
            else if(e.Topic.StartsWith(topicGraph))
            {
               
                string name = e.Topic.Substring(topicGraph.Length+1); 
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

                sensors.AddLast(newSensor);

                //only get's here if nothing found
            }
            else if (e.Topic.StartsWith(topicStatus) || e.Topic.StartsWith(topicLastWill))
            {

                string name = e.Topic.Substring(topicStatus.Length + 1); //"/" char
                string message = System.Text.Encoding.UTF8.GetString(e.Message);

                switch (name)
                {
                    case "batV":
                        setText(lblBatVoltage, name + ": " + message);
                        break;
                    case "conS":
                        setText(rtbSubscribe, name + ": " + message);
                        if (message == "1")
                        {
                            setcheckbox(cbxControl, true);

                        } else if(message == "0" )
                        {
                            setcheckbox( cbxControl,false);
                        }

                        break;
                    case "pis":
                        setText(rtbSubscribe, name + ": " + message);
                        if (message == "1")
                        {
                            setcheckbox (cbxPiStatus.Checked , true);

                        }
                        else if (message == "0")
                        {
                            setcheckbox( cbxPiStatus.Checked , false);
                        }
                        break;
                    case "Pos":
                        var split = message.Split(':');
                        if (split.Length >= 2)
                        {
                            
                            setText(lblCurrentPitch, "Current Pitch: " + split[0]);
                            setText(lblCurrentRoll, "Current Roll: " + split[1]);
                            try
                            {
                                setTrackbar(tbCurrentX, int.Parse(split[0]));
                                setTrackbar(tbCurrentY, int.Parse(split[1]));
                            }
                            catch
                            {

                            }
                        }
                        if (split.Length == 3)
                        {
                              setText(lblCurrentYaw, "Current Yaw: " + split[2]);
                        }
                            break;

                    default:
                        appendText(rtbSubscribe, e.Topic + " ");
                        appendText(rtbSubscribe, Encoding.UTF8.GetString(e.Message, 0, e.Message.Length) + Environment.NewLine);
                        break;
                }
            }
            else
            {
                appendText(rtbSubscribe, e.Topic + " ");
                appendText(rtbSubscribe, Encoding.UTF8.GetString(e.Message, 0, e.Message.Length) + Environment.NewLine);
            }
            // handle message received 
        }


        private void sendMessage(string topic, string payload)
        {
            // create client instance 
            // publish a message on "/home/temperature" topic with QoS 2 

            if (!cbxUseDSN.Checked) {
                if (client != null && client.IsConnected)
                {
                    client.Publish(topic, Encoding.UTF8.GetBytes(payload), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                }
                else
                {
                    MessageBox.Show("Connect to DSN");
                    cbxPorts.DataSource = SerialPort.GetPortNames();
                }

            } else { 
            if (spTransmit.IsOpen)
            {
                spTransmit.Write(topic + ':' + payload + '\n');
            }
            else
            {
                MessageBox.Show("Connect to DSN");
                cbxPorts.DataSource = SerialPort.GetPortNames();
            }
        }

    }
        private void btnDSN_Click(object sender, EventArgs e)
        {
            // checkbox for simulating DSN
            if (cbxPorts.SelectedIndex > -1)
            {
               var port = spTransmit;
                if (!port.IsOpen)
                {
                    port.PortName = cbxPorts.SelectedItem.ToString();
                    port.BaudRate = 1200;
                    port.Open();
                    btnDSN.Text = "Disconnect";
                }
                else
                {
                    port.Close();
                    btnDSN.Text = "Connect";
                }
            }
            else
            {
                MessageBox.Show("Please select a port first");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            sendMessage(tbxTopic.Text,Convert.ToString(tbxMessage.Text));
        }

        private void btnLedOn_Click(object sender, EventArgs e)
        {
            // switch LEDs on
            sendMessage("/powersys/pic", "1");
        }

        private void btnLedOff_Click(object sender, EventArgs e)
        {
            // Switch LEDs off
            sendMessage("/powersys/conc", "1");
        }

        private void rtbSubscribe_TextChanged(object sender, EventArgs e)
        { 
            // enables autoscroll
            if (cbxAutoScroll.Checked)
            {
                rtbSubscribe.ScrollToCaret();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            // clear the MQTT log
            if (MessageBox.Show("Are you sure you want to clear the MQTT log", "Clear Log?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                rtbSubscribe.Clear();
            }
        }
        private void btnTakePhoto_Click(object sender, EventArgs e)
        {
            // Capture Image

            // Disable the live stream
            sendMessage("/webserver/disable", "1");
            Thread.Sleep(500);      // sufficient delay so that the live stream may be disabled

            // arguments for image acquisition
            string args = "-q " + cbxQuality.Text;
            args += " -ISO " + cbxISO.Text;
            args += " -ex " + cbxExposure.Text;
            args += " -t 1";
            args += " -awb "+cbxAWB.Text;
            args += " -n"; // no preview
            args += " -o /var/cam.jpg";

            // capture photo
            sendMessage("/camera/takePhoto", args);
            Thread.Sleep(200);
            sendMessage("/webserver/enable", "1");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Event handler for closing the windor
            if (client != null && client.IsConnected)
            {
                client.Disconnect();
            }

            if (spTransmit.IsOpen)
            {
                spTransmit.Close();
            }
            
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // disable webserver
            sendMessage("/webserver/disable", "1");
        }

        private void btnWebservice_Click(object sender, EventArgs e)
        {
            // enable webserver
            sendMessage("/webserver/enable", "1");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // timer for updating graphs
            if (cbxAutoScr.Checked)
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Position = chart1.ChartAreas[0].AxisX.Maximum - 15;
                chart1.ChartAreas[0].AxisX.ScaleView.Size = 20;// .Chart1.Series(0)
            }
            for (int i = 0; i < sensors.Count; i++)
            {
                if (i < chart1.Series.Count)
                { //it existss
                    chart1.Series[i].Enabled = sensors.ElementAt(i).enabled.Checked;
                    while (sensors.ElementAt(i).data.Count > 0)
                    { 
                    PointF point = sensors.ElementAt(i).data.Dequeue();
                    chart1.Series[i].Points.AddXY(point.X , point.Y * double.Parse(sensors.ElementAt(i).scale.Text));                 }
 
                }
                else
                {
                    chart1.Series.Add(sensors.ElementAt(i).topic.Text);
                    chart1.Series[sensors.ElementAt(i).topic.Text].ChartType = SeriesChartType.Line;
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // enables live feed timer
            timer2.Enabled = checkBox1.Checked;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //  visualise livve feed
            try
            {
                pbxLiveFeed.Load("http://" + tbxAddress.Text + "/html/cam_pic.php?");
            }
            catch
            {
                MessageBox.Show("lost live feed");
                checkBox1.Checked = false;
            }
        }

        // points for storing target and current positions
        public PointF targetPos;
        public PointF currentPos;

        private void setPositionY(float Y)
        {
            // set the Y position
            setPosition( targetPos.X,Y);
        }

        private void setPositionX(float X)
        {
            // set the X position
            setPosition(X, targetPos.Y);
        }

        private void setPosition(float X,float Y)
        {
            // Sets the craft position
            X = Math.Min(X, tbTargetX.Maximum);
            X = Math.Max(X, tbTargetX.Minimum);

            Y = Math.Min(Y, tbTargetY.Maximum);
            Y = Math.Max(Y, tbTargetY.Minimum);

            targetPos.Y = Y;
            targetPos.X = X;
            lblTargetPitch.Text = "Target Pitch: " + targetPos.X;
            lblTargetRoll.Text = "Target Yaw: " + targetPos.Y;
            tbTargetX.Value = (int) X;
            tbTargetY.Value = (int) Y;

            sendMessage("/status/Pos", X+":"+Y);
            sendMessage("/control/Pos", X+":"+Y);

        }
       

        private void btnYneg10_Click(object sender, EventArgs e)
        {
            // decrease the Y coordinate by 5
            setPositionY(targetPos.Y - 5);
        }

        private void btnYpos10_Click(object sender, EventArgs e)
        {
            // increase the Y coordinate by 5
            setPositionY(targetPos.Y + 5);
        }

        private void btnXneg10_Click(object sender, EventArgs e)
        {
            // decrease the X coordinate by 5
            setPositionX(targetPos.X - 5);
        }

        private void btnXpos10_Click(object sender, EventArgs e)
        {
            // increase the X coordinate by 5
            setPositionX(targetPos.X + 5);
        }

        private void btnXneg1_Click(object sender, EventArgs e)
        {
            // decrease the X coordinate by 1
            setPositionX(targetPos.X - 1);
        }

        private void btnXpos1_Click(object sender, EventArgs e)
        {
            // increase the X coordinate by 1
            setPositionX(targetPos.X + 1);
        }

        private void btnYpos1_Click(object sender, EventArgs e)
        {
            // increase the Y coordinate by 1
            setPositionY(targetPos.Y + 1);
        }

        private void btnYneg1_Click(object sender, EventArgs e)
        {
            // decrease the Y coordinate by 1
            setPositionY(targetPos.Y - 1);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // return craft to origin
            setPosition(0, 0);
        }

        private void btnTarget4_Click(object sender, EventArgs e)
        {
            setPosition(25.0F, -14.5F);
        }

        private void btnTarget3_Click(object sender, EventArgs e)
        {
            setPosition(-45.0F, -24.5F);
        }

        private void btnTarget2_Click(object sender, EventArgs e)
        {
            setPosition(35.0F, 44.5F);
        }

        private void btnTarget1_Click(object sender, EventArgs e)
        {
            setPosition(-15.0F, 14.5F);
        }

        private void tbCurrentX_Scroll(object sender, EventArgs e)
        {
            setPositionX(tbTargetX.Value);
        }

        private void tbCurrentY_Scroll(object sender, EventArgs e)
        {
            setPositionY(tbTargetY.Value);
        }



        int rtbTargetsIndex = 0;
        private void btnNextTarget_Click(object sender, EventArgs e)
        {
            // iterates through target list
            if (rtbTargetsIndex == lbxTargets.Items.Count)
            {
                rtbTargetsIndex = 0;
            }
            var split = lbxTargets.Items[rtbTargetsIndex].ToString().Split(' ');

            lbxTargets.SelectedIndex = rtbTargetsIndex;

            if (split.Length == 2)
            {
                float x = 0, y = 0;
                if(float.TryParse(split[0], out x) &&
                float.TryParse(split[1], out y))
                {
                    setPosition(x, y);
                }

            }
            rtbTargetsIndex++;
        }

        private void btnSetPos_Click(object sender, EventArgs e)
        {
            // Sets custom target position
            float x = 0, y = 0;
            if (float.TryParse(tbxSetPosX.Text, out x) &&
            float.TryParse(tbxSetPosY.Text, out y))
            {
                setPosition(x, y);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Gets all serial ports
            cbxPorts.DataSource = SerialPort.GetPortNames();
        }


        private void comboBoxPorts_DropDown(object sender, EventArgs e)
        {
            // Gets all serial ports on drop down selection
            cbxPorts.DataSource = SerialPort.GetPortNames();
        }

        private void tbGamma_Scroll(object sender, EventArgs e)
        {
            // Reprocesses the image frame when the gamma value is changed
            double _gam = tbGamma.Value;
            _gamma = _gam / 10;
            ProcessFrame();
        }

        private void btnPidYaw_Click(object sender, EventArgs e)
        {
            // PID tuning for yaw
            try
            {
                int Kp = (int)float.Parse(tbxKpYaw.Text) * 100;
                int Ki = (int)float.Parse(tbxKiYaw.Text) * 100;
                int Kd = (int)float.Parse(tbxKdYaw.Text) * 100;
                sendMessage("/control/Pid", Kp + ":" + Ki + ":" + Kd);
            } 
            catch {}
        }

        private void btnPidPitch_Click(object sender, EventArgs e)
        {
            // PID tuning for pitch
            try
            {
                int Kp = (int)float.Parse(tbxKpPitch.Text) * 100;
                int Ki = (int)float.Parse(tbxKiPitch.Text) * 100;
                int Kd = (int)float.Parse(tbxKdPitch.Text) * 100;
                sendMessage("/control/Pid", Kp + ":" + Ki + ":" + Kd);
            }
            catch { }
        }

        private void ckbStart_CheckedChanged(object sender, EventArgs e)
        {
            // start orientation control
            sendMessage("/control/Start", "1");
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            // calibrate orientation control
            sendMessage("/control/Calibrate", "1");
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            // Reads magnetometer at current heading
            sendMessage("/control/Read", "1");
        }

        private void btnCalMag_Click(object sender, EventArgs e)
        {
            // Calibrate magnetometer
            sendMessage("/control/CalMag", "1");
        }
    }
}
