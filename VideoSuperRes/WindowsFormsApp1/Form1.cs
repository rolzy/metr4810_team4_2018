using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.Superres;

using Microsoft.Expression.Encoder;
using Microsoft.Expression.Encoder.Profiles;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] FileName;
        string[] FilePath;


        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnFileDlg = new OpenFileDialog();
            opnFileDlg.Multiselect = false;
            opnFileDlg.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,3gp,flv)|*.mp3;*.wav;*.mp4;*.3gp;*.avi;*.mov;*.flv;*.wmv;*.mpg|all files|*.*";
            if (opnFileDlg.ShowDialog() == DialogResult.OK)
            {
                FileName = opnFileDlg.SafeFileNames;
                FilePath = opnFileDlg.FileNames;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SuperResolutionTest();
        }

        public void SuperResolutionTest()
        {
            Mat frame = new Mat(); // input video frame
            Mat result = new Mat(); // output superresolution image

            //FrameSource _frameSource = new FrameSource(0); // input frames are obtained from WebCam or USB Camera
            FrameSource _frameSource = new FrameSource(@"C:\Users\Samantha\Documents\University\Fourth Year\METR4810\Data\Backlight\vi_0004_20180430_015632.mp4", false); // input frames are read from a file
            _frameSource.NextFrame(frame); // input frames are obtained from WebCam or USB Camera

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    frame.Save(@"C:\Users\Samantha\Documents\University\Fourth Year\METR4810\Data\SuperresTest\In" + i.ToString("00i") + ".png");

                    SuperResolution _superResolution = new SuperResolution(Emgu.CV.Superres.SuperResolution.OpticalFlowType.Btvl, _frameSource);
                    _superResolution.NextFrame(result); // output super resolution image

                    result.Save(@"C:\Users\Samantha\Documents\University\Fourth Year\METR4810\Data\SuperresTest\Out" + i.ToString("00i") + ".png");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

    }
}
