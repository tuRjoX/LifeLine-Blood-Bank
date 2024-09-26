using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeLineBloodBank.Forms
{
    public partial class BloodStock : Form
    {
        public BloodStock()
        {
            InitializeComponent();
            BloodStocks();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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

                label5.ForeColor = ThemeColor.SecondaryColor;
                label1.ForeColor = ThemeColor.PrimaryColor;
            }
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

        private void BloodStock_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
