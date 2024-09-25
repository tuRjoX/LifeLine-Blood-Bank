using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration; 

namespace LifeLineBloodBank.Forms
{
    public partial class Donate : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;

        public Donate()
        {
            InitializeComponent();
            populate();
            bloodStock();
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
                label12.ForeColor = ThemeColor.PrimaryColor;
                label13.ForeColor = ThemeColor.SecondaryColor;
                label14.ForeColor = ThemeColor.PrimaryColor;
                label15.ForeColor = ThemeColor.SecondaryColor;
            }
        }
        private void populate()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM DonorTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DonorsDGV.DataSource = ds.Tables[0];
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

        private void Donate_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        int oldstock;
        private void GetStock(string Bgroup)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT BStock FROM BloodTbl WHERE BGroup = @Bgroup";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Bgroup", Bgroup);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    oldstock = Convert.ToInt32(dt.Rows[0]["BStock"].ToString());
                }
            }
        }
        private void DonorsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DNameTb.Text = DonorsDGV.SelectedRows[0].Cells[1].Value.ToString();
            BGroupTb.Text = DonorsDGV.SelectedRows[0].Cells[6].Value.ToString();
            GetStock(BGroupTb.Text);
        }
        private void reset()
        {
            DNameTb.Text = "";
            BGroupTb.Text = "";
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DNameTb.Text))
            {
                MessageBox.Show("Select A Donor");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    int newStock = oldstock + 1;
                    string query = "UPDATE BloodTbl SET BStock = @newStock WHERE BGroup = @Bgroup";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@newStock", newStock);
                    cmd.Parameters.AddWithValue("@Bgroup", BGroupTb.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Donation Successful");

                    reset();
                    bloodStock();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Donate_Load_1(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
