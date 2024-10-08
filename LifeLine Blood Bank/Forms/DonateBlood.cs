using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LifeLineBloodBank.Database; 

namespace LifeLineBloodBank.Forms
{
    public partial class DonateBlood : Form
    {
        private int Id;
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private System.Drawing.Printing.PrintDocument printDonorInfo = new System.Drawing.Printing.PrintDocument();
        private SqlConnection Con;
        private UserTbl userTbl;
        private DonorTbl donorTbl;

        public DonateBlood(int userId)
        {
            InitializeComponent();
            Id = userId;
            userTbl = new UserTbl(); 
            donorTbl = new DonorTbl(); 
            printDonorInfo.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDonorInfo_PrintPage);
            string connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            Con = new SqlConnection(connectionString);
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
            label1.ForeColor = ThemeColor.PrimaryColor;
            label11.ForeColor = ThemeColor.SecondaryColor;
            label12.ForeColor = ThemeColor.PrimaryColor;
            label13.ForeColor = ThemeColor.SecondaryColor;
            label14.ForeColor = ThemeColor.PrimaryColor;
            label15.ForeColor = ThemeColor.SecondaryColor;
            label16.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
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
        private void LoadUserData(int userId)
        {
            try
            {
                DataRow userData = userTbl.LoadUserData(userId);
                DNameTb.Text = userData["UFullName"].ToString();
                txtUName.Text = userData["UName"].ToString();
                DPhone.Text = userData["UPhone"].ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void DonateBlood_Load(object sender, EventArgs e)
        {
            LoadUserData(Id);
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
        private void button2_Click(object sender, EventArgs e)
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
                printPreviewDialog1.Document = printDonorInfo;
                printPreviewDialog1.ShowDialog();
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

        private void printDonorInfo_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font headerFont = new Font("Arial", 20, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 12);
            PointF startingPoint = new PointF(100, 100);
            e.Graphics.DrawString("Donor Information", headerFont, Brushes.Black, startingPoint);

            startingPoint.Y += 50;
            e.Graphics.DrawString($"Name: {DNameTb.Text}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Age: {DAgeTb.Text}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Phone: {DPhone.Text}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Gender: {DGenderCB.SelectedItem}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Blood Group: {DBGroupCB.SelectedItem}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Address: {DAddressTbl.Text}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Date Created: {DateTime.Now.ToString("g")}", bodyFont, Brushes.Black, startingPoint);
        } 
    }
}
