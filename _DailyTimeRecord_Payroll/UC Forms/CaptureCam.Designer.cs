namespace _DailyTimeRecord_Payroll.UC_Forms
{
    partial class CaptureCam
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btncapturephotopersonal = new System.Windows.Forms.Button();
            this.vbocamerapersonal = new System.Windows.Forms.ComboBox();
            this.picpersonalphotocam = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picpersonalphotocam)).BeginInit();
            this.SuspendLayout();
            // 
            // btncapturephotopersonal
            // 
            this.btncapturephotopersonal.BackColor = System.Drawing.Color.SeaGreen;
            this.btncapturephotopersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncapturephotopersonal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncapturephotopersonal.ForeColor = System.Drawing.Color.White;
            this.btncapturephotopersonal.Location = new System.Drawing.Point(39, 219);
            this.btncapturephotopersonal.Name = "btncapturephotopersonal";
            this.btncapturephotopersonal.Size = new System.Drawing.Size(150, 32);
            this.btncapturephotopersonal.TabIndex = 152;
            this.btncapturephotopersonal.Text = "Capture";
            this.btncapturephotopersonal.UseVisualStyleBackColor = false;
            this.btncapturephotopersonal.Click += new System.EventHandler(this.btncapturephotopersonal_Click);
            // 
            // vbocamerapersonal
            // 
            this.vbocamerapersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vbocamerapersonal.FormattingEnabled = true;
            this.vbocamerapersonal.Location = new System.Drawing.Point(39, 183);
            this.vbocamerapersonal.Name = "vbocamerapersonal";
            this.vbocamerapersonal.Size = new System.Drawing.Size(150, 21);
            this.vbocamerapersonal.TabIndex = 154;
            // 
            // picpersonalphotocam
            // 
            this.picpersonalphotocam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picpersonalphotocam.Location = new System.Drawing.Point(39, 27);
            this.picpersonalphotocam.Name = "picpersonalphotocam";
            this.picpersonalphotocam.Size = new System.Drawing.Size(150, 150);
            this.picpersonalphotocam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picpersonalphotocam.TabIndex = 153;
            this.picpersonalphotocam.TabStop = false;
            // 
            // CaptureCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 280);
            this.Controls.Add(this.btncapturephotopersonal);
            this.Controls.Add(this.vbocamerapersonal);
            this.Controls.Add(this.picpersonalphotocam);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptureCam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capture Cam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CaptureCam_FormClosing);
            this.Load += new System.EventHandler(this.CaptureCam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picpersonalphotocam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btncapturephotopersonal;
        private System.Windows.Forms.ComboBox vbocamerapersonal;
        private System.Windows.Forms.PictureBox picpersonalphotocam;
    }
}