using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LifeLineBloodBank.Database; // Import the DataAccess namespace

namespace LifeLineBloodBank.Forms
{
    public partial class ViewDonor : Form
    {
        private readonly DonorTbl donorTbl = new DonorTbl(); // Create an instance of the DonorTbl class

        public ViewDonor()
        {
            InitializeComponent();
            populate();
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
                label10.ForeColor = ThemeColor.PrimaryColor;
                label11.ForeColor = ThemeColor.SecondaryColor;
            }
        }

        private void populate()
        {
            try
            {
                // Use DonorTbl to get all donors and bind to the DataGridView
                DataTable dt = donorTbl.GetAllDonors();
                DonorDGV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterDonorsByName(textBox1.Text);
        }

        private void FilterDonorsByName(string donorName)
        {
            try
            {
                // Use DonorTbl to filter donors by name
                DataTable dt = donorTbl.FilterDonorsByName(donorName);
                DonorDGV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewDonor_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
