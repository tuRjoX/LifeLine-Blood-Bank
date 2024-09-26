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
namespace LifeLineBloodBank
{
    public partial class View_Patients : Form
    {
        public View_Patients()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection("Data Source=TURJO\\SQLEXPRESS02;Initial Catalog=BloodBankDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
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
            key = 0;
        }
        private void populate()
        {
            Con.Open();
            string Query = "select * from PatientsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PatientsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        int key = 0;
        private void View_Patients_Load(object sender, EventArgs e)
        {

        }
        private void PatientsDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            PNameTb.Text = PatientsDGV.SelectedRows[0].Cells[1].Value.ToString();
            PAgeTb.Text = PatientsDGV.SelectedRows[0].Cells[2].Value.ToString();
            PPhoneTb.Text = PatientsDGV.SelectedRows[0].Cells[3].Value.ToString();
            PGenderCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[4].Value.ToString();
            PBGroupCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[5].Value.ToString();
            PAdressTb.Text = PatientsDGV.SelectedRows[0].Cells[6].Value.ToString();
            PDListCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[7].Value.ToString();
            PWNoCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[8].Value.ToString();
            PBNoCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[9].Value.ToString();

            if (PNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Patient to Delete");
            }
            else
            {
                try
                {
                    string query = "Delete From PatientsTbl where PNum = " + key + ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Deleted");
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" || PAgeTb.Text == "" || PPhoneTb.Text == "" || PGenderCb.SelectedIndex == -1 || PBGroupCb.SelectedIndex == -1 || PAdressTb.Text == "" || PDListCb.SelectedIndex == -1 || PWNoCb.SelectedIndex == -1 || PBNoCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                int age;
                bool isAgeValid = int.TryParse(PAgeTb.Text, out age);
                if (!isAgeValid || age <= 17)
                {
                    MessageBox.Show("Age must be greater than 17.");
                    return;
                }
                string phone = PPhoneTb.Text;
                string[] validPrefixes = { "014", "017", "018", "016", "015" };
                bool isPhoneValid = phone.Length == 11 && validPrefixes.Any(prefix => phone.StartsWith(prefix));

                if (!isPhoneValid)
                {
                    MessageBox.Show("Mobile number must be 11 digits and start with 014, 017, 018, 016, or 015.");
                    return;
                }

                try
                {
                    string query = "update PatientsTbl set Pname='" + PNameTb.Text + "',Page='" + PAgeTb.Text + "',Pphone='" + PPhoneTb.Text + "',PGender='" + PGenderCb.SelectedItem.ToString() + "',PBGroup='" + PBGroupCb.SelectedItem.ToString() + "',Padress='" + PAdressTb.Text + "',PDList='" + PDListCb.SelectedItem.ToString() + "',PWNo='" + PWNoCb.SelectedItem.ToString() + "' ,PBNo='" + PBNoCb.SelectedItem.ToString() + "' where PNum=" + key + ";";

                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Updated");

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

        private void label1_Click(object sender, EventArgs e)
        {
            View_Patients view_Patients = new View_Patients();
            view_Patients.Show();
            this.Hide();
        }

        private void DGenderCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

    }
}
