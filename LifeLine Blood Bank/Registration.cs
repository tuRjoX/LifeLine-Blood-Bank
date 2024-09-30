using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using LifeLineBloodBank.Database;

namespace LifeLineBloodBank
{
    public partial class Registration : Form
    {
        string OTPCode;
        public static string to;
        private UserTbl userTbl;

        public Registration()
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

        private void Registration_Load(object sender, EventArgs e)
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

        private void Reset()
        {
            txtUsername.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtConfirmPass.Text = "";
            txtCode.Text = "";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the username is already taken
                if (userTbl.IsUsernameTaken(txtUsername.Text))
                {
                    MessageBox.Show("This username already exists. Please choose a different username.");
                    return;
                }

                // Check if the email is already registered
                if (userTbl.IsEmailTaken(txtEmail.Text))
                {
                    MessageBox.Show("This email already exists. Please use a different email.");
                    return;
                }

                // Proceed with OTP generation and sending the email
                string from, pass, messageBody;
                Random rand = new Random();
                OTPCode = (rand.Next(999999)).ToString();

                MailMessage message = new MailMessage
                {
                    From = new MailAddress("lifelinebloodbankbd@gmail.com", "LifeLine Blood Bank"),
                    Subject = "Welcome to LifeLine Blood Bank! Verify Your Account with This OTP",
                    Body = $"Dear User,<br><br>Your one-time password (OTP) is: {OTPCode}.<br><br>" +
                           "Please use this code to complete the registration process. This OTP is valid for a limited time and should not be shared with anyone for security purposes.<br><br>" +
                           "Thank you for using our services.<br><br>Best regards,<br>LifeLine Blood Bank",
                    IsBodyHtml = true
                };
                message.To.Add(txtEmail.Text);

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("lifelinebloodbankbd@gmail.com", "tpul kgmg gfrc nkki");
                    smtp.Send(message);
                }

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCode.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                MessageBox.Show("Missing Info. Please fill in all the fields.");
                return;
            }

            string phone = txtPhone.Text;
            if (phone.Length != 11 || !(phone.StartsWith("018") || phone.StartsWith("014") || phone.StartsWith("017") ||
                                       phone.StartsWith("013") || phone.StartsWith("015") || phone.StartsWith("016")))
            {
                MessageBox.Show("Invalid phone number.");
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
                try
                {
                    // Register the new user
                    userTbl.RegisterUser(txtUsername.Text, txtFullName.Text, txtPhone.Text, txtEmail.Text, txtPassword.Text);
                    MessageBox.Show("Registration Successful.");
                    Reset();
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match. Please try again.");
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
