using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using LifeLineBloodBank.Database;

namespace LifeLineBloodBank
{
    public partial class Login : Form
    {
        public static string to;
        private readonly UserTbl userTbl = new UserTbl(); // Create an instance of UserTbl

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                MessageBox.Show("Admin login successful.");
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                this.Hide();
            }
            else
            {
                // Use the new AuthenticateUser method
                DataRow userData = userTbl.AuthenticateUser(txtUsername.Text, txtPassword.Text);

                if (userData != null)
                {
                    MessageBox.Show("Login Successful.");
                    int userId = Convert.ToInt32(userData["Id"]);
                    string userEmail = userData["UEmail"].ToString();

                    SendLoginNotification(userEmail);
                    UserForm userForm = new UserForm(userId);
                    userForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Unsuccessful. Please check your username and password.");
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
            string from = "lifelinebloodbankbd@gmail.com";
            string pass = "tpul kgmg gfrc nkki"; // You should consider storing this securely
            string userIP = GetLocalIPAddress();

            MailMessage message = new MailMessage
            {
                From = new MailAddress(from, "LifeLine Blood Bank"),
                Subject = "Login successful - LifeLine Blood Bank",
                IsBodyHtml = true
            };

            message.To.Add(userEmail);
            message.Body = GenerateEmailBody(userIP);

            using (SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, pass)
            })
            {
                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to send email: " + ex.Message);
                }
            }
        }

        private string GenerateEmailBody(string userIP)
        {
            return $"Dear Member,<br><br>" +
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
                   "<a href='https://www.lifelinebloodbank.com'>www.lifelinebloodbank.com</a><br>";
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
                eye.Image = Properties.Resources.eye; // Assuming you have an eye icon
            }
            else
            {
                txtPassword.PasswordChar = '*';
                eye.Image = Properties.Resources.eye; // Assuming you have an eye icon
            }
        }
    }
}
