namespace LifeLineBloodBank.Forms
{
    partial class UpdateDonor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.DAddressTbl = new System.Windows.Forms.TextBox();
            this.DBGroupCB = new System.Windows.Forms.ComboBox();
            this.DGenderCB = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.DPhone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.DAgeTb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.DNameTb = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DonorDGV = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DonorDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(374, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 38);
            this.label1.TabIndex = 57;
            this.label1.Text = "Donor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(38, 168);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 20);
            this.label16.TabIndex = 56;
            this.label16.Text = "Address";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DAddressTbl
            // 
            this.DAddressTbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.DAddressTbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DAddressTbl.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DAddressTbl.Location = new System.Drawing.Point(114, 171);
            this.DAddressTbl.Multiline = true;
            this.DAddressTbl.Name = "DAddressTbl";
            this.DAddressTbl.Size = new System.Drawing.Size(163, 20);
            this.DAddressTbl.TabIndex = 2;
            // 
            // DBGroupCB
            // 
            this.DBGroupCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.DBGroupCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DBGroupCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DBGroupCB.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DBGroupCB.FormattingEnabled = true;
            this.DBGroupCB.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
            this.DBGroupCB.Location = new System.Drawing.Point(712, 171);
            this.DBGroupCB.Name = "DBGroupCB";
            this.DBGroupCB.Size = new System.Drawing.Size(163, 24);
            this.DBGroupCB.TabIndex = 54;
            this.DBGroupCB.TabStop = false;
            // 
            // DGenderCB
            // 
            this.DGenderCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.DGenderCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DGenderCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DGenderCB.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGenderCB.FormattingEnabled = true;
            this.DGenderCB.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.DGenderCB.Location = new System.Drawing.Point(712, 93);
            this.DGenderCB.Name = "DGenderCB";
            this.DGenderCB.Size = new System.Drawing.Size(163, 24);
            this.DGenderCB.TabIndex = 53;
            this.DGenderCB.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(645, 174);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 20);
            this.label15.TabIndex = 52;
            this.label15.Text = "Group";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(636, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 20);
            this.label14.TabIndex = 51;
            this.label14.Text = "Gender";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(320, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 20);
            this.label12.TabIndex = 50;
            this.label12.Text = "Number";
            // 
            // DPhone
            // 
            this.DPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.DPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DPhone.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DPhone.Location = new System.Drawing.Point(441, 93);
            this.DPhone.Multiline = true;
            this.DPhone.Name = "DPhone";
            this.DPhone.Size = new System.Drawing.Size(163, 20);
            this.DPhone.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(320, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 20);
            this.label11.TabIndex = 48;
            this.label11.Text = "Age";
            // 
            // DAgeTb
            // 
            this.DAgeTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.DAgeTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DAgeTb.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DAgeTb.Location = new System.Drawing.Point(441, 171);
            this.DAgeTb.Multiline = true;
            this.DAgeTb.Name = "DAgeTb";
            this.DAgeTb.Size = new System.Drawing.Size(163, 20);
            this.DAgeTb.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(38, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 20);
            this.label13.TabIndex = 46;
            this.label13.Text = "Name";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DNameTb
            // 
            this.DNameTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.DNameTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DNameTb.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DNameTb.Location = new System.Drawing.Point(114, 93);
            this.DNameTb.Multiline = true;
            this.DNameTb.Name = "DNameTb";
            this.DNameTb.Size = new System.Drawing.Size(163, 20);
            this.DNameTb.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(297, 239);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 33);
            this.button2.TabIndex = 58;
            this.button2.TabStop = false;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(455, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 33);
            this.button1.TabIndex = 59;
            this.button1.TabStop = false;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DonorDGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DonorDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DonorDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DonorDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DonorDGV.ColumnHeadersHeight = 28;
            this.DonorDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DonorDGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.DonorDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DonorDGV.Location = new System.Drawing.Point(26, 297);
            this.DonorDGV.Name = "DonorDGV";
            this.DonorDGV.ReadOnly = true;
            this.DonorDGV.RowHeadersVisible = false;
            this.DonorDGV.Size = new System.Drawing.Size(849, 290);
            this.DonorDGV.TabIndex = 60;
            this.DonorDGV.TabStop = false;
            this.DonorDGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DonorDGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DonorDGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DonorDGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DonorDGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DonorDGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DonorDGV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DonorDGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Red;
            this.DonorDGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DonorDGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonorDGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DonorDGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DonorDGV.ThemeStyle.HeaderStyle.Height = 28;
            this.DonorDGV.ThemeStyle.ReadOnly = true;
            this.DonorDGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DonorDGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DonorDGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonorDGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DonorDGV.ThemeStyle.RowsStyle.Height = 22;
            this.DonorDGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Red;
            this.DonorDGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DonorDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DonorDGV_CellContentClick);
            // 
            // UpdateDonor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 619);
            this.Controls.Add(this.DonorDGV);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.DAddressTbl);
            this.Controls.Add(this.DBGroupCB);
            this.Controls.Add(this.DGenderCB);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.DPhone);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DAgeTb);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.DNameTb);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.Name = "UpdateDonor";
            this.Text = "UpdateDonor";
            this.Load += new System.EventHandler(this.UpdateDonor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DonorDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox DAddressTbl;
        private System.Windows.Forms.ComboBox DBGroupCB;
        private System.Windows.Forms.ComboBox DGenderCB;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox DPhone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox DAgeTb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox DNameTb;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2DataGridView DonorDGV;
    }
}