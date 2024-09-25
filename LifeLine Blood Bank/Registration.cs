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

namespace LifeLineBloodBank
{
    public partial class Registration : Form
    {
        string OTPCode;
        public static string to;
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

        SqlConnection Con = new SqlConnection("Data Source=TURJO\\SQLEXPRESS02;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True");

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
                // Check if the email already exists
                string emailCheckQuery = "SELECT COUNT(*) FROM UsersTbl WHERE UEmail = @UE";
                SqlCommand emailCheckCmd = new SqlCommand(emailCheckQuery, Con);
                emailCheckCmd.Parameters.AddWithValue("@UE", txtEmail.Text);

                Con.Open();
                int emailCount = (int)emailCheckCmd.ExecuteScalar();
                Con.Close();

                if (emailCount > 0)
                {
                    MessageBox.Show("This email already exists. Please use a different email.");
                    return;
                }

                // Check if the username already exists
                string usernameCheckQuery = "SELECT COUNT(*) FROM UsersTbl WHERE UName = @UN";
                SqlCommand usernameCheckCmd = new SqlCommand(usernameCheckQuery, Con);
                usernameCheckCmd.Parameters.AddWithValue("@UN", txtUsername.Text);

                Con.Open();
                int usernameCount = (int)usernameCheckCmd.ExecuteScalar();
                Con.Close();

                if (usernameCount > 0)
                {
                    MessageBox.Show("This username already exists. Please choose a different username.");
                    return;
                }

                // Proceed with OTP generation and sending if both email and username are unique
                string from, pass, messageBody;
                Random rand = new Random();
                OTPCode = (rand.Next(999999)).ToString();

                MailMessage message = new MailMessage();
                to = txtEmail.Text;
                from = "lifelinebloodbankbd@gmail.com";
                pass = "tpul kgmg gfrc nkki";
                messageBody = "Your one-time password is : " + OTPCode;
                message.To.Add(to);
                message.From = new MailAddress("lifelinebloodbankbd@gmail.com", "LifeLine Blood Bank");
                message.Body = messageBody;
                message.Subject = "Welcome to LifeLine Blood Bank! Verify Your Account with This OTP";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                    $"Dear User,<br><br>Your one-time password (OTP) password is: {OTPCode}.<br><br>" +
                    "Please use this code to complete the password reset process. This OTP is valid for a limited time and should not be shared with anyone for security purposes.<br><br>" +
                    "Thank you for using our services.<br><br>Best regards,<br>LifeLine Blood Bank<br><br>" +
                    "<hr><br>" +
                    "<b>LifeLine Blood Bank</b><br>" +
                    "House 11, Road 62, Gulshan 2 <br>" +
                    "Dhaka, Bangladesh<br>" +
                    "Phone: (+880) 185 656 4543<br>" +
                    "Email: support@lifelinebloodbank.com<br>" +
                    "<a href='https://www.lifelinebloodbank.com'>www.lifelinebloodbank.com</a><br>" +
                    "<img src=cid:logoImage>",  
                    null, "text/html"
                );
                LinkedResource logo = new LinkedResource(@"C:\Users\tdas4\source\repos\GUI\Background1.png");
                logo.ContentId = "logoImage";
                htmlView.LinkedResources.Add(logo);
                message.AlternateViews.Add(htmlView);

                message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                smtp.Send(message);

                MessageBox.Show("OTP sent successfully.");
                txtCode.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }


        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (OTPCode == (txtCode.Text).ToString())
            {
                to = txtEmail.Text;
                MessageBox.Show("Verification Sucessful.");
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
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtCode.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                MessageBox.Show("Missing Info. Please fill in all the fields.");
                return;
            }

            if (txtPassword.Text == txtConfirmPass.Text)
            {
                string query = "INSERT INTO UsersTbl (UName, UFullName, UPhone, UEmail, UPassword) VALUES (@UN, @UFN, @UP, @UE, @UPASS)";

                using (SqlConnection con = new SqlConnection("Data Source=TURJO\\SQLEXPRESS02;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UN", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@UFN", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@UP", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@UE", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@UPASS", txtPassword.Text);

                    try
                    {
                        con.Open(); 
                        cmd.ExecuteNonQuery();
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
