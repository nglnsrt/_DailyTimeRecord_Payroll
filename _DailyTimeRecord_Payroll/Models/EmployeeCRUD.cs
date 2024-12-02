using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _DailyTimeRecord_Payroll.Models
{
    internal class EmployeeCRUD
    {
        public static void InsertEmployee(PictureBox picpersonalphoto, TextBox txtEmployeeID, TextBox txtFirstName, TextBox txtMiddleName,
            TextBox txtLastName, TextBox txtContactNumber, TextBox txtAddress,
            DateTimePicker dateTimePickerEmploymentDate, ComboBox cbGender, ComboBox cbPosition,
            ComboBox cbDepartment, ComboBox cbEmploymentType, 
            DateTimePicker dateTimePickerBirthDate, TextBox txtDailyWage, byte[] fingerprint)
        {
            SqlCommand command = new SqlCommand();
            Image img = picpersonalphoto.Image;
            byte[] arrpic;
            ImageConverter converter = new ImageConverter();
            arrpic = (byte[])converter.ConvertTo(img, typeof(byte[]));
            globalnames.con.Open();
            command.Connection = globalnames.con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Insert_Employee";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@ID", txtEmployeeID.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@FirstName", txtFirstName.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@MiddleName", txtMiddleName.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@LastName", txtLastName.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@Address", txtAddress.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@ContactNumber", txtContactNumber.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@Gender", cbGender.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@Department", cbDepartment.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@Position", cbPosition.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@EmploymentType", cbEmploymentType.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@DateOfBirth", dateTimePickerBirthDate.Value));
            command.Parameters.Add(new SqlParameter("@DateOfEmployment", dateTimePickerEmploymentDate.Value));
            command.Parameters.Add(new SqlParameter("@DailyWage", Convert.ToDouble(txtDailyWage.Text.Trim())));
            command.Parameters.Add(new SqlParameter("@Photo", arrpic));
            command.Parameters.Add(new SqlParameter("@FingerPrint", fingerprint));
            command.ExecuteNonQuery();
            globalnames.con.Close();
            arrpic = null;
        }

        public static void LoadAddEmployees(DataGridView dgvAddEmpList)
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
            dgvAddEmpList.Rows.Clear();
            for (int i = 0; i < DSorlist.Rows.Count; i++)
            {
                dgvAddEmpList.Rows.Add();
                dgvAddEmpList.Rows[i].Cells["clmdbid"].Value = DSorlist.Rows[i]["DbID"];
                dgvAddEmpList.Rows[i].Cells["clmaddID"].Value = DSorlist.Rows[i]["ID"];
                dgvAddEmpList.Rows[i].Cells["clmaddFirstName"].Value = DSorlist.Rows[i]["FirstName"];
                dgvAddEmpList.Rows[i].Cells["clmaddMiddleName"].Value = DSorlist.Rows[i]["MiddleName"];
                dgvAddEmpList.Rows[i].Cells["clmaddLastName"].Value = DSorlist.Rows[i]["LastName"];
                dgvAddEmpList.Rows[i].Cells["clmaddAddress"].Value = DSorlist.Rows[i]["Address"];
                dgvAddEmpList.Rows[i].Cells["clmaddContactNumber"].Value = DSorlist.Rows[i]["ContactNumber"];
                dgvAddEmpList.Rows[i].Cells["clmaddGender"].Value = DSorlist.Rows[i]["Gender"];
                dgvAddEmpList.Rows[i].Cells["clmaddDepartment"].Value = DSorlist.Rows[i]["Department"];
                dgvAddEmpList.Rows[i].Cells["clmaddPosition"].Value = DSorlist.Rows[i]["Position"];
                dgvAddEmpList.Rows[i].Cells["clmaddEmploymentType"].Value = DSorlist.Rows[i]["EmploymentType"];
                dgvAddEmpList.Rows[i].Cells["clmaddDateOfBirth"].Value = DSorlist.Rows[i]["DateOfBirth"];
                dgvAddEmpList.Rows[i].Cells["clmDateaddOfEmployment"].Value = DSorlist.Rows[i]["DateOfEmployment"];
                dgvAddEmpList.Rows[i].Cells["clmaddDailyWage"].Value = DSorlist.Rows[i]["DailyWage"];
                dgvAddEmpList.Rows[i].Cells["clmaddPhoto"].Value = DSorlist.Rows[i]["Photo"];
                dgvAddEmpList.Rows[i].Cells["clmeditaddemp"].Value = "Edit";
                dgvAddEmpList.Rows[i].Cells["clmaddDelete"].Value = "Delete";
            }
            globalnames.con.Close();
            dgvAddEmpList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvAddEmpList.RowsDefaultCellStyle.BackColor = Color.Azure;
            dgvAddEmpList.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Beige;
        }

        public static void UpdateEmployee(PictureBox picpersonalphoto, TextBox txtEmployeeID, TextBox txtFirstName, TextBox txtMiddleName,
           TextBox txtLastName, TextBox txtContactNumber, TextBox txtAddress,
           DateTimePicker dateTimePickerEmploymentDate, ComboBox cbGender, ComboBox cbPosition,
           ComboBox cbDepartment, ComboBox cbEmploymentType,
           DateTimePicker dateTimePickerBirthDate, TextBox txtDailyWage, Label lbldbid)
        {
            SqlCommand command = new SqlCommand();
            Image img = picpersonalphoto.Image;
            byte[] arrpic;
            ImageConverter converter = new ImageConverter();
            arrpic = (byte[])converter.ConvertTo(img, typeof(byte[]));
            globalnames.con.Open();
            command.Connection = globalnames.con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Update_Employee";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@DBID", Convert.ToInt32(lbldbid.Text.Trim())));
            command.Parameters.Add(new SqlParameter("@ID", txtEmployeeID.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@FirstName", txtFirstName.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@MiddleName", txtMiddleName.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@LastName", txtLastName.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@Address", txtAddress.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@ContactNumber", txtContactNumber.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@Gender", cbGender.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@Department", cbDepartment.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@Position", cbPosition.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@EmploymentType", cbEmploymentType.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@DateOfBirth", dateTimePickerBirthDate.Value));
            command.Parameters.Add(new SqlParameter("@DateOfEmployment", dateTimePickerEmploymentDate.Value));
            command.Parameters.Add(new SqlParameter("@DailyWage", Convert.ToDouble(txtDailyWage.Text.Trim())));
            command.Parameters.Add(new SqlParameter("@Photo", arrpic));
            command.ExecuteNonQuery();
            globalnames.con.Close();
            arrpic = null;
        }

        public static void SearchAddEmployees(DataGridView dgvAddEmpList, string EmpID)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter;
            DataTable DSorlist = new DataTable();
            globalnames.con.Open();
            command.Connection = globalnames.con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Search_Add_Employees";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@ID", EmpID));
            adapter = new SqlDataAdapter(command);
            DSorlist.Clear();
            adapter.Fill(DSorlist);
            dgvAddEmpList.Rows.Clear();
            for (int i = 0; i < DSorlist.Rows.Count; i++)
            {
                dgvAddEmpList.Rows.Add();
                dgvAddEmpList.Rows[i].Cells["clmdbid"].Value = DSorlist.Rows[i]["DbID"];
                dgvAddEmpList.Rows[i].Cells["clmaddID"].Value = DSorlist.Rows[i]["ID"];
                dgvAddEmpList.Rows[i].Cells["clmaddFirstName"].Value = DSorlist.Rows[i]["FirstName"];
                dgvAddEmpList.Rows[i].Cells["clmaddMiddleName"].Value = DSorlist.Rows[i]["MiddleName"];
                dgvAddEmpList.Rows[i].Cells["clmaddLastName"].Value = DSorlist.Rows[i]["LastName"];
                dgvAddEmpList.Rows[i].Cells["clmaddAddress"].Value = DSorlist.Rows[i]["Address"];
                dgvAddEmpList.Rows[i].Cells["clmaddContactNumber"].Value = DSorlist.Rows[i]["ContactNumber"];
                dgvAddEmpList.Rows[i].Cells["clmaddGender"].Value = DSorlist.Rows[i]["Gender"];
                dgvAddEmpList.Rows[i].Cells["clmaddDepartment"].Value = DSorlist.Rows[i]["Department"];
                dgvAddEmpList.Rows[i].Cells["clmaddPosition"].Value = DSorlist.Rows[i]["Position"];
                dgvAddEmpList.Rows[i].Cells["clmaddEmploymentType"].Value = DSorlist.Rows[i]["EmploymentType"];
                dgvAddEmpList.Rows[i].Cells["clmaddDateOfBirth"].Value = DSorlist.Rows[i]["DateOfBirth"];
                dgvAddEmpList.Rows[i].Cells["clmDateaddOfEmployment"].Value = DSorlist.Rows[i]["DateOfEmployment"];
                dgvAddEmpList.Rows[i].Cells["clmaddDailyWage"].Value = DSorlist.Rows[i]["DailyWage"];
                dgvAddEmpList.Rows[i].Cells["clmaddPhoto"].Value = DSorlist.Rows[i]["Photo"];
                dgvAddEmpList.Rows[i].Cells["clmaddEdit"].Value = "Edit";
                dgvAddEmpList.Rows[i].Cells["clmaddDelete"].Value = "Delete";
            }
            globalnames.con.Close();
            dgvAddEmpList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvAddEmpList.RowsDefaultCellStyle.BackColor = Color.Azure;
            dgvAddEmpList.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Beige;
        }
        public static void ShowGridToTextbox(PictureBox picpersonalphoto, DataGridView dataGridView, TextBox txtEmployeeID, TextBox txtFirstName, TextBox txtMiddleName, TextBox txtLastName,
            DateTimePicker dateTimePickerEmploymentDate, DateTimePicker dateTimePickerBirthDate, TextBox txtAddress, TextBox txtContactNumber,Label lbldbid,TextBox txtDailyWage,
            ComboBox cbEmploymentType, ComboBox cbGender, ComboBox cbDepartment, ComboBox cbPosition)
        {
            if (null == dataGridView.CurrentRow.Cells["clmdbid"].Value)
            {
                lbldbid.Text = "0";
            }
            else
            {
                lbldbid.Text = dataGridView.CurrentRow.Cells["clmdbid"].Value.ToString();
            }
            if (null == dataGridView.CurrentRow.Cells["clmaddID"].Value)
            {
                txtEmployeeID.Text = "";
            }
            else
            {
                txtEmployeeID.Text = dataGridView.CurrentRow.Cells["clmaddID"].Value.ToString();
            }
            if (null == dataGridView.CurrentRow.Cells["clmaddFirstName"].Value)
            {
                txtFirstName.Text = "";
            }
            else
            {
                txtFirstName.Text = dataGridView.CurrentRow.Cells["clmaddFirstName"].Value.ToString();
            }
            if (null == dataGridView.CurrentRow.Cells["clmaddMiddleName"].Value)
            {
                txtMiddleName.Text = "";
            }
            else
            {
                txtMiddleName.Text = dataGridView.CurrentRow.Cells["clmaddMiddleName"].Value.ToString();
            }
            if (null == dataGridView.CurrentRow.Cells["clmaddLastName"].Value)
            {
                txtLastName.Text = "";
            }
            else
            {
                txtLastName.Text = dataGridView.CurrentRow.Cells["clmaddLastName"].Value.ToString();
            }
            if (null == dataGridView.CurrentRow.Cells["clmDateaddOfEmployment"].Value)
            {
                dateTimePickerEmploymentDate.Value = DateTime.Now;
            }
            else
            {
                dateTimePickerEmploymentDate.Value = Convert.ToDateTime(dataGridView.CurrentRow.Cells["clmDateaddOfEmployment"].Value);
            }
            if (null == dataGridView.CurrentRow.Cells["clmaddDateOfBirth"].Value)
            {
                dateTimePickerBirthDate.Value = DateTime.Now;
            }
            else
            {
                dateTimePickerBirthDate.Value = Convert.ToDateTime(dataGridView.CurrentRow.Cells["clmaddDateOfBirth"].Value);
            }
            if (null == dataGridView.CurrentRow.Cells["clmaddAddress"].Value)
            {
                txtAddress.Text = "";
            }
            else
            {
                txtAddress.Text = dataGridView.CurrentRow.Cells["clmaddAddress"].Value.ToString();
            }
            if (null == dataGridView.CurrentRow.Cells["clmaddContactNumber"].Value)
            {
                txtContactNumber.Text = "";
            }
            else
            {
                txtContactNumber.Text = dataGridView.CurrentRow.Cells["clmaddContactNumber"].Value.ToString();
            }
            if (null == dataGridView.CurrentRow.Cells["clmaddDailyWage"].Value)
            {
                txtDailyWage.Text = "";
            }
            else
            {
                txtDailyWage.Text = dataGridView.CurrentRow.Cells["clmaddDailyWage"].Value.ToString();
            }
            if (DBNull.Value.Equals(dataGridView.CurrentRow.Cells["clmaddPhoto"].Value))
            {
                picpersonalphoto.Image = null;
            }
            else
            {
                var data = (Byte[])(dataGridView.CurrentRow.Cells["clmaddPhoto"].Value);
                var stream = new MemoryStream(data);
                picpersonalphoto.Image = Image.FromStream(stream);
            }
            if (null == dataGridView.CurrentRow.Cells["clmaddEmploymentType"].Value)
            {
                cbEmploymentType.SelectedIndex = -1;
            }
            else
            {
                cbEmploymentType.Text = dataGridView.CurrentRow.Cells["clmaddEmploymentType"].Value.ToString();
            }
            if (null == dataGridView.CurrentRow.Cells["clmaddGender"].Value)
            {
                cbGender.SelectedIndex = -1;
            }
            else
            {
                cbGender.Text = dataGridView.CurrentRow.Cells["clmaddGender"].Value.ToString();
            }
            if (null == dataGridView.CurrentRow.Cells["clmaddDepartment"].Value)
            {
                cbDepartment.SelectedIndex = -1;
            }
            else
            {
                cbDepartment.Text = dataGridView.CurrentRow.Cells["clmaddDepartment"].Value.ToString();
            }
            if (null == dataGridView.CurrentRow.Cells["clmaddPosition"].Value)
            {
                cbPosition.SelectedIndex = -1;
            }
            else
            {
                cbPosition.Text = dataGridView.CurrentRow.Cells["clmaddPosition"].Value.ToString();
            }
        }
        public static void DeleteEmployee(int dbid)
        {
            SqlCommand command = new SqlCommand();
            globalnames.con.Open();
            command.Connection = globalnames.con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Delete_Employee";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@DBID", dbid));
            command.ExecuteNonQuery();
            globalnames.con.Close();
        }
        public static void LoadEmployeeName(TextBox textauto1)
        {
            if (textauto1.Text.Length < 2)
            {

            }
            else
            {
                AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
                globalnames.SQLQuery = string.Empty;
                globalnames.SQLQuery = "SELECT ID FROM Employees";
                globalnames.da = new SqlDataAdapter(globalnames.SQLQuery, globalnames.con);
                DataTable ds = new DataTable();
                globalnames.da.Fill(ds);
                namesCollection.Clear();
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    namesCollection.Add(ds.Rows[i]["ID"].ToString());
                }
                textauto1.AutoCompleteMode = AutoCompleteMode.Suggest;
                textauto1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textauto1.AutoCompleteCustomSource = namesCollection;
                //globalnames.con.Close();
            }
        }
        public static void GetEmployeeByID(string EmpID, TextBox txtPEmployeeName,TextBox txtemployeeposition,TextBox txtemployeetype,TextBox txtPRateperday,TextBox txtPNoDays)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                SqlDataAdapter adapter;
                DataTable DSorlist = new DataTable();
                globalnames.con.Open();
                command.Connection = globalnames.con;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Get_Employee_By_ID";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@ID", EmpID));
                adapter = new SqlDataAdapter(command);
                DSorlist.Clear();
                adapter.Fill(DSorlist);
                globalnames.con.Close();
                txtPEmployeeName.Text = "";
                txtemployeeposition.Text = "";
                txtemployeetype.Text = "";
                txtPRateperday.Text = "";
                txtPNoDays.Text = "";
                if (DSorlist.Rows.Count > 0) {
                    foreach (DataRow row in DSorlist.Rows)
                    {
                        txtPEmployeeName.Text = row["Fullname"].ToString();
                        txtemployeeposition.Text = row["Position"].ToString();
                        txtemployeetype.Text = row["EmploymentType"].ToString();
                        txtPRateperday.Text = row["DailyWage"].ToString();
                        txtPNoDays.Text = row["NoDays"].ToString();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } 
           
        }
    }
}
