using _DailyTimeRecord_Payroll.Models;
using AForge.Video;
using DPFP;
using DPFP.Capture;
using DPFP.Processing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DailyTimeRecord_Payroll.UC_Forms
{
    public partial class DailyInOut : Form, DPFP.Capture.EventHandler
    {

        private DPFP.Capture.Capture Capturer;
        private DPFP.Template Template;
        private DPFP.Verification.Verification Verificator;
        public DailyInOut()
        {
            InitializeComponent();
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            CaptureReport("Reader complete");
            ProcessImageVerify(Sample);
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
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            StatusReport("Biometric Reader is Disconnected");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
            {
                CaptureReport("Fingerprint is good");
            }
            else
            {
                CaptureReport("Fingerprint is not good");
            }
        }

        private void OnTemplate(DPFP.Template template)
        {
            Template = template;
            if (Template != null)
            {
                MessageBox.Show("The fingerprint template is ready for verification");
            }
            else
            {
                MessageBox.Show("The fingerprint teamplate is not valid");
            }

        }
        private void Verify(DPFP.Template template)
        {
            Template = template;
            UpdateStatusVerify(0);

        }
        protected virtual void InitializeCaptureVerify()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();

                if (Capturer != null)
                {
                    Capturer.EventHandler = this;
                    Start();
                    Verificator = new DPFP.Verification.Verification();
                    UpdateStatusVerify(0);
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
        private void UpdateStatusVerify(int FAR)
        {
            StatusReport(String.Format("False Accept Rate = {0}", FAR));
        }
        protected virtual void ProcessImage(DPFP.Sample Sample)
        {
            CreateImage(ConvertSampleToBitmap(Sample));
        }
        protected virtual void ProcessImageVerify(DPFP.Sample Sample)
        {
            Verificator = new DPFP.Verification.Verification();
            try
            {
                SqlCommand command = new SqlCommand();
                SqlDataAdapter adapter;
                DataTable DSorlist = new DataTable();
                globalnames.con.Open();
                command.Connection = globalnames.con;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Load_Add_Employees";
                adapter = new SqlDataAdapter(command);
                DSorlist.Clear();
                adapter.Fill(DSorlist);
                globalnames.con.Close();
                foreach (DataRow row in DSorlist.Rows)
                {
                    byte[] fimage = (byte[])row["FingerPrint"];
                    MemoryStream memoryStream = new MemoryStream(fimage);
                    DPFP.Template template = new DPFP.Template();
                    template.DeSerialize(memoryStream);
                    ProcessImage(Sample);
                    DPFP.FeatureSet featureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
                    if (featureSet != null)
                    {
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        Verificator.Verify(featureSet, template, ref result);
                        UpdateStatusVerify(result.FARAchieved);
                        if (result.Verified)
                        {
                            
                            TimeInOut.InsertTimeInOut(row["ID"].ToString(), DateTime.Now, DateTime.Now.ToString("MMMM"), DateTime.Now.ToString("dddd"), DateTime.Now.ToString("tt"),false);
                            CaptureReportViewDetails(row["ID"].ToString(), row["Department"].ToString(),
                                row["EmploymentType"].ToString(), "", row["Names"].ToString(), row["Photo"], row["ID"].ToString());
                            break;
                        }
                        else
                        {
                            CaptureReport("The fingerprint was NOT verified");
                        }
                    }
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        protected void CaptureReportViewDetails(string employeeID,string department,string emptype,string shift, 
            string name, object Photo, string empid)
        {
            this.Invoke(new Action(delegate ()
            {
                Byte[] MyData = new byte[0];
                MyData = (Byte[])Photo;
                MemoryStream stream = new MemoryStream(MyData);
                stream.Position = 0;
                picpersonalphoto.Image = Image.FromStream(stream);
                txtdtrempid.Text = employeeID;
                txtdtrdepartment.Text = department;
                txtdtremploytype.Text = emptype;
                txtdtrshift.Text = shift;
                txtdtrname.Text = name;
                TimeInOut.LoadTimeInOut(dgvInOut, empid);
                lblStatuslogin.Text = "Time " + TimeInOut.TimeInStatus(employeeID);
                txtInOut.Text = TimeInOut.GetInOut(employeeID);
            }));
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
        protected virtual void InitializeCapture()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();

                if (Capturer != null)
                {
                    Capturer.EventHandler = this;
                    Start();
                    UpdateStatusVerify(0);
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
        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose purpose)
        {
            DPFP.Processing.FeatureExtraction featureExtraction = new DPFP.Processing.FeatureExtraction();
            DPFP.Capture.CaptureFeedback captureFeedback = new DPFP.Capture.CaptureFeedback();
            DPFP.FeatureSet featureSet = new DPFP.FeatureSet();
            featureExtraction.CreateFeatureSet(Sample, purpose, ref captureFeedback, ref featureSet);
            if (captureFeedback == DPFP.Capture.CaptureFeedback.Good)
            {
                return featureSet;
            }
            else
            {
                return null;
            }
        }

        private void DailyInOut_Load(object sender, EventArgs e)
        {
            Verify(Template);
            InitializeCaptureVerify();
            timer1.Start();
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
            picFingerDtr.Image = new Bitmap(bitmap, picFingerDtr.Size);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void DailyInOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Stop();
            Capturer = null;
            try
            {
                AdminDashboardTwo form1 = (AdminDashboardTwo)this.Owner;
                //globalnames.pictureBox.Image = (Bitmap)picpersonalphotocam.Image.Clone();
                //if (videoSource.IsRunning == true)
                //{
                //    videoSource.Stop();
                //}
                //form1.TriggerPhoto();
                this.Hide();
                form1.Show();
            }
            catch
            {

            }
        }
    }
}
