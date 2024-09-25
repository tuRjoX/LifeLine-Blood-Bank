using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration; // Add this for ConfigurationManager

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
                if (btns is Button btn)
                {
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White; // Set forecolor to white
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }

                // Set label colors
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

        // Use the connection string from app.config
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString);

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
                    string query = "INSERT INTO DonorTbl (DName, DAge, DGender, DPhone, DAddress, DBGroup) VALUES (@DName, @DAge, @DGender, @DPhone, @DAddress, @DBGroup)";
                    using (Con)
                    {
                        Con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, Con))
                        {
                            cmd.Parameters.AddWithValue("@DName", DNameTb.Text);
                            cmd.Parameters.AddWithValue("@DAge", DAgeTb.Text);
                            cmd.Parameters.AddWithValue("@DGender", DGenderCB.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@DPhone", DPhone.Text);
                            cmd.Parameters.AddWithValue("@DAddress", DAddressTbl.Text);
                            cmd.Parameters.AddWithValue("@DBGroup", DBGroupCB.SelectedItem.ToString());

                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Donor Successfully Saved.");
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
