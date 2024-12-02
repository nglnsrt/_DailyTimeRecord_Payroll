using _DailyTimeRecord_Payroll.DataAccess;
using _DailyTimeRecord_Payroll.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DailyTimeRecord_Payroll.User_Controls
{
    public partial class AddEmployee_UC : UserControl
    {
        private readonly IEmployeeRepository employeeRepository;
        private string connectionString = "Data Source = LAPTOP-5QOID5GC\\SQLEXPRESS;Initial Catalog=DTR;Integrated Security=True";
        private Dictionary<string, List<string>> departmentPositions = new Dictionary<string, List<string>>()

        {
            {"Front Office", new List<string>{"Front Desk Agent", "Concierge", " Night Auditor", "Receptionist"} },
            {"Housekeeping", new List<string>{"Room Attendant", "Laundry Attendant", "Public Area Attendant", "Executive Housekeeper"} },
            {"Food and Beverage", new List<string>{"Chef", "Sous Chef", "Server","Bartender","Restaurant Manager" } },
            {"Sales and Marketing", new List<string>{"Sales Manager", "Marketing Manager", "Event Planner","Sales Coordinator"} },
            {"Events and Banquets", new List<string>{"Banquet Manager", "Banquet Server","Event Coordinator"} },
            {"Human Resource", new List<string>{"HR Manager"} },
            {"Maintenance", new List<string>{"Chief Engineer", "Maintenance Technician", "Electrician", "Plumber"} },
            {"Finance", new List<string>{"Accountant"} },
            {"Security", new List<string>{"Security Officer", "Security Supervisor"} },
            {"Recreational & Activities", new List<string>{"Recreational Manager","Spa Manager", "Life Guard"} },
            {"IT", new List<string>{"IT Manager", "System Administrator","Help Desk Technician","Network Engineer"} }
        };
        
        public AddEmployee_UC()
        {
            InitializeComponent();
            //Add items on cbDepartment
            cbDepartment.Items.AddRange(departmentPositions.Keys.ToArray());
            //Set the event handler for when a department is selected
            cbDepartment.SelectedIndexChanged += DepartmentComboBox_SelectedIndexChanged;
            employeeRepository = new EmployeeRepository();
        }
        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {      
            try
            {
                if (cbDepartment.SelectedIndex != -1 && cbDepartment.SelectedItem!=null)
                {
                    //clear the cbPosition                                                                  
                    cbPosition.Items.Clear();

                    //get the selected department    
                    string selectedDepartment = cbDepartment.SelectedItem.ToString();
                    //check if the department exist in the dictionary
                    if (departmentPositions.ContainsKey(selectedDepartment))
                    {
                        //add relevant positions to the cbPosition based on the selected department
                        cbPosition.Items.AddRange(departmentPositions[selectedDepartment].ToArray());
                        

                        if (cbPosition.Items.Count > 0)
                        {
                            cbPosition.SelectedIndex = 0;// default selection to first item
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid department.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("An item selection error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        private event Action<string, string, string, string> EmployeeAdded;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {          
                //get values from the input fields
                string employeeID = txtEmployeeID.Text;
                string firstName = txtFirstName.Text;
                string middleName = txtMiddleName.Text;
                string lastName = txtLastName.Text;
                string address = txtAddress.Text;
                string contactNumber = txtContactNumber.Text;
                string gender = cbGender.SelectedItem?.ToString();
                string department = cbDepartment.SelectedItem?.ToString();
                string position = cbPosition.SelectedItem?.ToString();
                string employmentType = cbEmploymentType.SelectedItem?.ToString();
                string dailyWage = txtDailyWage.Text;
                DateTime employmentDate = dateTimePickerEmploymentDate.Value;
                DateTime birthDate = dateTimePickerBirthDate.Value;

                if (string.IsNullOrEmpty(txtEmployeeID.Text) ||
                   string.IsNullOrEmpty(txtFirstName.Text) ||
                   string.IsNullOrEmpty(txtMiddleName.Text) ||
                   string.IsNullOrEmpty(txtLastName.Text) ||
                   string.IsNullOrEmpty(txtAddress.Text) ||
                   string.IsNullOrEmpty(txtContactNumber.Text) ||
                   string.IsNullOrEmpty(cbGender.SelectedItem?.ToString()) ||
                   string.IsNullOrEmpty(cbDepartment.SelectedItem?.ToString()) ||
                   string.IsNullOrEmpty(cbPosition.SelectedItem?.ToString()) ||
                   string.IsNullOrEmpty(cbEmploymentType.SelectedItem?.ToString()) ||
                   string.IsNullOrEmpty(txtDailyWage.Text) ||
                   dateTimePickerEmploymentDate.Value == DateTime.MinValue ||
                   dateTimePickerBirthDate.Value == DateTime.MinValue)
                {
                    MessageBox.Show("Please fill all fields.");
                    return;
                }

                byte[] photo = ConvertImageToByteArray(employeePictureBox.Image);

                if (employeePictureBox.Image != null)
                {
                    photo = ConvertImageToByteArray(employeePictureBox.Image);
                }
                else
                {
                    MessageBox.Show("Please upload a photo");
                    return;
                }

                bool success = SaveEmployeeToDatabase(employeeID, firstName, middleName, lastName, address, contactNumber, gender, department,
                    position, employmentType, employmentDate, birthDate, photo, dailyWage);

                if (success)
                {
                    EmployeeAdded?.Invoke(employeeID, $"{firstName}, {lastName}", department, employmentType);
                    MessageBox.Show("Employee added successfully!");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("An error occured while adding the employee.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //EmployeeList_UC employeeList = new EmployeeList_UC();
            //int rowIndex = dataGridViewEmployeeList.Rows.Add(employeeID, employeeName, department, employmentType, employmentDate, gender);
           // dataGridViewEmployeeList.Rows[rowIndex].Tag = new EmployeeDetails(employeeID, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, dateTimePickerEmploymentDate.Value, txtContactNumber.Text, txtAddress.Text, gender, department, cbPosition.Text, employmentType, photoPath););
        }
        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null)
                return null;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        private bool SaveEmployeeToDatabase(string employeeID, string firstName, string middleName, string lastName, string address, string contactNumber, string gender, string department, string position, string employmentType, DateTime employmentDate, DateTime birthdate, byte[] photo, string dailyWage)
        {
            string connectionString = "Server=LAPTOP-5QOID5GC\\SQLEXPRESS;Database=DTR;Trusted_Connection=True";
           
                    string query = @"INSERT INTO Employees(ID, FirstName, MiddleName, LastName, Address, ContactNumber, Gender, Department, Position, EmploymentType, DateOfBirth, DateOfEmployment, Photo, DailyWage)
                    VALUES (@ID, @FirstName, @MiddleName, @LastName, @Address, @ContactNumber, @Gender, @Department, @Position, @EmploymentType, @DateOfBirth, @DateOfEmployment, @Photo, @DailyWage)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", employeeID);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@MiddleName", middleName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Department", department);
                        cmd.Parameters.AddWithValue("@Position", position);
                        cmd.Parameters.AddWithValue("@EmploymentType", employmentType);
                        cmd.Parameters.AddWithValue("@DateOfEmployment", employmentDate);
                        cmd.Parameters.AddWithValue("@DateOfBirth", birthdate);
                        cmd.Parameters.AddWithValue("@DailyWage", dailyWage);
                        cmd.Parameters.AddWithValue("@Photo", (object)photo?? DBNull.Value);
                        
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
        private void ClearForm()
        {
            txtEmployeeID.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtContactNumber.Clear();
            txtAddress.Clear();
            dateTimePickerEmploymentDate.Value = DateTime.Now;
            cbGender.SelectedIndex = -1;
            cbPosition.SelectedIndex = -1;
            cbDepartment.SelectedIndex = -1;
            cbEmploymentType.SelectedIndex = -1;
            employeePictureBox.Image = null;
            dateTimePickerBirthDate.Value = DateTime.Now;
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    employeePictureBox.Image = Image.FromFile(openFileDialog.FileName);
                    employeePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    employeePictureBox.Tag = openFileDialog.FileName;
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtContactNumber.Clear();
            txtAddress.Clear();
            dateTimePickerEmploymentDate.Value = DateTime.Now;
            cbGender.SelectedIndex = -1;
            cbPosition.SelectedIndex = -1;
            cbDepartment.SelectedIndex = -1;
            cbEmploymentType.SelectedIndex = -1;
            employeePictureBox.Image = null;
            dateTimePickerBirthDate.Value = DateTime.Now;
            txtDailyWage.Clear();
        }
       
        private void AddEmployee_UC_Load(object sender, EventArgs e)
        {

        }
        //private bool ValidateFields()
        //{
        //    return !string.IsNullOrEmpty(txtEmployeeID.Text)&&!string.IsNullOrEmpty(txtFirstName.Text) &&!string.IsNullOrEmpty(txtMiddleName.Text)&&!string.IsNullOrEmpty(txtAddress.Text)&&!string.IsNullOrEmpty(txtContactNumber.Text)&&!string.IsNullOrEmpty(txtDailyWage.Text);
        //}
        private void btnViewEmployee_Click(object sender, EventArgs e)
        {
            EmployeeList_UC employeeList_UC = new EmployeeList_UC();
            employeeList_UC.Show();
        }
    }
}
