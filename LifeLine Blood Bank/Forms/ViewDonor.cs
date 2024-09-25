using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; // Add this
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeLineBloodBank.Forms
{
    public partial class ViewDonor : Form
    {
        public ViewDonor()
        {
            InitializeComponent();
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
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                label10.ForeColor = ThemeColor.PrimaryColor;
                label11.ForeColor = ThemeColor.SecondaryColor;
            }
        }

        // Use the connection string from app.config
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString);

        private void populate()
        {
            Con.Open();
            String Query = "select * from DonorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonorDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterDonorsByName(textBox1.Text);
        }

        private void FilterDonorsByName(string donorName)
        {
            try
            {
                Con.Open();
                String Query = "SELECT * FROM DonorTbl WHERE DName LIKE @DN";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                sda.SelectCommand.Parameters.AddWithValue("@DN", "%" + donorName + "%");
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DonorDGV.DataSource = ds.Tables[0];
            }
            finally
            {
                Con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implement any actions needed when a cell is clicked
        }

        private void ViewDonor_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
