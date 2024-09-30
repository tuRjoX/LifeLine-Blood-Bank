using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using LifeLineBloodBank.Database;

namespace LifeLineBloodBank
{
    public partial class ForgetPassword : Form
    {
        string OTPCode;
        public static string to;
        private UserTbl userTbl;

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
            userTbl = new UserTbl(); // Initialize UserTbl
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
            Random rand = new Random();
            OTPCode = (rand.Next(999999)).ToString();

            // Check if the email exists
            if (!userTbl.IsEmailExists(txtEmail.Text))
            {
                MessageBox.Show("Email does not exist in our records.");
                return;
            }

            MailMessage message = new MailMessage
            {
                From = new MailAddress("lifelinebloodbankbd@gmail.com", "LifeLine Blood Bank"),
                Subject = "Password Reset OTP - LifeLine Blood Bank",
                Body = $"Dear User,<br><br>Your one-time password (OTP) for resetting your account password is: {OTPCode}.<br><br>" +
                       "Please use this code to complete the password reset process. This OTP is valid for a limited time and should not be shared with anyone for security purposes.<br><br>" +
                       "Thank you for using our services.<br><br>Best regards,<br>LifeLine Blood Bank",
                IsBodyHtml = true
            };

            to = txtEmail.Text;
            message.To.Add(to);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("lifelinebloodbankbd@gmail.com", "tpul kgmg gfrc nkki") // Consider using a secure way to handle passwords.
            };

            try
            {
                smtp.Send(message);
                MessageBox.Show("OTP sent successfully.");
                txtCode.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending OTP: " + ex.Message);
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (OTPCode == txtCode.Text)
            {
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
                // Update the password in the database
                userTbl.UpdatePassword(to, txtConfirmPass.Text);
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
                eye2.Image = Properties.Resources.eye;
            }
            else
            {
                txtConfirmPass.PasswordChar = '*';
                eye2.Image = Properties.Resources.eye;
            }
        }
    }
}
