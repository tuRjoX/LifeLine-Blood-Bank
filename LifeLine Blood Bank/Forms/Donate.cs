using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LifeLineBloodBank.Forms
{
    public partial class Donate : Form
    {
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
        SqlConnection Con = new SqlConnection("Data Source=TURJO\\SQLEXPRESS02;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True");
        private void populate()
        {
            Con.Open();
            String Query = "select * from DonorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonorsDGV.DataSource = ds.Tables[0];
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

        private void Donate_Load(object sender, EventArgs e)
        {

        }
        int oldstock;
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
            if (DNameTb.Text == "")
            {
                MessageBox.Show("Select A Donor");
            }
            else
            {
                try
                {
                    int stock = oldstock + 1;
                    string query = "update BloodTbl set BStock = " + stock + "where BGroup='" + BGroupTb.Text + "';";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donation Successful");
                    Con.Close();
                    reset();
                    bloodStock();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Donate_Load_1(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
