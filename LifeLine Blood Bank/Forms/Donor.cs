using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LifeLineBloodBank.Forms
{
    public partial class Donor : Form
    {
        public Donor()
        {
            InitializeComponent();
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
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (DNameTb.Text == "" || DPhone.Text == "" || DAgeTb.Text == "" || DGenderCB.SelectedIndex == -1 || DBGroupCB.SelectedIndex == -1)
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
                    String query = "insert into DonorTbl values('" + DNameTb.Text + "','" + DAgeTb.Text + "','" + DGenderCB.SelectedItem.ToString() + "','" + DPhone.Text + "','" + DAddressTbl.Text + "','" + DBGroupCB.SelectedItem.ToString() + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Successfully Saved.");
                    Con.Close();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }


        private void Donor_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
