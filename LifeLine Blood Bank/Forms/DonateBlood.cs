using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeLineBloodBank.Forms
{
    public partial class DonateBlood : Form
    {
        private int Id;

        // Add PrintPreviewDialog and PrintDocument
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private System.Drawing.Printing.PrintDocument printDonorInfo = new System.Drawing.Printing.PrintDocument();

        public DonateBlood(int userId)
        {
            InitializeComponent();
            Id = userId;

            // Assign PrintPage event
            printDonorInfo.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDonorInfo_PrintPage);
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.Honeydew;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                label1.ForeColor = ThemeColor.PrimaryColor;
                label11.ForeColor = ThemeColor.SecondaryColor;
                label12.ForeColor = ThemeColor.PrimaryColor;
                label13.ForeColor = ThemeColor.SecondaryColor;
                label14.ForeColor = ThemeColor.PrimaryColor;
                label15.ForeColor = ThemeColor.SecondaryColor;
                label16.ForeColor = ThemeColor.PrimaryColor;
            }
        }

        SqlConnection Con = new SqlConnection("Data Source=TURJO\\SQLEXPRESS02;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True");

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
                string query = "SELECT UName, UFullName, UPhone FROM UsersTbl WHERE Id = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    Con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        DNameTb.Text = reader["UFullName"].ToString();
                        txtUName.Text = reader["UName"].ToString();
                        DPhone.Text = reader["UPhone"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("User not found.");
                    }
                    Con.Close();
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (DNameTb.Text == "" || DPhone.Text == "" || DAgeTb.Text == "" || DGenderCB.SelectedIndex == -1 || DBGroupCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information.");
            }
            else if (DPhone.Text.Length != 11 || !long.TryParse(DPhone.Text, out _))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.");
            }
            else if (!int.TryParse(DAgeTb.Text, out int age) || age <= 17)
            {
                MessageBox.Show("Age must be a valid number greater than 17.");
            }
            else
            {
                try
                {
                    String query = "INSERT INTO DonorTbl VALUES(@Name, @Age, @Gender, @Phone, @Address, @BloodGroup)";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@Name", DNameTb.Text);
                    cmd.Parameters.AddWithValue("@Age", DAgeTb.Text);
                    cmd.Parameters.AddWithValue("@Gender", DGenderCB.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Phone", DPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", DAddressTbl.Text);
                    cmd.Parameters.AddWithValue("@BloodGroup", DBGroupCB.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Successfully Saved.");
                    Con.Close();

                    // Show print preview BEFORE resetting the form
                    printPreviewDialog1.Document = printDonorInfo;
                    printPreviewDialog1.ShowDialog();

                    // Reset fields after successful print and save
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // Event handler for PrintPage event
        private void printDonorInfo_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font headerFont = new Font("Arial", 20, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 12);
            PointF startingPoint = new PointF(100, 100);

            // Print header
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
