using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using LifeLineBloodBank.Database; 

namespace LifeLineBloodBank.Forms
{
    public partial class Donate : Form
    {
        private BloodTbl bloodTbl = new BloodTbl(); 
        private int oldstock;

        public Donate()
        {
            InitializeComponent();
            populate();
            bloodStock();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns is Button btn)
                {
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.Honeydew;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }

                label11.ForeColor = ThemeColor.SecondaryColor;
                label12.ForeColor = ThemeColor.PrimaryColor;
                label13.ForeColor = ThemeColor.SecondaryColor;
                label14.ForeColor = ThemeColor.PrimaryColor;
                label15.ForeColor = ThemeColor.SecondaryColor;
            }
        }

        private void populate()
        {
            DonorTbl donorTbl = new DonorTbl();
            DataTable dt = donorTbl.GetAllDonors();
            if (dt.Columns.Contains("DPicture"))
            {
                dt.Columns.Remove("DPicture");
            }
            DonorsDGV.DataSource = dt;
        }
        private void bloodStock()
        {
            try
            {
                DataTable dt = bloodTbl.GetAllBloodStock();
                BloodStockDGV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetStock(string Bgroup)
        {
            try
            {
                oldstock = bloodTbl.GetStockByBloodGroup(Bgroup);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DonorsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DNameTb.Text = DonorsDGV.SelectedRows[0].Cells[1].Value.ToString();
            BGroupTb.Text = DonorsDGV.SelectedRows[0].Cells[6].Value.ToString();
            GetStock(BGroupTb.Text);
        }

        private void reset()
        {
            DNameTb.Text = "";
            BGroupTb.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DNameTb.Text))
            {
                MessageBox.Show("Select A Donor");
                return;
            }

            try
            {
                int newStock = oldstock + 1;
                bloodTbl.UpdateStock(BGroupTb.Text, newStock);

                MessageBox.Show("Donation Successful");

                reset();
                bloodStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Donate_Load_1(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
