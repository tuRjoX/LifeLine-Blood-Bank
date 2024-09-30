using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using LifeLineBloodBank.Database;

namespace LifeLineBloodBank.Forms
{
    public partial class BloodTransfer : Form
    {
        private readonly PatientsTbl patientsTbl;
        private readonly BloodTbl bloodTbl;
        private readonly TransferTbl transferTbl;

        public BloodTransfer()
        {
            InitializeComponent();
            patientsTbl = new PatientsTbl();
            bloodTbl = new BloodTbl();
            transferTbl = new TransferTbl();
            fillPatientCb();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns is Button btn)
                {
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

            label1.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.PrimaryColor;
            AvailableLbl.ForeColor = ThemeColor.SecondaryColor;
        }

        private void fillPatientCb()
        {
            DataTable dt = patientsTbl.GetPatients();
            PatientIdCb.ValueMember = "PNum";
            PatientIdCb.DataSource = dt;
        }

        private void GetData()
        {
            int patientId = (int)PatientIdCb.SelectedValue;
            DataTable dt = patientsTbl.GetPatientById(patientId);
            if (dt.Rows.Count > 0)
            {
                PatNameTb.Text = dt.Rows[0]["PName"].ToString();
                BloodGroup.Text = dt.Rows[0]["PBGroup"].ToString();
            }
        }

        private void PatientIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData();
            int stock = bloodTbl.GetStockByBloodGroup(BloodGroup.Text);
            if (stock > 0)
            {
                TransferBtn.Visible = true;
                AvailableLbl.Text = "Available Stock";
                AvailableLbl.Visible = true;
            }
            else
            {
                TransferBtn.Visible = false;
                AvailableLbl.Text = "Stock Not Available";
                AvailableLbl.Visible = true;
            }
        }

        private void Reset()
        {
            PatNameTb.Text = "";
            BloodGroup.Text = "";
            AvailableLbl.Visible = false;
            TransferBtn.Visible = false;
        }

        private void TransferBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PatNameTb.Text))
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    transferTbl.AddTransfer(PatNameTb.Text, BloodGroup.Text);
                    int newStock = bloodTbl.GetStockByBloodGroup(BloodGroup.Text) - 1;
                    bloodTbl.UpdateStock(BloodGroup.Text, newStock);
                    MessageBox.Show("Successfully Transferred.");
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BloodTransfer_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
