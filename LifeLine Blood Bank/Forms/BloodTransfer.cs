using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace LifeLineBloodBank.Forms
{
    public partial class BloodTransfer : Form
    {
        public BloodTransfer()
        {
            InitializeComponent();
            fillPatientCb();
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

                label1.ForeColor = ThemeColor.SecondaryColor;
                label2.ForeColor = ThemeColor.PrimaryColor;
                label3.ForeColor = ThemeColor.SecondaryColor;
                label5.ForeColor = ThemeColor.PrimaryColor;
                AvailableLbl.ForeColor = ThemeColor.SecondaryColor;
            }
        }
        private void fillPatientCb()
        {
            using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString))
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("select PNum from PatientsTbl", Con);
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("PNum", typeof(int));
                dt.Load(rdr);
                PatientIdCb.ValueMember = "PNum";
                PatientIdCb.DataSource = dt;
            }
        }

        private void GetData()
        {
            using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString))
            {
                Con.Open();
                string query = "select * from PatientsTbl where PNum=" + PatientIdCb.SelectedValue.ToString() + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    PatNameTb.Text = dr["PName"].ToString();
                    BloodGroup.Text = dr["PBGroup"].ToString();
                }
            }
        }

        int stock = 0;
        private void GetStock(string Bgroup)
        {
            using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString))
            {
                Con.Open();
                string query = "select * from BloodTbl where BGroup='" + Bgroup + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    stock = Convert.ToInt32(dr["BStock"].ToString());
                }
            }
        }

        private void PatientIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData();
            GetStock(BloodGroup.Text);
            if (stock > 0)
            {
                TransferBtn.Visible = true;
                AvailableLbl.Text = "Available Stock";
                AvailableLbl.Visible = true;
            }
            else
            {
                TransferBtn.Visible = false;
                AvailableLbl.Text = "Stock Not Available";
                AvailableLbl.Visible = true;
            }
        }

        private void Reset()
        {
            PatNameTb.Text = "";
            BloodGroup.Text = "";
            AvailableLbl.Visible = false;
            TransferBtn.Visible = false;
        }

        private void updateStock()
        {
            int newstock = stock - 1;
            using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString))
            {
                try
                {
                    string query = "update BloodTbl set BStock=" + newstock + " where BGroup='" + BloodGroup.Text + "';";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void TransferBtn_Click(object sender, EventArgs e)
        {
            if (PatNameTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString))
                {
                    try
                    {
                        string query = "insert into TransferTbl values('" + PatNameTb.Text + "','" + BloodGroup.Text + "' )";
                        Con.Open();
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully Transfer.");
                        GetStock(BloodGroup.Text);
                        updateStock();
                        Reset();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
        }

        private void BloodTransfer_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
