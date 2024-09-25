using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LifeLineBloodBank.Forms
{
    public partial class RequestForBlood : Form
    {
        private int Id;
        public RequestForBlood(int id)
        {
            InitializeComponent();
            Id = id;
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
                label12.ForeColor = ThemeColor.SecondaryColor;
                label13.ForeColor = ThemeColor.PrimaryColor; ;
                label15.ForeColor = ThemeColor.SecondaryColor;
                label2.ForeColor = ThemeColor.PrimaryColor;
            }
        }
        SqlConnection Con = new SqlConnection("Data Source=TURJO\\SQLEXPRESS02;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True");
        private void Reset()
        {
            RNameTb.Text = "";
            RPhone.Text = "";
            RBGroupCB.SelectedIndex = -1;
        }
        private void FetchUserData(int userId)
        {
            try
            {
                Con.Open();
                string query = "SELECT UName, UFullName, UEmail, UPhone FROM UsersTbl WHERE Id = @UserId";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    RNameTb.Text = reader["UFullName"].ToString();
                    RPhone.Text = reader["UPhone"].ToString();
                    REmail.Text = reader["UEmail"].ToString();
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching user data: " + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void RequestForBlood_Load(object sender, EventArgs e)
        {
            FetchUserData(Id);
            LoadTheme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RNameTb.Text == "" || RPhone.Text == "" || RBGroupCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information.");
            }
            else if (RPhone.Text.Length != 11 || !long.TryParse(RPhone.Text, out _) ||
            !(RPhone.Text.StartsWith("018") || RPhone.Text.StartsWith("015") ||
            RPhone.Text.StartsWith("014") || RPhone.Text.StartsWith("017") ||
            RPhone.Text.StartsWith("016")))
            {
                MessageBox.Show("Incorrect Mobile Number.");
            }
            else
            {
                try
                {
                    String query = "insert into RequestTbl (RName, RPhone,REmail, RBGroup) values('" + RNameTb.Text + "','" + RPhone.Text + "','" + REmail.Text + "','" + RBGroupCB.SelectedItem.ToString() + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Request Sent Successfully.");
                    SendEmail(REmail.Text, "",RBGroupCB.SelectedItem.ToString());
                    Con.Close();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void SendEmail(string toEmail, string userName, string bloodGroup)
        {
            try
            {
                string from = "lifelinebloodbankbd@gmail.com";
                string pass = "tpul kgmg gfrc nkki"; 
                string subject = "Blood Request Confirmation";
                string messageBody = $"Dear {userName},<br><br>Your request for {bloodGroup} blood has been successfully submitted.<br><br>Thank you for using our services.";

                MailMessage message = new MailMessage
                {
                    From = new MailAddress(from, "LifeLine Blood Bank"),
                    Subject = subject,
                    IsBodyHtml = true
                };
                message.To.Add(toEmail); 
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                    messageBody +
                    "<br><br>Best regards,<br>LifeLine Blood Bank<br><br>" +
                    "<hr><br>" +
                    "<b>LifeLine Blood Bank</b><br>" +
                    "House 11, Road 62, Gulshan 2 <br>" +
                    "Dhaka, Bangladesh<br>" +
                    "Phone: (+880) 185 656 4543<br>" +
                    "Email: support@lifelinebloodbank.com<br>" +
                    "<a href='https://www.lifelinebloodbank.com'>www.lifelinebloodbank.com</a><br>",
                    null, "text/html"
                );

                message.AlternateViews.Add(htmlView); 
                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    EnableSsl = true,
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(from, pass)
                };

                // Send the email
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message);
            }
        }

    }
}
