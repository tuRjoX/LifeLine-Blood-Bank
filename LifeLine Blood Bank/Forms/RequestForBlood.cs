using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using LifeLineBloodBank.Database; 

namespace LifeLineBloodBank.Forms
{
    public partial class RequestForBlood : Form
    {
        private int Id;
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private System.Drawing.Printing.PrintDocument printRequestInfo = new System.Drawing.Printing.PrintDocument();
        private RequestTbl requestTbl; 
        private UserTbl userTbl; 

        public RequestForBlood(int id)
        {
            InitializeComponent();
            Id = id;
            printRequestInfo.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printRequestInfo_PrintPage);
            requestTbl = new RequestTbl(); 
            userTbl = new UserTbl(); 
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
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = ThemeColor.PrimaryColor;
            label12.ForeColor = ThemeColor.SecondaryColor;
            label13.ForeColor = ThemeColor.PrimaryColor;
            label15.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
        }

        private void Reset()
        {
            RNameTb.Text = "";
            RPhone.Text = "";
            RBGroupCB.SelectedIndex = -1;
            REmail.Text = "";
        }

        private void FetchUserData(int userId)
        {
            try
            {
                DataRow userData = userTbl.LoadUserData(userId);
                RNameTb.Text = userData["UFullName"].ToString();
                RPhone.Text = userData["UPhone"].ToString();
                REmail.Text = userData["UEmail"].ToString(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching user data: " + ex.Message);
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
                    requestTbl.AddRequest(RNameTb.Text, RPhone.Text, REmail.Text, RBGroupCB.SelectedItem.ToString());
                    MessageBox.Show("Request Sent Successfully.");
                    SendEmail(REmail.Text, RNameTb.Text, RBGroupCB.SelectedItem.ToString());
                    printPreviewDialog1.Document = printRequestInfo;
                    printPreviewDialog1.ShowDialog();
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
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message);
            }
        }

        private void printRequestInfo_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font headerFont = new Font("Arial", 20, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 12);
            PointF startingPoint = new PointF(100, 100);
            e.Graphics.DrawString("Blood Request Information", headerFont, Brushes.Black, startingPoint);

            startingPoint.Y += 50;
            e.Graphics.DrawString($"Name: {RNameTb.Text}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Phone: {RPhone.Text}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Blood Group: {RBGroupCB.SelectedItem}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Email: {REmail.Text}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Date Created: {DateTime.Now.ToString("g")}", bodyFont, Brushes.Black, startingPoint);
        }
    }
}
