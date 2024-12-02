using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DailyTimeRecord_Payroll.UC_Forms
{
    public partial class CaptureCam : Form
    {
        public CaptureCam()
        {
            InitializeComponent();
        }
        private FilterInfoCollection CaptureDevices;
        private VideoCaptureDevice videoSource;

        private void CaptureCam_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            vbocamerapersonal.Items.Clear();
            CaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevices)
            {
                vbocamerapersonal.Items.Add(Device.Name);
            }
            try
            {
                vbocamerapersonal.SelectedIndex = 0;
                videoSource = new VideoCaptureDevice(CaptureDevices[vbocamerapersonal.SelectedIndex].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
                videoSource.Start();
            }
            catch
            {

            }
        }
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            picpersonalphotocam.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void btncapturephotopersonal_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                AdminDashboardTwo form1 = (AdminDashboardTwo)this.Owner;
                globalnames.pictureBox.Image = (Bitmap)picpersonalphotocam.Image.Clone();
                if (videoSource.IsRunning == true)
                {
                    videoSource.Stop();
                }
                form1.TriggerPhoto();
                this.Hide();
            }
            catch
            {

            }
        }

        private void CaptureCam_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (videoSource != null)
                {
                    if (videoSource.IsRunning == true)
                    {
                        videoSource.Stop();
                    }
                }
            }
            catch
            { }
            this.Hide();
        }
    }
}
