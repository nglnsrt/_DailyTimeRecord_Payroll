using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _DailyTimeRecord_Payroll.Models
{
   internal class EmployeeList
    {
        public static void LoadEmployees(DataGridView dgvEmpList)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter;
            DataTable DSorlist = new DataTable();
            globalnames.con.Open();
            command.Connection = globalnames.con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Load_Employees";
            adapter = new SqlDataAdapter(command);
            DSorlist.Clear();
            adapter.Fill(DSorlist);
            dgvEmpList.Rows.Clear();
            for (int i = 0; i < DSorlist.Rows.Count; i++)
            {
                dgvEmpList.Rows.Add();
                dgvEmpList.Rows[i].Cells["clmeDBID"].Value = DSorlist.Rows[i]["DbID"];
                dgvEmpList.Rows[i].Cells["clmID"].Value = DSorlist.Rows[i]["ID"];
                dgvEmpList.Rows[i].Cells["clmName"].Value = DSorlist.Rows[i]["Names"];
                dgvEmpList.Rows[i].Cells["clmDepartment"].Value = DSorlist.Rows[i]["Department"];
                dgvEmpList.Rows[i].Cells["clmType"].Value = DSorlist.Rows[i]["EmploymentType"];
                dgvEmpList.Rows[i].Cells["clmAction"].Value = "Print";
                dgvEmpList.Rows[i].Cells["clmActionTwo"].Value = "View";
                dgvEmpList.Rows[i].Cells["clmActionThree"].Value = "Delete";
            }
            globalnames.con.Close();
            dgvEmpList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvEmpList.RowsDefaultCellStyle.BackColor = Color.Azure;
            dgvEmpList.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Beige;
        }
       
    }
}
