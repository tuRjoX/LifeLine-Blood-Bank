using System;
using System.Drawing;
using System.Windows.Forms;
using LifeLineBloodBank.Database; 

namespace LifeLineBloodBank.Forms
{
    public partial class Donor : Form
    {
        private readonly DonorTbl donorTbl = new DonorTbl(); 

        public Donor()
        {
            InitializeComponent();
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
                label10.ForeColor = ThemeColor.PrimaryColor;
                label11.ForeColor = ThemeColor.SecondaryColor;
                label12.ForeColor = ThemeColor.PrimaryColor;
                label13.ForeColor = ThemeColor.SecondaryColor;
                label14.ForeColor = ThemeColor.PrimaryColor;
                label15.ForeColor = ThemeColor.SecondaryColor;
                label16.ForeColor = ThemeColor.PrimaryColor;
                label1.ForeColor = ThemeColor.SecondaryColor;
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
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DNameTb.Text) || string.IsNullOrWhiteSpace(DPhone.Text) ||
                string.IsNullOrWhiteSpace(DAgeTb.Text) || DGenderCB.SelectedIndex == -1 || DBGroupCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information.");
            }
            else if (!int.TryParse(DAgeTb.Text, out int age) || age <= 17 || age >= 66)
            {
                MessageBox.Show("You are not eligiable for donation at this age.");
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
                    donorTbl.AddDonor(DNameTb.Text, age, DGenderCB.SelectedItem.ToString(),
                                      DPhone.Text, DAddressTbl.Text, DBGroupCB.SelectedItem.ToString());

                    MessageBox.Show("Donor Successfully Saved.");
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Donor_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
