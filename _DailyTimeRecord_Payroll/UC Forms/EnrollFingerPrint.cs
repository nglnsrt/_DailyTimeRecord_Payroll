using DPFP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DailyTimeRecord_Payroll.UC_Forms
{
    public partial class EnrollFingerPrint : CaptureFingerPrint
    {
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        public event OnTemplateEventHandler OnTemplate;
        private DPFP.Processing.Enrollment enrollment;
        protected override void InitializeCapture()
        {
            base.InitializeCapture();
            base.Text = "fingerprint Enrollment";
            enrollment = new DPFP.Processing.Enrollment();
            UpdateStatus();
        }
        protected override void ProcessImage(Sample Sample)
        {
            base.ProcessImage(Sample);
            DPFP.FeatureSet featureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
            if(featureSet != null)
            {
                try
                {
                    CaptureReport("The fingerprint feature set was created.");
                    enrollment.AddFeatures(featureSet);
                }
                finally
                {
                    UpdateStatus();
                    switch(enrollment.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:
                            {
                                int count = 0;
                                OnTemplate(enrollment.Template);
                                MemoryStream fingerPrintdata = new MemoryStream();
                                enrollment.Template.Serialize(fingerPrintdata);
                                fingerPrintdata.Position = 0;
                                BinaryReader binaryReader = new BinaryReader(fingerPrintdata);
                                byte[] bytes = binaryReader.ReadBytes((Int32)fingerPrintdata.Length);

                                break;

                            }
                        case DPFP.Processing.Enrollment.Status.Failed:
                            {
                                enrollment.Clear();
                                Stop();
                                UpdateStatus();
                                OnTemplate(null);
                                Start();
                                break;
                            }
                    }
                }
            }
        }
        private void UpdateStatus()
        {
            CaptureReport(String.Format("Finger Sample Needed: {0}", enrollment.FeaturesNeeded));
        }
    }
}
