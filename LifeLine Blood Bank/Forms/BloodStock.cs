using LifeLineBloodBank.Database;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LifeLineBloodBank.Forms
{
    public partial class BloodStock : Form
    {
        private BloodTbl bloodTbl = new BloodTbl(); 

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
                if (btns is Button btn)
                {
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }

                label5.ForeColor = ThemeColor.SecondaryColor;
                label1.ForeColor = ThemeColor.PrimaryColor;
            }
        }
        private void BloodStocks()
        {
            try
            {
                DataTable dt = bloodTbl.GetAllBloodStock();  
                BloodStockDGV.DataSource = dt;
                BloodStockDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                BloodStockDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                BloodStockDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBloodType = comboBox1.SelectedItem.ToString();
            try
            {
                if (selectedBloodType == "All")
                {
                    BloodStocks(); 
                }
                else
                {
                    DataTable dt = bloodTbl.GetBloodStockByType(selectedBloodType);  
                    BloodStockDGV.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BloodStock_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
