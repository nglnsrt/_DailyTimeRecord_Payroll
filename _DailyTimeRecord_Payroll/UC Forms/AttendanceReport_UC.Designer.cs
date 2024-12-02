namespace _DailyTimeRecord_Payroll.User_Controls
{
    partial class AttendanceReport_UC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceReport_UC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAttendanceReportDescription = new System.Windows.Forms.Label();
            this.AttendancePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSearchIcon = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewEmployeeList = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeOfEmployment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeShift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMExit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PMEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PMExit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AttendancePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "ATTENDANCE REPORT";
            // 
            // lblAttendanceReportDescription
            // 
            this.lblAttendanceReportDescription.AutoSize = true;
            this.lblAttendanceReportDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttendanceReportDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAttendanceReportDescription.Location = new System.Drawing.Point(3, 10);
            this.lblAttendanceReportDescription.Name = "lblAttendanceReportDescription";
            this.lblAttendanceReportDescription.Size = new System.Drawing.Size(277, 22);
            this.lblAttendanceReportDescription.TabIndex = 16;
            this.lblAttendanceReportDescription.Text = "Detailed Attendance Report for....";
            // 
            // AttendancePanel
            // 
            this.AttendancePanel.Controls.Add(this.panel1);
            this.AttendancePanel.Controls.Add(this.lblAttendanceReportDescription);
            this.AttendancePanel.Location = new System.Drawing.Point(22, 60);
            this.AttendancePanel.Name = "AttendancePanel";
            this.AttendancePanel.Size = new System.Drawing.Size(1251, 721);
            this.AttendancePanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btnSearchIcon);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1251, 674);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Beige;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(1123, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 33;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(502, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "Sort By";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Name",
            "Department"});
            this.comboBox2.Location = new System.Drawing.Point(491, 7);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(108, 24);
            this.comboBox2.TabIndex = 31;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1187, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 34);
            this.button3.TabIndex = 28;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(191, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(37, 23);
            this.button4.TabIndex = 30;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnSearchIcon
            // 
            this.btnSearchIcon.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchIcon.BackgroundImage")));
            this.btnSearchIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchIcon.ForeColor = System.Drawing.Color.Beige;
            this.btnSearchIcon.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSearchIcon.Location = new System.Drawing.Point(1071, 2);
            this.btnSearchIcon.Name = "btnSearchIcon";
            this.btnSearchIcon.Size = new System.Drawing.Size(30, 30);
            this.btnSearchIcon.TabIndex = 26;
            this.btnSearchIcon.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(8, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 22);
            this.txtSearch.TabIndex = 29;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(234, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(228, 22);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1251, 638);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewEmployeeList);
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1251, 586);
            this.panel3.TabIndex = 0;
            // 
            // dataGridViewEmployeeList
            // 
            this.dataGridViewEmployeeList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridViewEmployeeList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEmployeeList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewEmployeeList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEmployeeList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployeeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.typeOfEmployment,
            this.employeeShift,
            this.employeeDepartment,
            this.AMEntry,
            this.AMExit,
            this.Status,
            this.PMEntry,
            this.PMExit,
            this.statusPM,
            this.totalHour,
            this.action});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEmployeeList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewEmployeeList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewEmployeeList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewEmployeeList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewEmployeeList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewEmployeeList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEmployeeList.Name = "dataGridViewEmployeeList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEmployeeList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewEmployeeList.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewEmployeeList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewEmployeeList.RowTemplate.Height = 24;
            this.dataGridViewEmployeeList.Size = new System.Drawing.Size(1251, 586);
            this.dataGridViewEmployeeList.TabIndex = 5;
            this.dataGridViewEmployeeList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmployeeList_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 75;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.Width = 200;
            // 
            // typeOfEmployment
            // 
            this.typeOfEmployment.HeaderText = "EmployementType";
            this.typeOfEmployment.MinimumWidth = 6;
            this.typeOfEmployment.Name = "typeOfEmployment";
            this.typeOfEmployment.Width = 125;
            // 
            // employeeShift
            // 
            this.employeeShift.HeaderText = "Shift";
            this.employeeShift.MinimumWidth = 6;
            this.employeeShift.Name = "employeeShift";
            this.employeeShift.Width = 125;
            // 
            // employeeDepartment
            // 
            this.employeeDepartment.HeaderText = "Department";
            this.employeeDepartment.MinimumWidth = 6;
            this.employeeDepartment.Name = "employeeDepartment";
            this.employeeDepartment.Width = 125;
            // 
            // AMEntry
            // 
            this.AMEntry.HeaderText = "AM Entry";
            this.AMEntry.MinimumWidth = 6;
            this.AMEntry.Name = "AMEntry";
            this.AMEntry.Width = 50;
            // 
            // AMExit
            // 
            this.AMExit.HeaderText = "AM Exit";
            this.AMExit.MinimumWidth = 6;
            this.AMExit.Name = "AMExit";
            this.AMExit.Width = 50;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.Width = 75;
            // 
            // PMEntry
            // 
            this.PMEntry.HeaderText = "PM Entry";
            this.PMEntry.MinimumWidth = 6;
            this.PMEntry.Name = "PMEntry";
            this.PMEntry.Width = 50;
            // 
            // PMExit
            // 
            this.PMExit.HeaderText = "PM Exit";
            this.PMExit.MinimumWidth = 6;
            this.PMExit.Name = "PMExit";
            this.PMExit.Width = 50;
            // 
            // statusPM
            // 
            this.statusPM.HeaderText = "Status";
            this.statusPM.MinimumWidth = 6;
            this.statusPM.Name = "statusPM";
            this.statusPM.Width = 75;
            // 
            // totalHour
            // 
            this.totalHour.HeaderText = "Total Hour";
            this.totalHour.MinimumWidth = 6;
            this.totalHour.Name = "totalHour";
            this.totalHour.Width = 125;
            // 
            // action
            // 
            this.action.HeaderText = "Action";
            this.action.MinimumWidth = 6;
            this.action.Name = "action";
            this.action.Width = 125;
            // 
            // AttendanceReport_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AttendancePanel);
            this.Name = "AttendanceReport_UC";
            this.Size = new System.Drawing.Size(1328, 781);
            this.AttendancePanel.ResumeLayout(false);
            this.AttendancePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAttendanceReportDescription;
        private System.Windows.Forms.Panel AttendancePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridViewEmployeeList;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnSearchIcon;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeOfEmployment;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeShift;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn PMEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn PMExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalHour;
        private System.Windows.Forms.DataGridViewComboBoxColumn action;
    }
}
