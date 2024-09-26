namespace LifeLineBloodBank
{
    partial class Patient
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            PAdressTb = new TextBox();
            PGenderCb = new ComboBox();
            PBGroupCb = new ComboBox();
            PPhoneTb = new TextBox();
            PAgeTb = new TextBox();
            PNameTb = new TextBox();
            button1 = new Button();
            PDListCb = new ComboBox();
            label8 = new Label();
            PWNoCb = new ComboBox();
            label9 = new Label();
            label10 = new Label();
            PBNoCb = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(373, 31);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(133, 38);
            label1.TabIndex = 0;
            label1.Text = "Patient";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(48, 147);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 2;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(347, 153);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 3;
            label3.Text = "Age";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(48, 254);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 4;
            label4.Text = "Gender";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(655, 156);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 5;
            label5.Text = "Phone";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(347, 260);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(112, 20);
            label6.TabIndex = 6;
            label6.Text = "Blood Group";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(655, 366);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(65, 20);
            label7.TabIndex = 7;
            label7.Text = "Adress";
            // 
            // PAdressTb
            // 
            PAdressTb.BackColor = Color.FromArgb(230, 231, 233);
            PAdressTb.BorderStyle = BorderStyle.None;
            PAdressTb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PAdressTb.Location = new Point(655, 406);
            PAdressTb.Margin = new Padding(2);
            PAdressTb.Multiline = true;
            PAdressTb.Name = "PAdressTb";
            PAdressTb.Size = new Size(177, 27);
            PAdressTb.TabIndex = 8;
            // 
            // PGenderCb
            // 
            PGenderCb.BackColor = Color.FromArgb(230, 231, 233);
            PGenderCb.FlatStyle = FlatStyle.Flat;
            PGenderCb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PGenderCb.FormattingEnabled = true;
            PGenderCb.Items.AddRange(new object[] { "Male", "Female" });
            PGenderCb.Location = new Point(48, 294);
            PGenderCb.Margin = new Padding(2);
            PGenderCb.Name = "PGenderCb";
            PGenderCb.Size = new Size(177, 24);
            PGenderCb.TabIndex = 9;
            // 
            // PBGroupCb
            // 
            PBGroupCb.BackColor = Color.FromArgb(230, 231, 233);
            PBGroupCb.FlatStyle = FlatStyle.Flat;
            PBGroupCb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PBGroupCb.FormattingEnabled = true;
            PBGroupCb.Items.AddRange(new object[] { "A+", "O+", "B+", "AB+", "A-", "O-", "B-", "AB-" });
            PBGroupCb.Location = new Point(347, 300);
            PBGroupCb.Margin = new Padding(2);
            PBGroupCb.Name = "PBGroupCb";
            PBGroupCb.Size = new Size(177, 24);
            PBGroupCb.TabIndex = 10;
            // 
            // PPhoneTb
            // 
            PPhoneTb.BackColor = Color.FromArgb(230, 231, 233);
            PPhoneTb.BorderStyle = BorderStyle.None;
            PPhoneTb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PPhoneTb.Location = new Point(655, 199);
            PPhoneTb.Margin = new Padding(2);
            PPhoneTb.Multiline = true;
            PPhoneTb.Name = "PPhoneTb";
            PPhoneTb.Size = new Size(177, 26);
            PPhoneTb.TabIndex = 11;
            // 
            // PAgeTb
            // 
            PAgeTb.BackColor = Color.FromArgb(230, 231, 233);
            PAgeTb.BorderStyle = BorderStyle.None;
            PAgeTb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PAgeTb.Location = new Point(347, 196);
            PAgeTb.Margin = new Padding(2);
            PAgeTb.Multiline = true;
            PAgeTb.Name = "PAgeTb";
            PAgeTb.Size = new Size(177, 26);
            PAgeTb.TabIndex = 12;
            // 
            // PNameTb
            // 
            PNameTb.BackColor = Color.FromArgb(230, 231, 233);
            PNameTb.BorderStyle = BorderStyle.None;
            PNameTb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PNameTb.Location = new Point(48, 190);
            PNameTb.Margin = new Padding(2);
            PNameTb.Multiline = true;
            PNameTb.Name = "PNameTb";
            PNameTb.Size = new Size(177, 26);
            PNameTb.TabIndex = 13;
            // 
            // button1
            // 
            button1.BackColor = Color.LimeGreen;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Century", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(373, 489);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(96, 36);
            button1.TabIndex = 14;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // PDListCb
            // 
            PDListCb.BackColor = Color.FromArgb(230, 231, 233);
            PDListCb.FlatStyle = FlatStyle.Flat;
            PDListCb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PDListCb.FormattingEnabled = true;
            PDListCb.Items.AddRange(new object[] { "Cardiothoracic and Vascular Surgery", "Cardiology", "Critical Care Units", "Orthopedics", "Obstetrics and Gynaecology", "Paediatrics", "Urology", "General Medicine", "Ent", "Gastroenterology and Hepatology", "Nephrology", "General and Laparoscopic Surgery", "Endocrinology and Diabetology", "Neurology", "Psychiatry", "Neurosurgery", "Respiratory Medicine", "Radiology and Imaging", "Physical Medicine and Rehabilitation", "Internal Medicine", "Dental and Maxillofacial Surgery", "Oncology", "Diet Center", "Pathology", "Blood Transfusion", "General and Colorectal Surgery", "Hamotology", "Thoracic Surgery", "Accident and Emergency", "Aaesthesia", "Dermatology and Venereology", "Ophthalmology", "Breast and Colorectal Surgeon", "Burn and Plastic Surgery" });
            PDListCb.Location = new Point(655, 303);
            PDListCb.Margin = new Padding(2);
            PDListCb.Name = "PDListCb";
            PDListCb.Size = new Size(177, 24);
            PDListCb.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(655, 263);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(146, 20);
            label8.TabIndex = 16;
            label8.Text = "Department List";
            // 
            // PWNoCb
            // 
            PWNoCb.BackColor = Color.FromArgb(230, 231, 233);
            PWNoCb.FlatStyle = FlatStyle.Flat;
            PWNoCb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PWNoCb.FormattingEnabled = true;
            PWNoCb.Items.AddRange(new object[] { "M1-M20", "F1-F20" });
            PWNoCb.Location = new Point(48, 403);
            PWNoCb.Margin = new Padding(2);
            PWNoCb.Name = "PWNoCb";
            PWNoCb.Size = new Size(177, 24);
            PWNoCb.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Red;
            label9.Location = new Point(48, 357);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(82, 20);
            label9.TabIndex = 18;
            label9.Text = "Ward No";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Red;
            label10.Location = new Point(347, 363);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 19;
            label10.Text = "Bed No";
            // 
            // PBNoCb
            // 
            PBNoCb.BackColor = Color.FromArgb(230, 231, 233);
            PBNoCb.FlatStyle = FlatStyle.Flat;
            PBNoCb.Font = new Font("Century", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PBNoCb.FormattingEnabled = true;
            PBNoCb.Items.AddRange(new object[] { "F-1", "F-2", "F-3", "F-4", "F-5", "F-6", "F-7", "F-8", "F-8", "F-9", "F-10", "F-11", "F-12", "F-13", "F-14", "F-15", "F-16", "F-17", "F-18", "F-19", "F-20", "M-1", "M-2", "M-3", "M-4", "M-5", "M-6", "M-7", "M-8", "M-8", "M-9", "M-10", "M-11", "M-12", "M-13", "M-14", "M-15", "M-16", "M-17", "M-18", "M-19", "M-20", "" });
            PBNoCb.Location = new Point(347, 409);
            PBNoCb.Margin = new Padding(2);
            PBNoCb.Name = "PBNoCb";
            PBNoCb.Size = new Size(177, 24);
            PBNoCb.TabIndex = 20;
            // 
            // Patient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(898, 619);
            Controls.Add(PBNoCb);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(PWNoCb);
            Controls.Add(label8);
            Controls.Add(PDListCb);
            Controls.Add(button1);
            Controls.Add(PNameTb);
            Controls.Add(PAgeTb);
            Controls.Add(PPhoneTb);
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
            Name = "Patient";
            Text = "Patient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox PAdressTb;
        private ComboBox PGenderCb;
        private ComboBox PBGroupCb;
        private TextBox PPhoneTb;
        private TextBox PAgeTb;
        private TextBox PNameTb;
        private Button button1;
        private ComboBox PDListCb;
        private Label label8;
        private ComboBox PWNoCb;
        private Label label9;
        private Label label10;
        private ComboBox PBNoCb;
    }
}
