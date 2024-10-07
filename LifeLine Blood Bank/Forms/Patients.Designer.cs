namespace LifeLineBloodBank.Forms
{
    partial class Patients
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
            this.PBGroupCb = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.PDListCb = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PBNoCb = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PWNoCb = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PGenderCb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PAdressTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PPhoneTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PAgeTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PNameTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PBGroupCb
            // 
            this.PBGroupCb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PBGroupCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PBGroupCb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PBGroupCb.FormattingEnabled = true;
            this.PBGroupCb.Items.AddRange(new object[] {
            "A+",
            "O+",
            "B+",
            "AB+",
            "A-",
            "O-",
            "B-",
            "AB-"});
            this.PBGroupCb.Location = new System.Drawing.Point(116, 232);
            this.PBGroupCb.Name = "PBGroupCb";
            this.PBGroupCb.Size = new System.Drawing.Size(176, 21);
            this.PBGroupCb.TabIndex = 83;
            this.PBGroupCb.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(384, 480);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 33);
            this.button2.TabIndex = 81;
            this.button2.TabStop = false;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PDListCb
            // 
            this.PDListCb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PDListCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PDListCb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PDListCb.FormattingEnabled = true;
            this.PDListCb.Items.AddRange(new object[] {
            "Cardiothoracic and Vascular Surgery",
            "Cardiology",
            "Critical Care Units",
            "Orthopedics",
            "Obstetrics and Gynaecology",
            "Paediatrics",
            "Urology",
            "General Medicine",
            "Ent",
            "Gastroenterology and Hepatology",
            "Nephrology",
            "General and Laparoscopic Surgery",
            "Endocrinology and Diabetology",
            "Neurology",
            "Psychiatry",
            "Neurosurgery",
            "Respiratory Medicine",
            "Radiology and Imaging",
            "Physical Medicine and Rehabilitation",
            "Internal Medicine",
            "Dental and Maxillofacial Surgery",
            "Oncology",
            "Diet Center",
            "Pathology",
            "Blood Transfusion",
            "General and Colorectal Surgery",
            "Hamotology",
            "Thoracic Surgery",
            "Accident and Emergency",
            "Aaesthesia",
            "Dermatology and Venereology",
            "Ophthalmology",
            "Breast and Colorectal Surgeon",
            "Burn and Plastic Surgery"});
            this.PDListCb.Location = new System.Drawing.Point(611, 343);
            this.PDListCb.Name = "PDListCb";
            this.PDListCb.Size = new System.Drawing.Size(176, 21);
            this.PDListCb.TabIndex = 80;
            this.PDListCb.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(607, 311);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 20);
            this.label10.TabIndex = 79;
            this.label10.Text = "Department";
            // 
            // PBNoCb
            // 
            this.PBNoCb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PBNoCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PBNoCb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PBNoCb.FormattingEnabled = true;
            this.PBNoCb.Items.AddRange(new object[] {
            "F-1",
            "F-2",
            "F-3",
            "F-4",
            "F-5",
            "F-6",
            "F-7",
            "F-8",
            "F-9",
            "F-10",
            "F-11",
            "F-12",
            "F-13",
            "F-14",
            "F-15",
            "F-16",
            "F-17",
            "F-18",
            "F-19",
            "F-20",
            "M-1",
            "M-2",
            "M-3",
            "M-4",
            "M-5",
            "M-6",
            "M-7",
            "M-8",
            "M-9",
            "M-10",
            "M-11",
            "M-12",
            "M-13",
            "M-14",
            "M-15",
            "M-16",
            "M-17",
            "M-18",
            "M-19",
            "M-20"});
            this.PBNoCb.Location = new System.Drawing.Point(116, 343);
            this.PBNoCb.Name = "PBNoCb";
            this.PBNoCb.Size = new System.Drawing.Size(176, 21);
            this.PBNoCb.TabIndex = 78;
            this.PBNoCb.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(112, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 77;
            this.label9.Text = "Bed No";
            // 
            // PWNoCb
            // 
            this.PWNoCb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PWNoCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PWNoCb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PWNoCb.FormattingEnabled = true;
            this.PWNoCb.Items.AddRange(new object[] {
            "M1-M20",
            "F1-F20"});
            this.PWNoCb.Location = new System.Drawing.Point(611, 232);
            this.PWNoCb.Name = "PWNoCb";
            this.PWNoCb.Size = new System.Drawing.Size(176, 21);
            this.PWNoCb.TabIndex = 76;
            this.PWNoCb.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(607, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 20);
            this.label8.TabIndex = 75;
            this.label8.Text = "Ward No";
            // 
            // PGenderCb
            // 
            this.PGenderCb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PGenderCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PGenderCb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PGenderCb.FormattingEnabled = true;
            this.PGenderCb.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.PGenderCb.Location = new System.Drawing.Point(366, 232);
            this.PGenderCb.Name = "PGenderCb";
            this.PGenderCb.Size = new System.Drawing.Size(176, 21);
            this.PGenderCb.TabIndex = 74;
            this.PGenderCb.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(362, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 73;
            this.label7.Text = "Gender";
            // 
            // PAdressTb
            // 
            this.PAdressTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PAdressTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PAdressTb.Location = new System.Drawing.Point(366, 343);
            this.PAdressTb.Multiline = true;
            this.PAdressTb.Name = "PAdressTb";
            this.PAdressTb.Size = new System.Drawing.Size(176, 21);
            this.PAdressTb.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(362, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 71;
            this.label6.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(112, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 70;
            this.label5.Text = "Blood Group";
            // 
            // PPhoneTb
            // 
            this.PPhoneTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PPhoneTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PPhoneTb.Location = new System.Drawing.Point(611, 135);
            this.PPhoneTb.Multiline = true;
            this.PPhoneTb.Name = "PPhoneTb";
            this.PPhoneTb.Size = new System.Drawing.Size(176, 23);
            this.PPhoneTb.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(607, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 68;
            this.label4.Text = "Mobile No.";
            // 
            // PAgeTb
            // 
            this.PAgeTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PAgeTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PAgeTb.Location = new System.Drawing.Point(366, 135);
            this.PAgeTb.Multiline = true;
            this.PAgeTb.Name = "PAgeTb";
            this.PAgeTb.Size = new System.Drawing.Size(176, 23);
            this.PAgeTb.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(362, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 66;
            this.label3.Text = "Age";
            // 
            // PNameTb
            // 
            this.PNameTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PNameTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PNameTb.Location = new System.Drawing.Point(116, 135);
            this.PNameTb.Multiline = true;
            this.PNameTb.Name = "PNameTb";
            this.PNameTb.Size = new System.Drawing.Size(176, 23);
            this.PNameTb.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(112, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(386, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 38);
            this.label1.TabIndex = 63;
            this.label1.Text = "Patient";
            // 
            // Patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 619);
            this.Controls.Add(this.PBGroupCb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PDListCb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PBNoCb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PWNoCb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PGenderCb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PAdressTb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PPhoneTb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PAgeTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PNameTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Patients";
            this.Text = "Patients";
            this.Load += new System.EventHandler(this.Patients_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PBGroupCb;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox PDListCb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox PBNoCb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox PWNoCb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox PGenderCb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PAdressTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PPhoneTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PAgeTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PNameTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}