using AForge.Video.DirectShow;
using AForge.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _DailyTimeRecord_Payroll.Models;
using _DailyTimeRecord_Payroll.UC_Forms;
using DPFP;
using DPFP.Capture;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using DevComponents.DotNetBar.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace _DailyTimeRecord_Payroll
{
    public partial class AdminDashboardTwo : Form, DPFP.Capture.EventHandler
    {
        private DPFP.Capture.Capture Capturer;
        private DPFP.Template Template;
        private DPFP.Processing.Enrollment enrollment;
        byte[] bytes;
        public AdminDashboardTwo()
        {
            InitializeComponent();
        }
        List<TabPage> savedTabPages;
        int step = -1;
        private FilterInfoCollection CaptureDevices;
        private VideoCaptureDevice videoSource;
        private void SelectNextStep()
        {
            step++;
            // remove all tabs
            for (int i = tabmain.TabPages.Count - 1; i >= 0; i--)
            {
                tabmain.TabPages.Remove(tabmain.TabPages[i]);
            }
            // add required tab
            tabmain.TabPages.Add(savedTabPages[step]);
        }

        private void AdminDashboardTwo_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            savedTabPages = new List<TabPage>();
            foreach (TabPage tp in tabmain.TabPages)
            {
                savedTabPages.Add(tp);
            }
            SelectNextStep();
            Helpers.LoadDepartment(cbDepartment);
            Helpers.LoadPosition(cbPosition);
            tslusername.Text = globalnames.gblusername;
            tslworkingdate.Text = DateTime.Now.ToShortDateString();
            tslbranch.Text = "BOLINAO";
            EmployeeCRUD.LoadEmployeeName(txtPAssignCode);
            txtPAssignCode.Text = "";


        }

        private void AdminDashboardTwo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            tabmain.TabPages.Clear();
            if (tabmain.TabPages.Contains(tpadmin))
            {
                tabmain.SelectedTab = tpadmin;
            }
            else
            {
                tabmain.TabPages.Add(savedTabPages[0]);
                tabmain.SelectedTab = tpadmin;
            }
        }

        private void btnAttendanceReport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            tabmain.TabPages.Clear();
            if (tabmain.TabPages.Contains(tpattendancereport))
            {
                tabmain.SelectedTab = tpattendancereport;
            }
            else
            {
                tabmain.TabPages.Add(savedTabPages[1]);
                tabmain.SelectedTab = tpattendancereport;
            }
        }

        private void btnEmployeeList_Click(object sender, EventArgs e)
        {
            tabmain.TabPages.Clear();
            if (tabmain.TabPages.Contains(tpemployeelist))
            {
                tabmain.SelectedTab = tpemployeelist;
            }
            else
            {
                tabmain.TabPages.Add(savedTabPages[2]);
                tabmain.SelectedTab = tpemployeelist;
            }
            EmployeeList.LoadEmployees(dgvEmployeeList);
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            tabmain.TabPages.Clear();
            if (tabmain.TabPages.Contains(tpaddemployee))
            {
                tabmain.SelectedTab = tpaddemployee;
            }
            else
            {
                tabmain.TabPages.Add(savedTabPages[3]);
                tabmain.SelectedTab = tpaddemployee;
            }
            cbGender.SelectedIndex = 0;
            cbEmploymentType.SelectedIndex = 0;
            //EmployeeCRUD.LoadAddEmployees(dgvAddEmployee);
            txtFirstName.Focus();
        }

        private void btnSalaryReport_Click(object sender, EventArgs e)
        {
            tabmain.TabPages.Clear();
            if (tabmain.TabPages.Contains(tpsalaryreport))
            {
                tabmain.SelectedTab = tpsalaryreport;
            }
            else
            {
                tabmain.TabPages.Add(savedTabPages[4]);
                tabmain.SelectedTab = tpsalaryreport;
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            tabmain.TabPages.Clear();
            if (tabmain.TabPages.Contains(tpsetting))
            {
                tabmain.SelectedTab = tpsetting;
            }
            else
            {
                tabmain.TabPages.Add(savedTabPages[5]);
                tabmain.SelectedTab = tpsetting;
            }
        }

        private void tsbAddNewEmployee_Click(object sender, EventArgs e)
        {
            tabmain.TabPages.Clear();
            if (tabmain.TabPages.Contains(tpaddemployee))
            {
                tabmain.SelectedTab = tpaddemployee;
            }
            else
            {
                tabmain.TabPages.Add(savedTabPages[3]);
                tabmain.SelectedTab = tpaddemployee;
            }
            btnClear.PerformClick();
        }

        private void btnViewEmployee_Click(object sender, EventArgs e)
        {
            tabmain.TabPages.Clear();
            if (tabmain.TabPages.Contains(tpemployeelist))
            {
                tabmain.SelectedTab = tpemployeelist;
            }
            else
            {
                tabmain.TabPages.Add(savedTabPages[2]);
                tabmain.SelectedTab = tpemployeelist;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Helpers.ClearForm(txtEmployeeID, txtFirstName, txtMiddleName, txtLastName, txtContactNumber, txtAddress, dateTimePickerEmploymentDate
         , cbGender, cbPosition, cbDepartment, cbEmploymentType, picpersonalphoto, dateTimePickerBirthDate, txtDailyWage, dgvAddEmployee, fingerImage);
            globalnames.forEditEmployee = false;
            Stop();
            Capturer = null;
        }

        private void btnwebcampersonal_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CaptureCam captureCam = new CaptureCam();
            this.AddOwnedForm(captureCam);
            captureCam.ShowDialog();
        }

        public void TriggerPhoto()
        {
            picpersonalphoto.Image = globalnames.pictureBox.Image;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBox.Show("Please fill FirstName field.", "Error FirstName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMiddleName.Text))
            {
                MessageBox.Show("Please fill MiddleName field.", "Error MiddleName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMiddleName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Please fill LastName field.", "Error LastName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                return;
            }
            
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please fill Address field.", "Error Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtContactNumber.Text))
            {
                MessageBox.Show("Please fill ContactNumber field.", "Error ContactNumber", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNumber.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDailyWage.Text))
            {
                MessageBox.Show("Please fill DailyWage field.", "Error DailyWage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDailyWage.Focus();
                return;
            }
            double checkDailyWages = 0;
            try
            {
                checkDailyWages = Convert.ToDouble(txtDailyWage.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Only numeric value is Allowed.", "Error Numeric DailyWage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDailyWage.Focus();
                return;
            }
            if(Convert.ToDouble(txtDailyWage.Text.Trim()) == 0)
            {
                MessageBox.Show("DailyWage should not be Zero (0)", "Error Value DailyWage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDailyWage.Focus();
                return;
            }
            if (picpersonalphoto.Image == null)
            {
                MessageBox.Show("Please Select Image", "Error Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            if(globalnames.forEditEmployee == true)
            {
                EmployeeCRUD.UpdateEmployee(picpersonalphoto, txtEmployeeID, txtFirstName, txtMiddleName, txtLastName,
               txtContactNumber, txtAddress, dateTimePickerEmploymentDate, cbGender, cbPosition, cbDepartment,
               cbEmploymentType, dateTimePickerBirthDate, txtDailyWage,lbldbid);
            }
            else
            {
                EmployeeCRUD.InsertEmployee(picpersonalphoto, txtEmployeeID, txtFirstName, txtMiddleName, txtLastName,
                txtContactNumber, txtAddress, dateTimePickerEmploymentDate, cbGender, cbPosition, cbDepartment,
                cbEmploymentType, dateTimePickerBirthDate, txtDailyWage, bytes);
            }

            btnClear.PerformClick();
            EmployeeCRUD.LoadAddEmployees(dgvAddEmployee);
            
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picpersonalphoto.Image = Image.FromFile(openFileDialog.FileName);
                    picpersonalphoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    picpersonalphoto.Tag = openFileDialog.FileName;
                }
            }
        }

        private void txtEmployeeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Then Enter key was pressed
                EmployeeCRUD.SearchAddEmployees(dgvAddEmployee,txtEmployeeID.Text.Trim());
                try
                {
                    return;
                }
                catch (Exception) { }
            }
        }

        private void tsllogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm1 loginForm = new LoginForm1();
            loginForm.ShowDialog();
        }

        

        private void btnload_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            EmployeeCRUD.LoadAddEmployees(dgvAddEmployee);
        }

        

        private void btnenrollFingerPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //CaptureFingerPrint enrollFingerPrint = new CaptureFingerPrint();
            //this.AddOwnedForm(enrollFingerPrint);
            //enrollFingerPrint.ShowDialog();
            InitializeCapture();
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            CaptureReport("Reader complete");
            ProcessImageOverride(Sample);
            lblStatus.ForeColor = Color.Black;
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            CaptureReport("Reader remove");
            lblStatus.ForeColor = Color.Black;
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            CaptureReport("Reader touch");
            lblStatus.ForeColor = Color.Black;
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

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
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
        protected virtual void InitializeCapture()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();

                if (Capturer != null)
                {
                    Capturer.EventHandler = this;
                    Start();
                    enrollment = new DPFP.Processing.Enrollment();
                    UpdateStatus();
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
        protected virtual void ProcessImageOverride(DPFP.Sample Sample)
        {
            ProcessImage(Sample);
            DPFP.FeatureSet featureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
            if (featureSet != null)
            {
                try
                {
                    CaptureReport("The fingerprint feature set was created.");
                    enrollment.AddFeatures(featureSet);
                }
                finally
                {
                    UpdateStatus();
                    switch (enrollment.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:
                            {
                                int count = 0;
                                OnTemplate(enrollment.Template);
                                MemoryStream fingerPrintdata = new MemoryStream();
                                enrollment.Template.Serialize(fingerPrintdata);
                                fingerPrintdata.Position = 0;
                                BinaryReader binaryReader = new BinaryReader(fingerPrintdata);
                                bytes = binaryReader.ReadBytes((Int32)fingerPrintdata.Length);

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
            featureExtraction.CreateFeatureSet(Sample, purpose,ref captureFeedback,ref featureSet);
            if (captureFeedback == DPFP.Capture.CaptureFeedback.Good)
            {
                return featureSet;
            }
            else
            {
                return null;
            }
        }
        private void UpdateStatus()
        {
            StatusReport(String.Format("Finger Sample Needed: {0}", enrollment.FeaturesNeeded));
        }
        private void OnTemplate(DPFP.Template template)
        {
            Template = template;
            if (Template != null) {
                MessageBox.Show("The fingerprint template is ready for verification");
            }
            else
            {
                MessageBox.Show("The fingerprint teamplate is not valid");
            }

        }

        private void dgvAddEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 15)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (MessageBox.Show("Are you sure you want to Edit this Record?", "Warning Edit Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    EmployeeCRUD.ShowGridToTextbox(picpersonalphoto, dgvAddEmployee, txtEmployeeID, txtFirstName, txtMiddleName, txtLastName, dateTimePickerEmploymentDate,
                                                   dateTimePickerBirthDate, txtAddress, txtContactNumber, lbldbid, txtDailyWage, cbEmploymentType, cbGender, cbDepartment, cbPosition);
                    globalnames.forEditEmployee = true;
                }

            }
            if (e.ColumnIndex == 16)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (MessageBox.Show("Are you sure you want to Delete this Record?", "Warning Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    EmployeeCRUD.DeleteEmployee(Convert.ToInt32(dgvAddEmployee.CurrentRow.Cells["clmdbid"].Value));
                    btnload.PerformClick();
                }

            }
        }

        private void btnInOut_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Stop();
            Capturer = null;
            DailyInOut dailyInOut = new DailyInOut();
            this.AddOwnedForm(dailyInOut);
            this.Hide();
            dailyInOut.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm1 loginForm = new LoginForm1();
            loginForm.ShowDialog();
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {
            tabmain.TabPages.Clear();
            if (tabmain.TabPages.Contains(tpPayroll))
            {
                tabmain.SelectedTab = tpPayroll;
            }
            else
            {
                tabmain.TabPages.Add(savedTabPages[6]);
                tabmain.SelectedTab = tpPayroll;
            }
        }

        private void txtPAssignCode_TextChanged(object sender, EventArgs e)
        {
            EmployeeCRUD.GetEmployeeByID(txtPAssignCode.Text.Trim(), txtPEmployeeName, txtemployeeposition, txtemployeetype, txtPRateperday, txtPNoDays);
            if (!string.IsNullOrEmpty(txtPAssignCode.Text))
            {

                RegOTHr();
                RegHol();
                calc_on_dedution();
            }

        }

        private void txtPNoDays_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double rateWage, grossincome, neticome, ot, holpay;

                ot = Convert.ToDouble(txtPregOt.Text);
                holpay = Convert.ToDouble((txtPholPay.Text));

                if (txtPNoDays.Text == "" || txtPNoDays.Text == "0")
                {
                    txtPrateWage.Text = "0";
                    rateWage = Convert.ToDouble((txtPrateWage.Text));

                }
                else
                {
                    rateWage = Convert.ToDouble(txtPRateperday.Text) * Convert.ToDouble(txtPNoDays.Text);
                    txtPrateWage.Text = rateWage.ToString();

                }




                grossincome = rateWage + ot + holpay;
                txtpgincome.Text = grossincome.ToString();


                neticome = grossincome - Convert.ToDouble(txtpdeducttot.Text);
                txtpnetincome.Text = neticome.ToString("#,##0.00");
            }
            catch (Exception ex)
            {

            }
        }
        private void calc_on_dedution()
        {
            try
            {
                double ca, phic, pagibig,sss, d1, d2, d3, d4, total_deduction, gross, total_net;

                ca = Convert.ToDouble(txtpcadvance.Text);
                phic = Convert.ToDouble(txtpphic.Text);
                pagibig = Convert.ToDouble(txtppagibig.Text);
                sss = Convert.ToDouble(txtsss.Text);
                d1 = Convert.ToDouble(txtpdeduct1.Text);
                d2 = Convert.ToDouble(txtpdeduct2.Text);
                d3 = Convert.ToDouble(txtpdeduct3.Text);
                d4 = Convert.ToDouble(txtpdeduct4.Text);
                gross = Convert.ToDouble(txtpgincome.Text);

                total_deduction = ca + phic + pagibig + sss + d1 + d2 + d3 + d4;
                txtpdeducttot.Text = total_deduction.ToString();

                total_net = gross - total_deduction;
                txtpnetincome.Text = total_net.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void RegOTHr()
        {
            try
            {



                double total, total_OT, grossincome, neticome, ot, holpay, rateWage;


                if (txtPRegOtHr.Text == "" || txtPRegOtHr.Text == "0")
                {
                    txtPregOt.Text = "0";
                }
                else
                {
                    total = Convert.ToDouble(txtPRateperday.Text) / 8;
                    total_OT = total * Convert.ToDouble(txtPRegOtHr.Text);
                    txtPregOt.Text = total_OT.ToString();

                }

                ot = Convert.ToDouble(txtPregOt.Text);
                holpay = Convert.ToDouble(txtPholPay.Text);
                rateWage = Convert.ToDouble(txtPrateWage.Text);

                grossincome = rateWage + ot + holpay;
                txtpgincome.Text = grossincome.ToString();

                neticome = grossincome - Convert.ToDouble(txtpdeducttot.Text);
                txtpnetincome.Text = neticome.ToString();

            }
            catch
            {

            }
        }
        private void RegHol()
        {
            try
            {



                double total_hol, grossincome, neticome, ot, holpay, rateWage;

                if (txtPholPayDay.Text == "" || txtPholPayDay.Text == "0")
                {
                    txtPholPay.Text = "0";
                }
                else
                {
                    total_hol = Convert.ToDouble(txtPRateperday.Text) * Convert.ToDouble(txtPholPayDay.Text);

                    txtPholPay.Text = total_hol.ToString();

                }

                ot = Convert.ToDouble(txtPregOt.Text);
                holpay = Convert.ToDouble(txtPholPay.Text);
                rateWage = Convert.ToDouble(txtPrateWage.Text);

                grossincome = rateWage + ot + holpay;
                txtpgincome.Text = grossincome.ToString();

                neticome = grossincome - Convert.ToDouble(txtpdeducttot.Text);
                txtpnetincome.Text = neticome.ToString();

            }
            catch
            {

            }
        }
        private void btnnewpayroll_Click(object sender, EventArgs e)
        {
            txtPEmployeeName.Text = "";
            txtpremarks.Text = "";
            txtPAssignCode.Text = "";
            //Helpers.clearTxt(groupBox1);
            //Helpers.clearTxt(groupBox3);
            //Helpers.clearTxt(groupBox6);
            //Helpers.clearTxt(groupBox5);
            txtPNoDays.Text = "0";
            txtPRateperday.Text = "0";
            txtPrateWage.Text = "0";
            txtPRegOtHr.Text = "0";
            txtPrateWage.Text = "0";
            txtPregOt.Text = "0";
            txtPRegOtHr.Text = "0";
            txtPholPayDay.Text = "0";
            txtPholPay.Text = "0";
            txtpgincome.Text = "0";
            txtpnetincome.Text = "0";
            txtpdeducttot.Text = "0";
            txtpcadvance.Text = "0";
            //txtpphic.Text = "0";
            //txtppagibig.Text = "0";
            txtpdeduct1.Text = "0";
            txtpdeduct2.Text = "0";
            txtpdeduct3.Text = "0";
            txtpdeduct4.Text = "0";
            txtPAssignCode.Focus();
        }

        private void txtPRegOtHr_TextChanged(object sender, EventArgs e)
        {
            RegOTHr();
        }

        private void txtPholPayDay_TextChanged(object sender, EventArgs e)
        {
            RegHol();
        }

        private void txtpcadvance_TextChanged(object sender, EventArgs e)
        {
            if (txtpcadvance.Text == "" || txtpcadvance.Text == "0")
            {
                txtpcadvance.Text = "0";

            }

            calc_on_dedution();
        }

        private void txtpphic_TextChanged(object sender, EventArgs e)
        {
            if (txtpphic.Text == "" || txtpphic.Text == "0")
            {
                txtpphic.Text = "0";

            }
            calc_on_dedution();
        }

        private void txtppagibig_TextChanged(object sender, EventArgs e)
        {
            if (txtppagibig.Text == "" || txtppagibig.Text == "0")
            {
                txtppagibig.Text = "0";

            }
            calc_on_dedution();
        }

        private void txtsss_TextChanged(object sender, EventArgs e)
        {
            if (txtsss.Text == "" || txtsss.Text == "0")
            {
                txtsss.Text = "0";

            }
            calc_on_dedution();
        }

        private void txtpdeduct1_TextChanged(object sender, EventArgs e)
        {

            if (txtpdeduct1.Text == "" || txtpdeduct1.Text == "0")
            {
                txtpdeduct1.Text = "0";

            }
            calc_on_dedution();
        }

        private void txtpdeduct2_TextChanged(object sender, EventArgs e)
        {
            if (txtpdeduct2.Text == "" || txtpdeduct2.Text == "0")
            {
                txtpdeduct2.Text = "0";

            }
            calc_on_dedution();
        }

        private void txtpdeduct3_TextChanged(object sender, EventArgs e)
        {
            if (txtpdeduct3.Text == "" || txtpdeduct3.Text == "0")
            {
                txtpdeduct3.Text = "0";

            }
            calc_on_dedution();
        }

        private void txtpdeduct4_TextChanged(object sender, EventArgs e)
        {
            if (txtpdeduct4.Text == "" || txtpdeduct4.Text == "0")
            {
                txtpdeduct4.Text = "0";

            }
            calc_on_dedution();
        }

        private void btnSavepayroll_Click(object sender, EventArgs e)
        {

            if (txtPNoDays.Text == "" || txtPregOt.Text == "" || txtPholPay.Text == "")
            {
                MessageBox.Show("One of the box is empty. Data is required.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Payroll.InsertPayroll(txtPAssignCode, txtPNoDays, txtPrateWage, txtPregOt, txtPholPay, txtpgincome, txtpcadvance, txtpphic, txtsss, txtppagibig, txtpnetincome, txtpremarks.Text, DateTime.Now, "");
                MessageBox.Show("Record saved succesfully", "Record Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnnewpayroll.PerformClick();
            }
        }

       
    }
}
