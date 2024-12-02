using _DailyTimeRecord_Payroll.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DailyTimeRecord_Payroll
{
    public partial class AdminDashboardForm : Form
    {
        private AdminDashboard_UC adminDashboard_UC;
        private AttendanceReport_UC attendanceReport_UC;
        private EmployeeList_UC employeeList_UC;
        private AddEmployee_UC addEmployee_UC;
        private Timer slideTimer;
        private bool panelVisible = true;
        private int originalWidth;
        public AdminDashboardForm()
        {
            InitializeComponent();

            slideTimer = new Timer();
            slideTimer.Interval = 10;
            slideTimer.Tick += SlideTimer_Tick;

            adminDashboard_UC = new AdminDashboard_UC();
            attendanceReport_UC = new AttendanceReport_UC();
            employeeList_UC = new EmployeeList_UC();

            //DisplayEmployeeList();
        }

        private void btnHamburger_Click(object sender, EventArgs e)
        {
            
            pnlSideMenu.Visible =!pnlSideMenu.Visible;
            slideTimer.Start();

            if (pnlSideMenu.Visible )
            {
                pnlMainContent.Width-=pnlSideMenu.Width;
            }
            else
            {
                pnlMainContent.Width += pnlSideMenu.Width;
            }
            if (pnlMainContent.Width == originalWidth)
            {
                pnlMainContent.Width = this.ClientSize.Width;
            }
            else
            {
                pnlMainContent.Width=originalWidth;
            }
        }
        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            //Adjust panel width based on visibility
            if(panelVisible && pnlSideMenu.Width < 240)
            {
                pnlSideMenu.Width += 10; //slide open
            }
            else if(!panelVisible && pnlSideMenu.Width>0)
            {
                pnlSideMenu.Width -= 10; //slide closed
                btnHamburger.Visible = pnlSideMenu.Visible;
            }
            else
            {
                slideTimer.Stop(); //stop the timer when complete
            }
        }
        private void panelDashBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        public void ShowUserControl(AdminDashboard_UC adminDashboard_UC)
        {
            panelContainer.Controls.Clear();
            adminDashboard_UC.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(adminDashboard_UC);
            adminDashboard_UC.BringToFront();
        }
        private void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            AdminDashboardForm adminDashboardForm = new AdminDashboardForm();
            ShowUserControl(adminDashboard_UC);
        }
        private void ShowUserControl(AttendanceReport_UC attendanceReport_UC)
        {
            panelContainer.Controls.Clear();
            attendanceReport_UC.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(attendanceReport_UC);
            attendanceReport_UC.BringToFront();
        }

        private void btnAttendanceReport_Click(object sender, EventArgs e)
        {
            
            ShowUserControl(attendanceReport_UC);
        }
        private void ShowUserControl(EmployeeList_UC employeeList_UC)
        {
            panelContainer.Controls.Clear();
            employeeList_UC.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(employeeList_UC);
            employeeList_UC.BringToFront();
        }

        private void btnEmployeeList_Click(object sender, EventArgs e)
        {
            EmployeeList_UC employeeList_UC = new EmployeeList_UC();
            ShowUserControl(employeeList_UC);
        }

        private void ShowUserControl(AddEmployee_UC addEmployee_UC)
        {
            panelContainer.Controls.Clear();
            addEmployee_UC.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(addEmployee_UC);
            addEmployee_UC.BringToFront();
        }
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployee_UC addEmployee_UC = new AddEmployee_UC();
            ShowUserControl(addEmployee_UC);
        }
        public void TriggerClick()
        {
            AddEmployee_UC addEmployee_UC = new AddEmployee_UC();
            ShowUserControl(addEmployee_UC);
        }
        //Display the Add Employee Form when Add New Employee button in the Employee List is clicked
        //private void DisplayEmployeeList()
        //{
        //    //Create and add employee list usercontrol to the panelContainer in dashboard
        //    EmployeeList_UC employeeList_UC = new EmployeeList_UC();

        //    employeeList_UC.ShowAddEmployeeForm += EmployeeList_ShowAddEmployeeForm;

        //    panelContainer.Controls.Clear();
        //    employeeList_UC.Dock = DockStyle.Fill;
        //    panelContainer.Controls.Add(employeeList_UC);
        //}
        //private void EmployeeList_ShowAddEmployeeForm(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Event triggered");
        //    panelContainer.Controls.Clear();

        //    AddEmployee_UC addEmployee_UC = new AddEmployee_UC();
        //    addEmployee_UC.Dock = DockStyle.Fill;
        //    panelContainer.Controls.Add(addEmployee_UC);
        //}
        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            //DisplayEmployeeList();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm1 loginForm = new LoginForm1();
            loginForm.ShowDialog();
        }


    }
}
