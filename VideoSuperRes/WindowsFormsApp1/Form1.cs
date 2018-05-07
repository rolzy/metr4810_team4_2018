using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Superres;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Startindex;
        bool playnext;
        string[] FileName;
        string[] FilePath;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Startindex = 0;
            playnext = false;
            OpenFileDialog opnFileDlg = new OpenFileDialog();
            opnFileDlg.Multiselect = false;
            opnFileDlg.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,3gp,flv)|*.mp3;*.wav;*.mp4;*.3gp;*.avi;*.mov;*.flv;*.wmv;*.mpg|all files|*.*";
            if (opnFileDlg.ShowDialog() == DialogResult.OK)
            {
                FileName = opnFileDlg.SafeFileNames;
                FilePath = opnFileDlg.FileNames;

                Startindex = 0;
                playfile(0);
            }
        }
        public void playfile(int playlistindex)
        {
            //WindowsMediaPlayer.settings.autoStart = true;
            //WindowsMediaPlayer.URL = FilePath[playlistindex];
            //WindowsMediaPlayer.Ctlcontrols.next();
            //WindowsMediaPlayer.Ctlcontrols.play();
        }
        public void Super(string filename)
        {
            Mat frame = new Mat(); // input video frame
            Mat result = new Mat(); // output superresolution image

            //FrameSource _frameSource = new FrameSource(0); // input frames are obtained from WebCam or USB Camera
            FrameSource _frameSource = new FrameSource(filename, false); // input frames are read from a file
            _frameSource.NextFrame(frame); // input frames are obtained from WebCam or USB Camera

            for (int i = 0; i < 5; i++)
            {
                frame.Save(@"C:\Users\Samantha\Documents\University\Fourth Year\METR4810\Data\SuperresTest\inputframe" + i.ToString("00") + ".png");
                SuperResolution _superResolution = new SuperResolution(Emgu.CV.Superres.SuperResolution.OpticalFlowType.Btvl, _frameSource);
                _superResolution.NextFrame(result); // output super resolution image

                result.Save(@"C:\Users\Samantha\Documents\University\Fourth Year\METR4810\Data\SuperresTest\outputframe" + i.ToString("00") + ".png");

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Super(FilePath[0]);
        }
    }
}
