using _DailyTimeRecord_Payroll.Models;
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

namespace _DailyTimeRecord_Payroll.User_Controls
{
    public partial class EmployeeList_UC : UserControl
    {
       
        public EmployeeList_UC()
        {
            InitializeComponent();
        }
        private void EmployeeList_UC_Load(object sender, EventArgs e)
        {
            EmployeeList.LoadEmployees(dgvEmployeeList);
        }
        
        
        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
           this.Hide();
            AdminDashboardForm adminDashboardForm = new AdminDashboardForm();
            adminDashboardForm.TriggerClick();
            MessageBox.Show("Add new employee button clicked.");
        }
        
    }
}
