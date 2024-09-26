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

namespace LifeLineBloodBank
{
    public partial class BloodStock : Form
    {
        public BloodStock()
        {
            InitializeComponent();
            BloodStocks();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString);
        private void BloodStocks()
        {
            try
            {
                Con.Open();
                string Query = "select * from BloodTbl";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                BloodStockDGV.DataSource = ds.Tables[0];
                BloodStockDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                BloodStockDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                BloodStockDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBloodType = comboBox1.SelectedItem.ToString();
            if (selectedBloodType == "All")
            {
                BloodStocks();
                return;
            }
            Con.Open();
            string Query = "select * from BloodTbl where BGroup = @BT";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            sda.SelectCommand.Parameters.AddWithValue("@BT", selectedBloodType);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BloodStockDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
