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
    public partial class UpdateDonor : Form
    {
        public UpdateDonor()
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
                label1.ForeColor = ThemeColor.PrimaryColor;
                label11.ForeColor = ThemeColor.SecondaryColor;
                label12.ForeColor = ThemeColor.PrimaryColor;
                label13.ForeColor = ThemeColor.SecondaryColor;
                label14.ForeColor = ThemeColor.PrimaryColor;
                label15.ForeColor = ThemeColor.SecondaryColor;
                label16.ForeColor = ThemeColor.PrimaryColor;
                DonorDGV.ForeColor = ThemeColor.SecondaryColor;
            }
        }
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString);

        private void Reset()
        {
            DNameTb.Text = "";
            DAgeTb.Text = "";
            DPhone.Text = "";
            DGenderCB.SelectedIndex = -1;
            DBGroupCB.SelectedIndex = -1;
            DAddressTbl.Text = "";
            key = 0;
        }

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

        int key = 0;

        private void DonorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DNameTb.Text = DonorDGV.SelectedRows[0].Cells[1].Value.ToString();
            DAgeTb.Text = DonorDGV.SelectedRows[0].Cells[2].Value.ToString();
            DGenderCB.SelectedItem = DonorDGV.SelectedRows[0].Cells[3].Value.ToString();
            DPhone.Text = DonorDGV.SelectedRows[0].Cells[4].Value.ToString();
            DAddressTbl.Text = DonorDGV.SelectedRows[0].Cells[5].Value.ToString();
            DBGroupCB.SelectedItem = DonorDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (DNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DonorDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select A Donor");
            }
            else
            {
                try
                {
                    String query = "Delete from DonorTbl where DNum=" + key + ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Deleted Successfully.");
                    Con.Close();
                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (DNameTb.Text == "" || DPhone.Text == "" || DAgeTb.Text == "" || DGenderCB.SelectedIndex == -1 || DBGroupCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information.");
            }
            else if (!int.TryParse(DAgeTb.Text, out int age) || age <= 17)
            {
                MessageBox.Show("Age must be greater than 17.");
            }
            else if (DPhone.Text.Length != 11 || !long.TryParse(DPhone.Text, out _) ||
            !(DPhone.Text.StartsWith("018") || DPhone.Text.StartsWith("015") ||
            DPhone.Text.StartsWith("014") || DPhone.Text.StartsWith("017") ||
            DPhone.Text.StartsWith("016")))
            {
                MessageBox.Show("Incorrect Mobile Number.");
            }
            else
            {
                try
                {
                    String query = "update DonorTbl set DName='" + DNameTb.Text + "', DAge='" + DAgeTb.Text + "', DGender='" + DGenderCB.SelectedItem.ToString() + "', DPhone='" + DPhone.Text + "', DAddress='" + DAddressTbl.Text + "', DBGroup='" + DBGroupCB.SelectedItem.ToString() + "' where DNum=" + key + ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Updated Successfully.");
                    Con.Close();
                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void UpdateDonor_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
