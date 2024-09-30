using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using LifeLineBloodBank.Database;

namespace LifeLineBloodBank.Forms
{
    public partial class Patients : Form
    {
        private PrintDocument printPatientsInfo = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PatientsTbl patientsTbl = new PatientsTbl();  

        public Patients()
        {
            InitializeComponent();
            printPatientsInfo.PrintPage += new PrintPageEventHandler(printPatientsInfo_PrintPage);
            printPreviewDialog1.Document = printPatientsInfo;
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns is Button btn)
                {
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                label1.ForeColor = ThemeColor.PrimaryColor;
                label2.ForeColor = ThemeColor.SecondaryColor;
                label3.ForeColor = ThemeColor.PrimaryColor;
                label4.ForeColor = ThemeColor.SecondaryColor;
                label5.ForeColor = ThemeColor.PrimaryColor;
                label6.ForeColor = ThemeColor.SecondaryColor;
                label7.ForeColor = ThemeColor.PrimaryColor;
                label8.ForeColor = ThemeColor.SecondaryColor;
                label10.ForeColor = ThemeColor.PrimaryColor;
                label9.ForeColor = ThemeColor.SecondaryColor;
            }
        }
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PNameTb.Text) || string.IsNullOrEmpty(PAgeTb.Text) || string.IsNullOrEmpty(PPhoneTb.Text) ||
                PGenderCb.SelectedIndex == -1 || PBGroupCb.SelectedIndex == -1 || string.IsNullOrEmpty(PAdressTb.Text) ||
                PDListCb.SelectedIndex == -1 || PWNoCb.SelectedIndex == -1 || PBNoCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
                return;
            }

            string phone = PPhoneTb.Text;
            string[] validPrefixes = { "014", "013", "017", "018", "016", "015" };
            bool isPhoneValid = phone.Length == 11 && validPrefixes.Any(prefix => phone.StartsWith(prefix));

            if (!isPhoneValid)
            {
                MessageBox.Show("Incorrect Mobile Number.");
                return;
            }

            try
            {
                patientsTbl.InsertPatient(PNameTb.Text, PAgeTb.Text, PPhoneTb.Text, PGenderCb.SelectedItem.ToString(),
                                         PBGroupCb.SelectedItem.ToString(), PAdressTb.Text, PDListCb.SelectedItem.ToString(),
                                         PWNoCb.SelectedItem.ToString(), PBNoCb.SelectedItem.ToString());

                MessageBox.Show("Patient Successfully Saved");

                printPreviewDialog1.Document = printPatientsInfo;
                printPreviewDialog1.ShowDialog();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            e.Graphics.DrawString($"Department List: {PDListCb.SelectedItem}", bodyFont, Brushes.Black, startingPoint);
            startingPoint.Y += 30;
            e.Graphics.DrawString($"Ward No: {PWNoCb.SelectedItem}", bodyFont, Brushes.Black, startingPoint);
            startingPoint.Y += 30;
            e.Graphics.DrawString($"Bed No: {PBNoCb.SelectedItem}", bodyFont, Brushes.Black, startingPoint);
            startingPoint.Y += 30;
            e.Graphics.DrawString($"Date Created: {DateTime.Now.ToString("g")}", bodyFont, Brushes.Black, startingPoint);
        }

        private void Patients_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
