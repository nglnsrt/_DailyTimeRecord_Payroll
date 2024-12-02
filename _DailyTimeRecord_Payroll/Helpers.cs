using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DailyTimeRecord_Payroll
{
    internal class Helpers
    {
        public static void ClearForm(TextBox txtEmployeeID, TextBox txtFirstName, TextBox txtMiddleName, 
            TextBox txtLastName, TextBox txtContactNumber, TextBox txtAddress, 
            DateTimePicker dateTimePickerEmploymentDate,ComboBox cbGender, ComboBox cbPosition, 
            ComboBox cbDepartment, ComboBox cbEmploymentType, PictureBox employeePictureBox, 
            DateTimePicker dateTimePickerBirthDate, TextBox txtDailyWage, 
            DataGridView dataGridView, PictureBox fingerImage)
        {
            txtEmployeeID.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtContactNumber.Clear();
            txtAddress.Clear();
            txtDailyWage.Text = "0.00";
            dateTimePickerEmploymentDate.Value = DateTime.Now;
            cbGender.SelectedIndex = 0;
            cbPosition.SelectedIndex = 0;
            cbDepartment.SelectedIndex = 0;
            cbEmploymentType.SelectedIndex = 0;
            employeePictureBox.Image = null;
            fingerImage.Image = null;
            dateTimePickerBirthDate.Value = DateTime.Now;
            dataGridView.Rows.Clear();
            txtFirstName.Focus();
        }

        public static void LoadDepartment(ComboBox cboDepartment)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter;
            DataTable DSorlist = new DataTable();
            globalnames.con.Open();
            command.Connection = globalnames.con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Load_Department";
            command.Parameters.Clear();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(DSorlist);
            cboDepartment.Items.Clear();
            for (int i = 0; i < DSorlist.Rows.Count; i++)
            {
                cboDepartment.Items.Add(DSorlist.Rows[i]["Name"]);
            }
            globalnames.con.Close();
            cboDepartment.SelectedIndex = 0;
        }

        public static void LoadPosition(ComboBox cboPosition)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter;
            DataTable DSorlist = new DataTable();
            globalnames.con.Open();
            command.Connection = globalnames.con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Load_Position";
            command.Parameters.Clear();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(DSorlist);
            cboPosition.Items.Clear();
            for (int i = 0; i < DSorlist.Rows.Count; i++)
            {
                cboPosition.Items.Add(DSorlist.Rows[i]["Name"]);
            }
            globalnames.con.Close();
            cboPosition.SelectedIndex = 0;
        }
        public static void clearTxt(Control container)
        {
            try
            {
                //'for each txt as control in this(object).control
                foreach (Control txt in container.Controls)
                {
                    //conditioning the txt as control by getting it's type.
                    //the type of txt as control must be textbox.
                    if (txt is TextBox)
                    {
                        //if the object(textbox) is present. The result is, the textbox will be cleared.
                        txt.Text = "";
                    }
                    if (txt is RichTextBox)
                    {
                        txt.Text = "";
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
