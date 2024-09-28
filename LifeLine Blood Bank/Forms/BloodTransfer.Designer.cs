namespace LifeLineBloodBank.Forms
{
    partial class BloodTransfer
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
            this.BloodGroup = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TransferBtn = new System.Windows.Forms.Button();
            this.AvailableLbl = new System.Windows.Forms.Label();
            this.PatNameTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PatientIdCb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BloodGroup
            // 
            this.BloodGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.BloodGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BloodGroup.Enabled = false;
            this.BloodGroup.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BloodGroup.Location = new System.Drawing.Point(880, 364);
            this.BloodGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BloodGroup.Multiline = true;
            this.BloodGroup.Name = "BloodGroup";
            this.BloodGroup.Size = new System.Drawing.Size(217, 30);
            this.BloodGroup.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(447, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(311, 47);
            this.label5.TabIndex = 50;
            this.label5.Text = "Blood Transfer";
            // 
            // TransferBtn
            // 
            this.TransferBtn.BackColor = System.Drawing.Color.Red;
            this.TransferBtn.FlatAppearance.BorderSize = 0;
            this.TransferBtn.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.TransferBtn.Location = new System.Drawing.Point(519, 578);
            this.TransferBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TransferBtn.Name = "TransferBtn";
            this.TransferBtn.Size = new System.Drawing.Size(156, 55);
            this.TransferBtn.TabIndex = 52;
            this.TransferBtn.Text = "Transfer";
            this.TransferBtn.UseVisualStyleBackColor = false;
            this.TransferBtn.Visible = false;
            this.TransferBtn.Click += new System.EventHandler(this.TransferBtn_Click);
            // 
            // AvailableLbl
            // 
            this.AvailableLbl.AutoSize = true;
            this.AvailableLbl.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableLbl.ForeColor = System.Drawing.Color.Red;
            this.AvailableLbl.Location = new System.Drawing.Point(491, 517);
            this.AvailableLbl.Name = "AvailableLbl";
            this.AvailableLbl.Size = new System.Drawing.Size(218, 28);
            this.AvailableLbl.TabIndex = 49;
            this.AvailableLbl.Text = "Available Or Not";
            this.AvailableLbl.Visible = false;
            // 
            // PatNameTb
            // 
            this.PatNameTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PatNameTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PatNameTb.Enabled = false;
            this.PatNameTb.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatNameTb.Location = new System.Drawing.Point(492, 364);
            this.PatNameTb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PatNameTb.Multiline = true;
            this.PatNameTb.Name = "PatNameTb";
            this.PatNameTb.Size = new System.Drawing.Size(217, 30);
            this.PatNameTb.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(487, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 23);
            this.label3.TabIndex = 47;
            this.label3.Text = "Patient Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(875, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 46;
            this.label2.Text = "Blood Group";
            // 
            // PatientIdCb
            // 
            this.PatientIdCb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.PatientIdCb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PatientIdCb.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatientIdCb.FormattingEnabled = true;
            this.PatientIdCb.Location = new System.Drawing.Point(136, 367);
            this.PatientIdCb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PatientIdCb.Name = "PatientIdCb";
            this.PatientIdCb.Size = new System.Drawing.Size(216, 28);
            this.PatientIdCb.TabIndex = 45;
            this.PatientIdCb.SelectedIndexChanged += new System.EventHandler(this.PatientIdCb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(132, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 44;
            this.label1.Text = "Patient ID";
            // 
            // BloodTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 762);
            this.Controls.Add(this.BloodGroup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TransferBtn);
            this.Controls.Add(this.AvailableLbl);
            this.Controls.Add(this.PatNameTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PatientIdCb);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BloodTransfer";
            this.Text = "BloodTransfer";
            this.Load += new System.EventHandler(this.BloodTransfer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BloodGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button TransferBtn;
        private System.Windows.Forms.Label AvailableLbl;
        private System.Windows.Forms.TextBox PatNameTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PatientIdCb;
        private System.Windows.Forms.Label label1;
    }
}