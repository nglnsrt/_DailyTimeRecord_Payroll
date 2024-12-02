using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace _DailyTimeRecord_Payroll.Models
{
    internal class TimeInOut
    {
        public static void InsertTimeInOut(string EmployeeID, DateTime Date_,string Month_,string Day_week, string Remarks,bool Description)
        {
            SqlCommand command = new SqlCommand();
            globalnames.con.Open();
            command.Connection = globalnames.con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Insert_Time_In_Out";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
            command.Parameters.Add(new SqlParameter("@Date_", Date_));
            command.Parameters.Add(new SqlParameter("@Time_In", Date_));
            command.Parameters.Add(new SqlParameter("@Time_OUT", Date_));
            command.Parameters.Add(new SqlParameter("@Month_", Month_));
            command.Parameters.Add(new SqlParameter("@Day_week", Day_week));
            command.Parameters.Add(new SqlParameter("@Remarks", Remarks));
            command.ExecuteNonQuery();
            globalnames.con.Close();
        }
        public static void LoadTimeInOut(DataGridView dgvInOut,string employeeid)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter;
            DataTable DSorlist = new DataTable();
            globalnames.con.Open();
            command.Connection = globalnames.con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Load_Time_In_Out";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@EmployeeID", employeeid));
            adapter = new SqlDataAdapter(command);
            DSorlist.Clear();
            adapter.Fill(DSorlist);
            dgvInOut.Rows.Clear();
            for (int i = 0; i < DSorlist.Rows.Count; i++)
            {
                dgvInOut.Rows.Add();
                dgvInOut.Rows[i].Cells["clmsEmployeeID"].Value = DSorlist.Rows[i]["EmployeeID"];
                dgvInOut.Rows[i].Cells["clmsDeath"].Value = DSorlist.Rows[i]["Date_"];
               
                
                dgvInOut.Rows[i].Cells["clmsstatus"].Value = DSorlist.Rows[i]["Status"];
                dgvInOut.Rows[i].Cells["clmsRemarks"].Value = DSorlist.Rows[i]["Remarks"];
                dgvInOut.Rows[i].Cells["clmmonth"].Value = DSorlist.Rows[i]["Month"];
                dgvInOut.Rows[i].Cells["clmdays"].Value = DSorlist.Rows[i]["Days"];
                if (DSorlist.Rows[i]["Status"].ToString() == "IN")
                {
                    dgvInOut.Rows[i].Cells["clmsTime"].Value = DSorlist.Rows[i]["Time_In"];
                    dgvInOut.Rows[i].Cells["clmtimeout"].Value = "--:--";
                }
                else
                {
                    dgvInOut.Rows[i].Cells["clmtimeout"].Value = DSorlist.Rows[i]["Time_OUT"];
                    dgvInOut.Rows[i].Cells["clmsTime"].Value = "--:--";
                }
            }
            globalnames.con.Close();
            dgvInOut.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvInOut.RowsDefaultCellStyle.BackColor = Color.Azure;
            dgvInOut.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Beige;
        }
        public static string TimeInStatus(string employeeID)
        {
            string timeStatus = string.Empty;
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter;
            DataTable DSorlist = new DataTable();
            globalnames.con.Open();
            command.Connection = globalnames.con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Get_Time_Status";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));
            adapter = new SqlDataAdapter(command);
            DSorlist.Clear();
            adapter.Fill(DSorlist);
            globalnames.con.Close();
            foreach (DataRow row in DSorlist.Rows)
            {
                timeStatus = row["Status"].ToString();
            }
            return timeStatus;
        }
        public static string GetInOut(string employeeID)
        {
            string GetInOut = string.Empty;
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter;
            DataTable DSorlist = new DataTable();
            globalnames.con.Open();
            command.Connection = globalnames.con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Get_In_Out";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));
            adapter = new SqlDataAdapter(command);
            DSorlist.Clear();
            adapter.Fill(DSorlist);
            globalnames.con.Close();
            foreach (DataRow row in DSorlist.Rows)
            {
                GetInOut = row["Time_"].ToString();
            }
            return GetInOut;
        }
    }
}
