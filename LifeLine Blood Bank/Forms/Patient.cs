using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing.Printing;

namespace LifeLineBloodBank
{
    public partial class Patient : Form
    {
        private PrintDocument printPatientsInfo = new PrintDocument(); 
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog(); 

        public Patient()
        {
            InitializeComponent();
            printPatientsInfo.PrintPage += new PrintPageEventHandler(printPatientsInfo_PrintPage);
            printPreviewDialog1.Document = printPatientsInfo;
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
        }

        SqlConnection Con = new SqlConnection("Data Source=TURJO\\SQLEXPRESS02;Initial Catalog=BloodBankDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        private void Reset()
        {
            PNameTb.Text = "";
            PAgeTb.Text = "";
            PPhoneTb.Text = "";
            PAdressTb.Text = "";
            PGenderCb.SelectedIndex = -1;
            PBGroupCb.SelectedIndex = -1;
            PDListCb.SelectedIndex = -1;
            PWNoCb.SelectedIndex = -1;
            PBNoCb.SelectedIndex = -1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" || PAgeTb.Text == "" || PPhoneTb.Text == "" || PGenderCb.SelectedIndex == -1 || PBGroupCb.SelectedIndex == -1 || PAdressTb.Text == "" || PDListCb.SelectedIndex == -1 || PWNoCb.SelectedIndex == -1 || PBNoCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                int age;
                bool isAgeValid = int.TryParse(PAgeTb.Text, out age);
                if (!isAgeValid || age <= 17)
                {
                    MessageBox.Show("Age must be greater than 17.");
                    return;
                }
                string phone = PPhoneTb.Text;
                string[] validPrefixes = { "014", "017", "018", "016", "015" };
                bool isPhoneValid = phone.Length == 11 && validPrefixes.Any(prefix => phone.StartsWith(prefix));

                if (!isPhoneValid)
                {
                    MessageBox.Show("Incorrect Mobile Number.");
                    return;
                }

                try
                {
                    string query = $"insert into PatientsTbl (PName, PAge, PPhone, PGender, PBGroup, PAdress, PDList, PWNo, PBNo, CreatedDate) " +
                                   $"Values ('{PNameTb.Text}','{PAgeTb.Text}','{PPhoneTb.Text}', '{PGenderCb.SelectedItem.ToString()}', " +
                                   $"'{PBGroupCb.SelectedItem.ToString()}', '{PAdressTb.Text}', '{PDListCb.SelectedItem.ToString()}', " +
                                   $"'{PWNoCb.SelectedItem.ToString()}', '{PBNoCb.SelectedItem.ToString()}', GETDATE())";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Saved");

                    printPreviewDialog1.Document = printPatientsInfo;
                    printPreviewDialog1.ShowDialog();
                    Con.Close();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void printPatientsInfo_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font headerFont = new Font("Arial", 20, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 12);
            PointF startingPoint = new PointF(100, 100);
            e.Graphics.DrawString("Patient Information", headerFont, Brushes.Black, startingPoint);
            startingPoint.Y += 50; 
            e.Graphics.DrawString($"Name: {PNameTb.Text}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Age: {PAgeTb.Text}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Phone: {PPhoneTb.Text}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Gender: {PGenderCb.SelectedItem}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Blood Group: {PBGroupCb.SelectedItem}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Address: {PAdressTb.Text}", bodyFont, Brushes.Black, startingPoint);

            startingPoint.Y += 30;
            e.Graphics.DrawString($"Date Created: {DateTime.Now.ToString("g")}", bodyFont, Brushes.Black, startingPoint);
        }

    }
}


