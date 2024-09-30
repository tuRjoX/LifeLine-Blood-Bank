using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LifeLineBloodBank.Database; 

namespace LifeLineBloodBank.Forms
{
    public partial class UpdateDonor : Form
    {
        private readonly DonorTbl donorTbl = new DonorTbl(); 
        private int key = 0; 

        public UpdateDonor()
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
                label1.ForeColor = ThemeColor.PrimaryColor;
                label11.ForeColor = ThemeColor.SecondaryColor;
                label12.ForeColor = ThemeColor.PrimaryColor;
                label13.ForeColor = ThemeColor.SecondaryColor;
                label14.ForeColor = ThemeColor.PrimaryColor;
                label15.ForeColor = ThemeColor.SecondaryColor;
                label16.ForeColor = ThemeColor.PrimaryColor;
                DonorDGV.ForeColor = ThemeColor.SecondaryColor;
            }
        }

        private void Reset()
        {
            DNameTb.Text = "";
            DAgeTb.Text = "";
            DPhone.Text = "";
            DGenderCB.SelectedIndex = -1;
            DBGroupCB.SelectedIndex = -1;
            DAddressTbl.Text = "";
            key = 0;
        }
        private void populate()
        {
            try
            {
                DonorDGV.DataSource = donorTbl.GetAllDonors();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DonorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DNameTb.Text = DonorDGV.SelectedRows[0].Cells[1].Value.ToString();
            DAgeTb.Text = DonorDGV.SelectedRows[0].Cells[2].Value.ToString();
            DGenderCB.SelectedItem = DonorDGV.SelectedRows[0].Cells[3].Value.ToString();
            DPhone.Text = DonorDGV.SelectedRows[0].Cells[4].Value.ToString();
            DAddressTbl.Text = DonorDGV.SelectedRows[0].Cells[5].Value.ToString();
            DBGroupCB.SelectedItem = DonorDGV.SelectedRows[0].Cells[6].Value.ToString();
            key = Convert.ToInt32(DonorDGV.SelectedRows[0].Cells[0].Value.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select A Donor");
            }
            else
            {
                try
                {
                    donorTbl.DeleteDonor(key); 
                    MessageBox.Show("Donor Deleted Successfully.");
                    Reset();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DNameTb.Text) || string.IsNullOrWhiteSpace(DPhone.Text) ||
                string.IsNullOrWhiteSpace(DAgeTb.Text) || DGenderCB.SelectedIndex == -1 || DBGroupCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information.");
            }
            else if (!int.TryParse(DAgeTb.Text, out int age) || age <= 17)
            {
                MessageBox.Show("Age must be greater than 17.");
            }
            else if (DPhone.Text.Length != 11 || !long.TryParse(DPhone.Text, out _) ||
            !(DPhone.Text.StartsWith("018") || DPhone.Text.StartsWith("015") ||
            DPhone.Text.StartsWith("014") || DPhone.Text.StartsWith("017") ||
            DPhone.Text.StartsWith("016")))
            {
                MessageBox.Show("Incorrect Mobile Number.");
            }
            else
            {
                try
                {
                    donorTbl.UpdateDonor(key, DNameTb.Text, age, DGenderCB.SelectedItem.ToString(),
                                         DPhone.Text, DAddressTbl.Text, DBGroupCB.SelectedItem.ToString()); // Use DonorTbl to update the donor
                    MessageBox.Show("Donor Updated Successfully.");
                    Reset();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UpdateDonor_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
