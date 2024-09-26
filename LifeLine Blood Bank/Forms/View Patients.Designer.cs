namespace LifeLineBloodBank
{
    partial class View_Patients
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            button1 = new Button();
            PNameTb = new TextBox();
            PPhoneTb = new TextBox();
            PAgeTb = new TextBox();
            PBGroupCb = new ComboBox();
            PGenderCb = new ComboBox();
            PAdressTb = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button2 = new Button();
            sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            label8 = new Label();
            PDListCb = new ComboBox();
            label9 = new Label();
            PWNoCb = new ComboBox();
            label10 = new Label();
            PBNoCb = new ComboBox();
            PatientsDGV = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)PatientsDGV).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Green;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Century", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(298, 288);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(96, 39);
            button1.TabIndex = 29;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // PNameTb
            // 
            PNameTb.BackColor = Color.FromArgb(230, 231, 233);
            PNameTb.BorderStyle = BorderStyle.None;
            PNameTb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PNameTb.Location = new Point(92, 104);
            PNameTb.Margin = new Padding(2);
            PNameTb.Multiline = true;
            PNameTb.Name = "PNameTb";
            PNameTb.Size = new Size(177, 26);
            PNameTb.TabIndex = 28;
            // 
            // PPhoneTb
            // 
            PPhoneTb.BackColor = Color.FromArgb(230, 231, 233);
            PPhoneTb.BorderStyle = BorderStyle.None;
            PPhoneTb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PPhoneTb.Location = new Point(611, 104);
            PPhoneTb.Margin = new Padding(2);
            PPhoneTb.Multiline = true;
            PPhoneTb.Name = "PPhoneTb";
            PPhoneTb.Size = new Size(177, 26);
            PPhoneTb.TabIndex = 27;
            // 
            // PAgeTb
            // 
            PAgeTb.BackColor = Color.FromArgb(230, 231, 233);
            PAgeTb.BorderStyle = BorderStyle.None;
            PAgeTb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PAgeTb.Location = new Point(353, 104);
            PAgeTb.Margin = new Padding(2);
            PAgeTb.Multiline = true;
            PAgeTb.Name = "PAgeTb";
            PAgeTb.Size = new Size(177, 26);
            PAgeTb.TabIndex = 26;
            // 
            // PBGroupCb
            // 
            PBGroupCb.BackColor = Color.FromArgb(230, 231, 233);
            PBGroupCb.FlatStyle = FlatStyle.Flat;
            PBGroupCb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PBGroupCb.FormattingEnabled = true;
            PBGroupCb.Items.AddRange(new object[] { "A+", "O+", "B+", "AB+", "A-", "O-", "B-", "AB-" });
            PBGroupCb.Location = new Point(92, 176);
            PBGroupCb.Margin = new Padding(2);
            PBGroupCb.Name = "PBGroupCb";
            PBGroupCb.Size = new Size(177, 24);
            PBGroupCb.TabIndex = 25;
            // 
            // PGenderCb
            // 
            PGenderCb.BackColor = Color.FromArgb(230, 231, 233);
            PGenderCb.FlatStyle = FlatStyle.Flat;
            PGenderCb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PGenderCb.FormattingEnabled = true;
            PGenderCb.Items.AddRange(new object[] { "Male", "Female" });
            PGenderCb.Location = new Point(353, 176);
            PGenderCb.Margin = new Padding(2);
            PGenderCb.Name = "PGenderCb";
            PGenderCb.Size = new Size(177, 24);
            PGenderCb.TabIndex = 24;
            PGenderCb.SelectedIndexChanged += DGenderCb_SelectedIndexChanged;
            // 
            // PAdressTb
            // 
            PAdressTb.BackColor = Color.FromArgb(230, 231, 233);
            PAdressTb.BorderStyle = BorderStyle.None;
            PAdressTb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PAdressTb.Location = new Point(353, 245);
            PAdressTb.Margin = new Padding(2);
            PAdressTb.Multiline = true;
            PAdressTb.Name = "PAdressTb";
            PAdressTb.Size = new Size(177, 25);
            PAdressTb.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(353, 212);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(65, 20);
            label7.TabIndex = 22;
            label7.Text = "Adress";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(92, 138);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(112, 20);
            label6.TabIndex = 21;
            label6.Text = "Blood Group";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(611, 68);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 20;
            label5.Text = "Phone";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(353, 138);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 19;
            label4.Text = "Gender";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(353, 68);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 18;
            label3.Text = "Age";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(92, 68);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 17;
            label2.Text = "Name";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(318, 9);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(221, 38);
            label1.TabIndex = 15;
            label1.Text = "Patients List";
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Century", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(455, 288);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(96, 39);
            button2.TabIndex = 30;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
           
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(611, 212);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(146, 20);
            label8.TabIndex = 33;
            label8.Text = "Department List";
            label8.Click += label8_Click;
            // 
            // PDListCb
            // 
            PDListCb.BackColor = Color.FromArgb(230, 231, 233);
            PDListCb.FlatStyle = FlatStyle.Flat;
            PDListCb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PDListCb.FormattingEnabled = true;
            PDListCb.Items.AddRange(new object[] { "Cardiothoracic and Vascular Surgery", "Cardiology", "Critical Care Units", "Orthopedics", "Obstetrics and Gynaecology", "Paediatrics", "Urology", "General Medicine", "Ent", "Gastroenterology and Hepatology", "Nephrology", "General and Laparoscopic Surgery", "Endocrinology and Diabetology", "Neurology", "Psychiatry", "Neurosurgery", "Respiratory Medicine", "Radiology and Imaging", "Physical Medicine and Rehabilitation", "Internal Medicine", "Dental and Maxillofacial Surgery", "Oncology", "Diet Center", "Pathology", "Blood Transfusion", "General and Colorectal Surgery", "Hamotology", "Thoracic Surgery", "Accident and Emergency", "Aaesthesia", "Dermatology and Venereology", "Ophthalmology", "Breast and Colorectal Surgeon", "Burn and Plastic Surgery" });
            PDListCb.Location = new Point(611, 245);
            PDListCb.Margin = new Padding(2);
            PDListCb.Name = "PDListCb";
            PDListCb.Size = new Size(177, 24);
            PDListCb.TabIndex = 34;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Red;
            label9.Location = new Point(611, 138);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(82, 20);
            label9.TabIndex = 35;
            label9.Text = "Ward No";
            // 
            // PWNoCb
            // 
            PWNoCb.BackColor = Color.FromArgb(230, 231, 233);
            PWNoCb.FlatStyle = FlatStyle.Flat;
            PWNoCb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PWNoCb.FormattingEnabled = true;
            PWNoCb.Items.AddRange(new object[] { "M1-M20", "F1-F20" });
            PWNoCb.Location = new Point(611, 176);
            PWNoCb.Margin = new Padding(2);
            PWNoCb.Name = "PWNoCb";
            PWNoCb.Size = new Size(177, 24);
            PWNoCb.TabIndex = 36;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Red;
            label10.Location = new Point(92, 212);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 37;
            label10.Text = "Bed No";
            // 
            // PBNoCb
            // 
            PBNoCb.BackColor = Color.FromArgb(230, 231, 233);
            PBNoCb.FlatStyle = FlatStyle.Flat;
            PBNoCb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PBNoCb.FormattingEnabled = true;
            PBNoCb.Items.AddRange(new object[] { "F-1", "F-2", "F-3", "F-4", "F-5", "F-6", "F-7", "F-8", "F-8", "F-9", "F-10", "F-11", "F-12", "F-13", "F-14", "F-15", "F-16", "F-17", "F-18", "F-19", "F-20", "M-1", "M-2", "M-3", "M-4", "M-5", "M-6", "M-7", "M-8", "M-8", "M-9", "M-10", "M-11", "M-12", "M-13", "M-14", "M-15", "M-16", "M-17", "M-18", "M-19", "M-20" });
            PBNoCb.Location = new Point(92, 246);
            PBNoCb.Margin = new Padding(2);
            PBNoCb.Name = "PBNoCb";
            PBNoCb.Size = new Size(177, 24);
            PBNoCb.TabIndex = 38;
            // 
            // PatientsDGV
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            PatientsDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            PatientsDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            PatientsDGV.ColumnHeadersHeight = 28;
            PatientsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            PatientsDGV.DefaultCellStyle = dataGridViewCellStyle3;
            PatientsDGV.GridColor = Color.FromArgb(231, 229, 255);
            PatientsDGV.Location = new Point(12, 332);
            PatientsDGV.Name = "PatientsDGV";
            PatientsDGV.RowHeadersVisible = false;
            PatientsDGV.Size = new Size(874, 275);
            PatientsDGV.TabIndex = 39;
            PatientsDGV.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            PatientsDGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            PatientsDGV.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            PatientsDGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            PatientsDGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            PatientsDGV.ThemeStyle.BackColor = Color.White;
            PatientsDGV.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            PatientsDGV.ThemeStyle.HeaderStyle.BackColor = Color.Red;
            PatientsDGV.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            PatientsDGV.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            PatientsDGV.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            PatientsDGV.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            PatientsDGV.ThemeStyle.HeaderStyle.Height = 28;
            PatientsDGV.ThemeStyle.ReadOnly = false;
            PatientsDGV.ThemeStyle.RowsStyle.BackColor = Color.White;
            PatientsDGV.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            PatientsDGV.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            PatientsDGV.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            PatientsDGV.ThemeStyle.RowsStyle.Height = 25;
            PatientsDGV.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            PatientsDGV.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            PatientsDGV.CellContentClick += PatientsDGV_CellContentClick_1;
            // 
            // View_Patients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(898, 619);
            Controls.Add(PatientsDGV);
            Controls.Add(PBNoCb);
            Controls.Add(label10);
            Controls.Add(PWNoCb);
            Controls.Add(label9);
            Controls.Add(PDListCb);
            Controls.Add(label8);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(PNameTb);
            Controls.Add(PPhoneTb);
            Controls.Add(PAgeTb);
            Controls.Add(PBGroupCb);
            Controls.Add(PGenderCb);
            Controls.Add(PAdressTb);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "View_Patients";
            Text = "View_Patients";
            Load += View_Patients_Load;
            ((System.ComponentModel.ISupportInitialize)PatientsDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox PNameTb;
        private TextBox PPhoneTb;
        private TextBox PAgeTb;
        private ComboBox PBGroupCb;
        private ComboBox PGenderCb;
        private TextBox PAdressTb;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button2;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private Label label8;
        private ComboBox PDListCb;
        private Label label9;
        private ComboBox PWNoCb;
        private Label label10;
        private ComboBox PBNoCb;
        private Guna.UI2.WinForms.Guna2DataGridView PatientsDGV;
    }
}