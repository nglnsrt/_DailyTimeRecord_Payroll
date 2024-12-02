using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DailyTimeRecord_Payroll.User_Controls
{
    public partial class AttendanceReport_UC : UserControl
    {
        private const string PlaceholderText = "Search employee...";
        public AttendanceReport_UC()
        {
            InitializeComponent();
            SetPlaceholder();

            txtSearch.GotFocus += RemovePlaceholder;
            txtSearch.LostFocus += SetPlaceholder;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
        private void SetPlaceholder(object sender, EventArgs e)
        {
            SetPlaceholder();
        }
        private void SetPlaceholder()
        {
            if(string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = PlaceholderText;
                txtSearch.ForeColor = Color.Gray;
            }
        }
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txtSearch.Text == PlaceholderText)
            {
                txtSearch.Text = string.Empty;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void dataGridViewEmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
