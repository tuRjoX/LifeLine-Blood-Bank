using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Configuration;

namespace LifeLineBloodBank.Forms
{
    public partial class RequestList : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;

        public RequestList()
        {
            InitializeComponent();
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
                label12.ForeColor = ThemeColor.SecondaryColor;
                label14.ForeColor = ThemeColor.PrimaryColor;
                label15.ForeColor = ThemeColor.SecondaryColor;
            }
        }
        private void populate()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT id, RName, RPhone, REmail, RBGroup FROM RequestTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                RequestDGV.DataSource = ds.Tables[0];
            }
        }
        private void bloodStock()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM BloodTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                BloodStockDGV.DataSource = ds.Tables[0];
            }
        }

        private int oldstock;
        private string selectedBloodGroup;
        private void GetStock(string Bgroup)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM BloodTbl WHERE BGroup = @Bgroup";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Bgroup", Bgroup);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        oldstock = Convert.ToInt32(dr["BStock"].ToString());
                    }
                }
            }
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

        private void updateStock()
        {
            int newstock = oldstock - 1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "UPDATE BloodTbl SET BStock = @newstock WHERE BGroup = @Bgroup";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@newstock", newstock);
                        cmd.Parameters.AddWithValue("@Bgroup", selectedBloodGroup);
                        cmd.ExecuteNonQuery();
                    }
                    bloodStock();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (oldstock > 0)
            {
                updateStock();
                DataGridViewRow selectedRow = RequestDGV.SelectedRows[0];
                string RName = selectedRow.Cells["RName"].Value.ToString();
                string RBGroup = selectedRow.Cells["RBGroup"].Value.ToString();
                string REmail = selectedRow.Cells["REmail"].Value.ToString();
                int requestId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        string insertQuery = "INSERT INTO TransferTbl (PName, BGroup) VALUES (@PName, @BGroup)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                        {
                            insertCmd.Parameters.AddWithValue("@PName", RName);
                            insertCmd.Parameters.AddWithValue("@BGroup", RBGroup);
                            insertCmd.ExecuteNonQuery();
                        }
                        string deleteQuery = "DELETE FROM RequestTbl WHERE id = @id";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con))
                        {
                            deleteCmd.Parameters.AddWithValue("@id", requestId);
                            deleteCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Blood Transferred Successfully.");

                        SendEmail(REmail, RName, RBGroup);
                        populate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
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
