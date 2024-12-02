namespace _DailyTimeRecord_Payroll.User_Controls
{
    partial class EmployeeList_UC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.employeeListPanelContent = new System.Windows.Forms.Panel();
            this.btnAddNewEmployee = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvEmployeeList = new System.Windows.Forms.DataGridView();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmActionTwo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmActionThree = new System.Windows.Forms.DataGridViewButtonColumn();
            this.employeeListPanelContent.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeListPanelContent
            // 
            this.employeeListPanelContent.Controls.Add(this.btnAddNewEmployee);
            this.employeeListPanelContent.Controls.Add(this.panel2);
            this.employeeListPanelContent.Controls.Add(this.label5);
            this.employeeListPanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeListPanelContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeListPanelContent.Location = new System.Drawing.Point(0, 0);
            this.employeeListPanelContent.Margin = new System.Windows.Forms.Padding(2);
            this.employeeListPanelContent.Name = "employeeListPanelContent";
            this.employeeListPanelContent.Size = new System.Drawing.Size(970, 635);
            this.employeeListPanelContent.TabIndex = 0;
            // 
            // btnAddNewEmployee
            // 
            this.btnAddNewEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddNewEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewEmployee.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewEmployee.ForeColor = System.Drawing.Color.White;
            this.btnAddNewEmployee.Location = new System.Drawing.Point(824, 598);
            this.btnAddNewEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNewEmployee.Name = "btnAddNewEmployee";
            this.btnAddNewEmployee.Size = new System.Drawing.Size(130, 32);
            this.btnAddNewEmployee.TabIndex = 21;
            this.btnAddNewEmployee.Text = "Add New Employee";
            this.btnAddNewEmployee.UseVisualStyleBackColor = false;
            this.btnAddNewEmployee.Click += new System.EventHandler(this.btnAddNewEmployee_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.dgvEmployeeList);
            this.panel2.Location = new System.Drawing.Point(16, 76);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(938, 518);
            this.panel2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(264, 35);
            this.label5.TabIndex = 4;
            this.label5.Text = "EMPLOYEE LIST";
            // 
            // dgvEmployeeList
            // 
            this.dgvEmployeeList.AllowUserToAddRows = false;
            this.dgvEmployeeList.AllowUserToDeleteRows = false;
            this.dgvEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmID,
            this.clmName,
            this.clmDepartment,
            this.clmType,
            this.clmAction,
            this.clmActionTwo,
            this.clmActionThree});
            this.dgvEmployeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployeeList.Location = new System.Drawing.Point(0, 0);
            this.dgvEmployeeList.Name = "dgvEmployeeList";
            this.dgvEmployeeList.ReadOnly = true;
            this.dgvEmployeeList.Size = new System.Drawing.Size(938, 518);
            this.dgvEmployeeList.TabIndex = 0;
            this.dgvEmployeeList.TabStop = false;
            // 
            // clmID
            // 
            this.clmID.HeaderText = "ID";
            this.clmID.Name = "clmID";
            this.clmID.ReadOnly = true;
            this.clmID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmName
            // 
            this.clmName.HeaderText = "Name";
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            this.clmName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmDepartment
            // 
            this.clmDepartment.HeaderText = "Department";
            this.clmDepartment.Name = "clmDepartment";
            this.clmDepartment.ReadOnly = true;
            this.clmDepartment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmType
            // 
            this.clmType.HeaderText = "Employee Type";
            this.clmType.Name = "clmType";
            this.clmType.ReadOnly = true;
            this.clmType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmType.Width = 130;
            // 
            // clmAction
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.clmAction.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clmAction.HeaderText = "";
            this.clmAction.Name = "clmAction";
            this.clmAction.ReadOnly = true;
            this.clmAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clmActionTwo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.clmActionTwo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmActionTwo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clmActionTwo.HeaderText = "";
            this.clmActionTwo.Name = "clmActionTwo";
            this.clmActionTwo.ReadOnly = true;
            this.clmActionTwo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clmActionThree
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.clmActionThree.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmActionThree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clmActionThree.HeaderText = "";
            this.clmActionThree.Name = "clmActionThree";
            this.clmActionThree.ReadOnly = true;
            this.clmActionThree.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // EmployeeList_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.employeeListPanelContent);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EmployeeList_UC";
            this.Size = new System.Drawing.Size(970, 635);
            this.Load += new System.EventHandler(this.EmployeeList_UC_Load);
            this.employeeListPanelContent.ResumeLayout(false);
            this.employeeListPanelContent.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel employeeListPanelContent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddNewEmployee;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvEmployeeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmType;
        private System.Windows.Forms.DataGridViewButtonColumn clmAction;
        private System.Windows.Forms.DataGridViewButtonColumn clmActionTwo;
        private System.Windows.Forms.DataGridViewButtonColumn clmActionThree;
    }
}
