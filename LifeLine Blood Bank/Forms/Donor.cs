using System;
using System.Drawing;
using System.IO;
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
                label3.ForeColor = ThemeColor.PrimaryColor;
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
            DPBox.Image = null;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DNameTb.Text) || string.IsNullOrEmpty(DPhone.Text) ||
                string.IsNullOrEmpty(DAgeTb.Text) || DGenderCB.SelectedIndex == -1 || DBGroupCB.SelectedIndex == -1 || DPBox.Image == null)
            {
                MessageBox.Show("Missing Information.");
            }
            else if (DPhone.Text.Length != 11 || !long.TryParse(DPhone.Text, out _))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.");
            }
            else if (!int.TryParse(DAgeTb.Text, out int age) || age <= 17 || age >= 66)
            {
                MessageBox.Show("You are not eligible for donation at this age.");
            }
            else
            {
                try
                {
                    byte[] picture = ImageToByteArray(DPBox.Image);
                    donorTbl.AddDonor(DNameTb.Text, age, DGenderCB.SelectedItem.ToString(), DPhone.Text, DAddressTbl.Text, DBGroupCB.SelectedItem.ToString(), picture);
                    MessageBox.Show("Donor Successfully Saved.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                Reset();
            }
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        private void Donor_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private string imgLocation = "";
        private void DPBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg|All Files (*.*)|*.*";
                dialog.Title = "Select Donor Picture";
                dialog.FilterIndex = 1; 

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imgLocation = dialog.FileName; 
                    DPBox.ImageLocation = imgLocation; 
                    try
                    {
                        DPBox.Image = Image.FromFile(imgLocation); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message);
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
