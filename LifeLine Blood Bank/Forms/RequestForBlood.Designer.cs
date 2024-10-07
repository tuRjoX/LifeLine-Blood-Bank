namespace LifeLineBloodBank.Forms
{
    partial class RequestForBlood
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
            this.RPhone = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.RNameTb = new System.Windows.Forms.TextBox();
            this.RBGroupCB = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.REmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RPhone
            // 
            this.RPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.RPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RPhone.Enabled = false;
            this.RPhone.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPhone.Location = new System.Drawing.Point(402, 197);
            this.RPhone.Multiline = true;
            this.RPhone.Name = "RPhone";
            this.RPhone.Size = new System.Drawing.Size(163, 20);
            this.RPhone.TabIndex = 54;
            this.RPhone.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(271, 137);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 20);
            this.label13.TabIndex = 53;
            this.label13.Text = "Name";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RNameTb
            // 
            this.RNameTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.RNameTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RNameTb.Enabled = false;
            this.RNameTb.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RNameTb.Location = new System.Drawing.Point(402, 137);
            this.RNameTb.Multiline = true;
            this.RNameTb.Name = "RNameTb";
            this.RNameTb.Size = new System.Drawing.Size(163, 20);
            this.RNameTb.TabIndex = 52;
            this.RNameTb.TabStop = false;
            // 
            // RBGroupCB
            // 
            this.RBGroupCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.RBGroupCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RBGroupCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RBGroupCB.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBGroupCB.FormattingEnabled = true;
            this.RBGroupCB.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
            this.RBGroupCB.Location = new System.Drawing.Point(402, 328);
            this.RBGroupCB.Name = "RBGroupCB";
            this.RBGroupCB.Size = new System.Drawing.Size(163, 24);
            this.RBGroupCB.TabIndex = 57;
            this.RBGroupCB.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(271, 332);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 20);
            this.label15.TabIndex = 56;
            this.label15.Text = "Blood Group";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(271, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "Number";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(402, 417);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 33);
            this.button2.TabIndex = 59;
            this.button2.TabStop = false;
            this.button2.Text = "Request";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(279, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(306, 38);
            this.label12.TabIndex = 60;
            this.label12.Text = "Request For Blood";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(271, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 62;
            this.label2.Text = "Email";
            // 
            // REmail
            // 
            this.REmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.REmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.REmail.Enabled = false;
            this.REmail.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REmail.Location = new System.Drawing.Point(402, 263);
            this.REmail.Multiline = true;
            this.REmail.Name = "REmail";
            this.REmail.Size = new System.Drawing.Size(163, 20);
            this.REmail.TabIndex = 61;
            this.REmail.TabStop = false;
            // 
            // RequestForBlood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 619);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.REmail);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RBGroupCB);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.RPhone);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.RNameTb);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.Name = "RequestForBlood";
            this.Text = "RequestForBlood";
            this.Load += new System.EventHandler(this.RequestForBlood_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox RPhone;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox RNameTb;
        private System.Windows.Forms.ComboBox RBGroupCB;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox REmail;
    }
}