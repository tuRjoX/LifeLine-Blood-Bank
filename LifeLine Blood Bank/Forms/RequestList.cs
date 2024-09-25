using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeLineBloodBank.Forms
{
    public partial class RequestList : Form
    {
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
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                label12.ForeColor = ThemeColor.SecondaryColor;
                label14.ForeColor = ThemeColor.PrimaryColor;
                label15.ForeColor = ThemeColor.SecondaryColor;
            }
        }

        SqlConnection Con = new SqlConnection("Data Source=TURJO\\SQLEXPRESS02;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True");

        private void populate()
        {
            Con.Open();
            String Query = "select id, RName, RPhone,REmail, RBGroup from RequestTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            RequestDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void bloodStock()
        {
            Con.Open();
            String Query = "select * from BloodTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BloodStockDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        int oldstock;
        string selectedBloodGroup;
        private void GetStock(string Bgroup)
        {
            Con.Open();
            string query = "select * from BloodTbl where BGroup = @Bgroup";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.Parameters.AddWithValue("@Bgroup", Bgroup);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString());
            }
            Con.Close();
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
            try
            {
                string query = "update BloodTbl set BStock = @newstock where BGroup = @Bgroup";
                Con.Open();
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@newstock", newstock);
                cmd.Parameters.AddWithValue("@Bgroup", selectedBloodGroup);
                cmd.ExecuteNonQuery();
                Con.Close();
                bloodStock();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
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
                string REmail = selectedRow.Cells["REmail"].Value.ToString(); // Get the email
                int requestId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                try
                {
                    // Insert into TransferTbl
                    string insertQuery = "insert into TransferTbl (PName, BGroup) values (@PName, @BGroup)";
                    Con.Open();
                    SqlCommand insertCmd = new SqlCommand(insertQuery, Con);
                    insertCmd.Parameters.AddWithValue("@PName", RName);
                    insertCmd.Parameters.AddWithValue("@BGroup", RBGroup);
                    insertCmd.ExecuteNonQuery();

                    // Delete from RequestTbl
                    string deleteQuery = "delete from RequestTbl where id = @id";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, Con);
                    deleteCmd.Parameters.AddWithValue("@id", requestId);
                    deleteCmd.ExecuteNonQuery();

                    Con.Close();
                    MessageBox.Show("Blood Transferred Successfully, Record Inserted and Request Deleted.");

                    // Send success email after blood transfer
                    SendEmail(REmail, RName, RBGroup);

                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
