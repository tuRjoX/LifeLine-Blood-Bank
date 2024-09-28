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
using System.Configuration;  

namespace LifeLineBloodBank.Forms
{
    public partial class Dashboard : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;

        public Dashboard()
        {
            InitializeComponent();
            GetData();
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
                label11.ForeColor = ThemeColor.SecondaryColor;
                TotalBStocklbl.ForeColor = ThemeColor.PrimaryColor;
                APlusNumlbl.ForeColor = ThemeColor.SecondaryColor;
                AMinusNumlbl.ForeColor = ThemeColor.PrimaryColor;
                BPlusNumlbl.ForeColor = ThemeColor.SecondaryColor;
                BMinusNumlbl.ForeColor = ThemeColor.PrimaryColor;
                ABPlusNumlbl.ForeColor = ThemeColor.SecondaryColor;
                ABMinusNumlbl.ForeColor = ThemeColor.PrimaryColor;
                OPlusNumlbl.ForeColor = ThemeColor.SecondaryColor;
                OMinusNumlbl.ForeColor = ThemeColor.PrimaryColor;
            }
        }

        private void GetData()
        {
            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                Con.Open();

                SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from DonorTbl", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Donorlbl.Text = dt.Rows[0][0].ToString();

                SqlDataAdapter sda1 = new SqlDataAdapter("Select count(*) from TransferTbl", Con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                TransferLbl.Text = dt1.Rows[0][0].ToString();

                SqlDataAdapter sda111 = new SqlDataAdapter("Select count(*) from PatientsTbl", Con);
                DataTable dt111 = new DataTable();
                sda111.Fill(dt111);
                PatientsLbl.Text = dt111.Rows[0][0].ToString();

                SqlDataAdapter sda1111 = new SqlDataAdapter("Select count(*) from RequestTbl", Con);
                DataTable dt1111 = new DataTable();
                sda1111.Fill(dt1111);
                Requestlbl.Text = dt1111.Rows[0][0].ToString();

                SqlDataAdapter sda100 = new SqlDataAdapter("SELECT SUM(BStock) FROM BloodTbl", Con);
                DataTable dt100 = new DataTable();
                sda100.Fill(dt100);
                int BStock = Convert.ToInt32(dt100.Rows[0][0].ToString());
                TotalBStocklbl.Text = "Total Stocks : " + BStock;

                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT SUM(BStock) FROM BloodTbl WHERE BGroup='A+'", Con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                APlusNumlbl.Text = dt2.Rows[0][0].ToString();
                double AplusPercentage = (Convert.ToDouble(dt2.Rows[0][0].ToString()) / BStock) * 100;
                APlusProgress.Value = Convert.ToInt32(AplusPercentage);

                SqlDataAdapter sda3 = new SqlDataAdapter("SELECT SUM(BStock) FROM BloodTbl WHERE BGroup='A-'", Con);
                DataTable dt3 = new DataTable();
                sda3.Fill(dt3);
                AMinusNumlbl.Text = dt3.Rows[0][0].ToString();
                double AminusPercentage = (Convert.ToDouble(dt3.Rows[0][0].ToString()) / BStock) * 100;
                AMinusProgress.Value = Convert.ToInt32(AminusPercentage);

                SqlDataAdapter sda4 = new SqlDataAdapter("SELECT SUM(BStock) FROM BloodTbl WHERE BGroup='AB+'", Con);
                DataTable dt4 = new DataTable();
                sda4.Fill(dt4);
                ABPlusNumlbl.Text = dt4.Rows[0][0].ToString();
                double ABplusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString()) / BStock) * 100;
                ABPlusProgress.Value = Convert.ToInt32(ABplusPercentage);

                SqlDataAdapter sda5 = new SqlDataAdapter("SELECT SUM(BStock) FROM BloodTbl WHERE BGroup='AB-'", Con);
                DataTable dt5 = new DataTable();
                sda5.Fill(dt5);
                ABMinusNumlbl.Text = dt5.Rows[0][0].ToString();
                double ABminusPercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / BStock) * 100;
                ABMinusProgress.Value = Convert.ToInt32(ABminusPercentage);

                SqlDataAdapter sda6 = new SqlDataAdapter("SELECT SUM(BStock) FROM BloodTbl WHERE BGroup='B+'", Con);
                DataTable dt6 = new DataTable();
                sda6.Fill(dt6);
                BPlusNumlbl.Text = dt6.Rows[0][0].ToString();
                double BplusPercentage = (Convert.ToDouble(dt6.Rows[0][0].ToString()) / BStock) * 100;
                BPlusProgress.Value = Convert.ToInt32(BplusPercentage);

                SqlDataAdapter sda7 = new SqlDataAdapter("SELECT SUM(BStock) FROM BloodTbl WHERE BGroup='B-'", Con);
                DataTable dt7 = new DataTable();
                sda7.Fill(dt7);
                BMinusNumlbl.Text = dt7.Rows[0][0].ToString();
                double BminusPercentage = (Convert.ToDouble(dt7.Rows[0][0].ToString()) / BStock) * 100;
                BMinusProgress.Value = Convert.ToInt32(BminusPercentage);

                SqlDataAdapter sda8 = new SqlDataAdapter("SELECT SUM(BStock) FROM BloodTbl WHERE BGroup='O+'", Con);
                DataTable dt8 = new DataTable();
                sda8.Fill(dt8);
                OPlusNumlbl.Text = dt8.Rows[0][0].ToString();
                double OplusPercentage = (Convert.ToDouble(dt8.Rows[0][0].ToString()) / BStock) * 100;
                OPlusProgress.Value = Convert.ToInt32(OplusPercentage);

                SqlDataAdapter sda9 = new SqlDataAdapter("SELECT SUM(BStock) FROM BloodTbl WHERE BGroup='O-'", Con);
                DataTable dt9 = new DataTable();
                sda9.Fill(dt9);
                OMinusNumlbl.Text = dt9.Rows[0][0].ToString();
                double OminusPercentage = (Convert.ToDouble(dt9.Rows[0][0].ToString()) / BStock) * 100;
                OMinusProgress.Value = Convert.ToInt32(OminusPercentage);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
