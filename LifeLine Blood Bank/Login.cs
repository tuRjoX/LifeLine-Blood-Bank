using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;
using LifeLineBloodBank.Forms;

namespace LifeLineBloodBank
{
    public partial class Login : Form
    {
        public static string to;
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection("Data Source=TURJO\\SQLEXPRESS02;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True");

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';  
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM UsersTbl WHERE [UName] COLLATE SQL_Latin1_General_CP1_CS_AS = @UserName AND [UPassword] = @Password";
            SqlCommand sqlCmd = new SqlCommand(query, Con);
            sqlCmd.Parameters.AddWithValue("@UserName", txtUsername.Text);
            sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text);

            try
            {
                Con.Open();
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MessageBox.Show("Login Successful.");

                        // Retrieve the user ID
                        int userId = Convert.ToInt32(reader["Id"]); // Assuming the ID field is called "Id"
                        string userEmail = reader["UEmail"].ToString();

                        SendLoginNotification(userEmail);

                        // Pass the user ID to the DonateBlood form
                        UserForm userform = new UserForm(userId);
                        userform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login Unsuccessful. Please check your username and password.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

        private string GetLocalIPAddress()
        {
            string localIP = "";
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }

            return localIP;
        }
        private void SendLoginNotification(string userEmail)
        {
            string from, pass, messageBody;
            string userIP = GetLocalIPAddress();
            MailMessage message = new MailMessage();
            from = "lifelinebloodbankbd@gmail.com";
            pass = "tpul kgmg gfrc nkki";

            messageBody = $"Dear Member,<br><br>" +
                          "You have successfully logged in to LifeLine Blood Bank on " + DateTime.Now.ToString("dd MMMM, yyyy 'at' hh:mm:ss tt") +
                          " from IP: " + userIP + ".<br><br>" +
                          "For any queries, please contact:<br>" +
                          "- Call: 16221 (Local)<br>" +
                          "- +880255668055, +880255668056, +8809611223344 (Overseas).<br><br>" +
                          "Sincerely,<br><br>" +
                          "LifeLine Blood Bank Team.<br><br>" +
                          "<b>**This is an auto-generated email. Please do not reply to this email.**</b><br><br>" +
                          "<b>LifeLine Blood Bank</b><br>" +
                          "House 11, Road 62, Gulshan 2 <br>" +
                          "Dhaka, Bangladesh<br>" +
                          "Phone: (+880) 185 656 4543<br>" +
                          "Email: support@lifelinebloodbank.com<br>" +
                          "<a href='https://www.lifelinebloodbank.com'>www.lifelinebloodbank.com</a><br>" +
                          "<img src=cid:logoImage>";

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(messageBody, null, "text/html");
            LinkedResource logo = new LinkedResource(@"C:\Users\tdas4\source\repos\GUI\Background1.png");
            logo.ContentId = "logoImage";
            htmlView.LinkedResources.Add(logo);
            message.AlternateViews.Add(htmlView);
            message.To.Add(userEmail);
            message.From = new MailAddress(from, "LifeLine Blood Bank");
            message.Subject = "Login successful - LifeLine Blood Bank";

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, pass)
            };

            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ForgetPassword fp = new ForgetPassword();
            fp.Show();
            this.Hide();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void eye_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
                eye.Image = Properties.Resources.eye;
            }
            else
            {
                txtPassword.PasswordChar = '*';
                eye.Image = Properties.Resources.eye;
            }
        }
    }
}
