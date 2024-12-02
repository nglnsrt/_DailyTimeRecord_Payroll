using DPFP;
using DPFP.Capture;
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
    public partial class CaptureFingerPrint : Form, DPFP.Capture.EventHandler
    {
        private DPFP.Capture.Capture Capturer;
        public CaptureFingerPrint()
        {
            InitializeComponent();
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            CaptureReport("Reader complete");
            ProcessImage(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            CaptureReport("Reader remove");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            CaptureReport("Reader touch");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            StatusReport("Biometric Reader is Connected");
            lblStatus.ForeColor = Color.Green;
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            StatusReport("Biometric Reader is Disconnected");
            lblStatus.ForeColor = Color.Red;

        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
            {
                CaptureReport("Reader good");
            }
            else
            {
                CaptureReport("Reader not good");
            }
        }

        private void EnrollFingerPrint_Load(object sender, EventArgs e)
        {
            InitializeCapture();
        }
        protected virtual void InitializeCapture()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();

                if (Capturer != null)
                {
                    Capturer.EventHandler = this;
                    Start();
                }
                else
                {
                    CaptureReport("Can't initiate capture operation");
                }
            }
            catch
            {
                MessageBox.Show("Can't initialized");
            }
        }
        protected void StatusReport(string message)
        {
            this.Invoke(new Action(delegate ()
            {
                lblStatus.Text = message;
            }));
        }
        protected void CaptureReport(string message)
        {
            this.Invoke(new Action(delegate ()
            {
                txtStatus.Text = message;
            }));
        }
        protected virtual void ProcessImage(DPFP.Sample Sample)
        {
            CreateImage(ConvertSampleToBitmap(Sample));
        }
        protected void Start()
        {
            if (Capturer != null)
            {
                try
                {
                    Capturer.StartCapture();
                    CaptureReport("Scan your fingerprint");
                }
                catch
                {
                    CaptureReport("Can't initiate capture");
                }

            }
        }
        protected void Stop()
        {
            if (Capturer != null)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    CaptureReport("Something went wrong");
                }

            }
        }
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion sampleConverter = new DPFP.Capture.SampleConversion();
            Bitmap bitmap = null;
            sampleConverter.ConvertToPicture(Sample, ref bitmap);
            return bitmap;
        }
        private void CreateImage(Bitmap bitmap)
        {
           fingerImage.Image = new Bitmap(bitmap, fingerImage.Size);
        }
        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose purpose)
        {
            DPFP.Processing.FeatureExtraction featureExtraction = new DPFP.Processing.FeatureExtraction();
            DPFP.Capture.CaptureFeedback captureFeedback = new DPFP.Capture.CaptureFeedback();
            DPFP.FeatureSet featureSet = new DPFP.FeatureSet();
            if (captureFeedback == DPFP.Capture.CaptureFeedback.Good) { 
                return featureSet;
            }
            else{
                return null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Stop();
            this.Hide();
        }
    }
}
