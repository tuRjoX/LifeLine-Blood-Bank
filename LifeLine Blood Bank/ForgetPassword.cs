using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration; // Include this namespace

namespace LifeLineBloodBank
{
    public partial class ForgetPassword : Form
    {
        string OTPCode;
        public static string to;

        public ForgetPassword()
        {
            InitializeComponent();
            btnSend.Enabled = false;
            btnVerify.Enabled = false;
            txtCode.Enabled = false;
            txtPassword.Enabled = false;
            txtConfirmPass.Enabled = false;
            txtEmail.TextChanged += new EventHandler(txtEmail_TextChanged);
            txtCode.TextChanged += new EventHandler(txtCode_TextChanged);
        }

        private void FP_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            txtConfirmPass.PasswordChar = '*';
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            btnSend.Enabled = !string.IsNullOrWhiteSpace(txtEmail.Text);
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            btnVerify.Enabled = !string.IsNullOrWhiteSpace(txtCode.Text);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            OTPCode = (rand.Next(999999)).ToString();
            string connString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;

            using (SqlConnection Con = new SqlConnection(connString))
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM UsersTbl WHERE UEmail=@Email", Con);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                int count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Email does not exist in our records.");
                    return;
                }
            }

            MailMessage message = new MailMessage();
            to = txtEmail.Text;
            from = "lifelinebloodbankbd@gmail.com";
            pass = "tpul kgmg gfrc nkki"; // Consider using a secure way to handle passwords.
            messageBody = "Your one-time password is: " + OTPCode;
            message.To.Add(to);
            message.From = new MailAddress("lifelinebloodbankbd@gmail.com", "LifeLine Blood Bank");
            message.Body = messageBody;
            message.Subject = "Password Reset OTP - LifeLine Blood Bank";

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                $"Dear User,<br><br>Your one-time password (OTP) for resetting your account password is: {OTPCode}.<br><br>" +
                "Please use this code to complete the password reset process. This OTP is valid for a limited time and should not be shared with anyone for security purposes.<br><br>" +
                "Thank you for using our services.<br><br>Best regards,<br>LifeLine Blood Bank<br><br>" +
                "<hr><br>" +
                "<b>LifeLine Blood Bank</b><br>" +
                "House 11, Road 62, Gulshan 2 <br>" +
                "Dhaka, Bangladesh<br>" +
                "Phone: (+880) 185 656 4543<br>" +
                "Email: support@lifelinebloodbank.com<br>" +
                "<a href='https://www.lifelinebloodbank.com'>www.lifelinebloodbank.com</a><br>" +
                "<img src=cid:logoImage>", null, "text/html"
            );

            LinkedResource logo = new LinkedResource(@"C:\Users\tdas4\source\repos\GUI\Background1.png");
            logo.ContentId = "logoImage";
            htmlView.LinkedResources.Add(logo);
            message.AlternateViews.Add(htmlView);

            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from, pass)
            };

            try
            {
                smtp.Send(message);
                MessageBox.Show("OTP sent successfully.");
                txtCode.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (OTPCode == txtCode.Text)
            {
                to = txtEmail.Text;
                MessageBox.Show("Verification Successful.");
                txtPassword.Enabled = true;
                txtConfirmPass.Enabled = true;
            }
            else
            {
                MessageBox.Show("Wrong Code.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtCode.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                MessageBox.Show("Missing Info. Please fill in all the fields.");
                return;
            }
            string password = txtPassword.Text;
            if (password.Length < 6)
            {
                MessageBox.Show("Invalid password. It must be at least 6 characters long.");
                return;
            }
            if (txtPassword.Text == txtConfirmPass.Text)
            {
                string connString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE UsersTbl SET UPassword=@Password WHERE UEmail=@Email", Con);
                    cmd.Parameters.AddWithValue("@Password", txtConfirmPass.Text);
                    cmd.Parameters.AddWithValue("@Email", to);
                    Con.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Password Reset Successfully.");
                Login login = new Login();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Passwords Don't Match.");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void eye1_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
                eye1.Image = Properties.Resources.eye;
            }
            else
            {
                txtPassword.PasswordChar = '*';
                eye1.Image = Properties.Resources.eye;
            }
        }

        private void eye2_Click(object sender, EventArgs e)
        {
            if (txtConfirmPass.PasswordChar == '*')
            {
                txtConfirmPass.PasswordChar = '\0';
                eye1.Image = Properties.Resources.eye;
            }
            else
            {
                txtConfirmPass.PasswordChar = '*';
                eye1.Image = Properties.Resources.eye;
            }
        }
    }
}
