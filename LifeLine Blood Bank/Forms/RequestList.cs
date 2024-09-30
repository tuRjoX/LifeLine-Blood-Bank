using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Configuration;
using LifeLineBloodBank.Database;

namespace LifeLineBloodBank.Forms
{
    public partial class RequestList : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        private TransferTbl transferTbl; // Instance of TransferTbl
        private BloodTbl bloodTbl; // Instance of BloodTbl
        private RequestTbl requestTbl; // Instance of RequestTbl
        private int oldstock;
        private string selectedBloodGroup;

        public RequestList()
        {
            InitializeComponent();
            bloodTbl = new BloodTbl(); // Initialize BloodTbl
            requestTbl = new RequestTbl(); // Initialize RequestTbl
            transferTbl = new TransferTbl(); // Initialize TransferTbl
            bloodStock();
            populate();
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
            label12.ForeColor = ThemeColor.SecondaryColor;
            label14.ForeColor = ThemeColor.PrimaryColor;
            label15.ForeColor = ThemeColor.SecondaryColor;
        }

        private void populate()
        {
            RequestTbl requestTbl = new RequestTbl();
            DataTable requestData = requestTbl.GetAllRequests(); 
            RequestDGV.DataSource = requestData;
        }
        private void bloodStock()
        {
            BloodStockDGV.DataSource = bloodTbl.GetAllBloodStock();
        }

        private void GetStock(string Bgroup)
        {
            oldstock = bloodTbl.GetStockByBloodGroup(Bgroup);
        }

        private void RequestList_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void RequestDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = RequestDGV.Rows[e.RowIndex];
                selectedBloodGroup = row.Cells["RBGroup"].Value.ToString();
                GetStock(selectedBloodGroup);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (oldstock > 0)
            {
                int newstock = oldstock - 1;
                bloodTbl.UpdateStock(selectedBloodGroup, newstock);

                DataGridViewRow selectedRow = RequestDGV.SelectedRows[0];
                string RName = selectedRow.Cells["RName"].Value.ToString();
                string RBGroup = selectedRow.Cells["RBGroup"].Value.ToString();
                string REmail = selectedRow.Cells["REmail"].Value.ToString();
                int requestId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                // Add transfer record
                transferTbl.AddTransfer(RName, RBGroup);
                // Delete the request after transfer
                transferTbl.DeleteRequest(requestId);

                MessageBox.Show("Blood Transferred Successfully.");
                SendEmail(REmail, RName, RBGroup);
                populate();
            }
            else
            {
                MessageBox.Show("Insufficient Blood Stock");
            }
        }

        private void SendEmail(string toEmail, string userName, string bloodGroup)
        {
            try
            {
                string from = "lifelinebloodbankbd@gmail.com";
                string pass = "tpul kgmg gfrc nkki";
                string subject = "Blood Transfer Confirmation";
                string messageBody = $"Dear {userName},<br><br>Your request for blood group {bloodGroup} has been successfully fulfilled and transferred.<br><br>Thank you for trusting LifeLine Blood Bank.";

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
                MessageBox.Show("Blood transfer email notification sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message);
            }
        }
    }
}
