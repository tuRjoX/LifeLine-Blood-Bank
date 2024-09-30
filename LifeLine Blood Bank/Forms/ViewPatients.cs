using LifeLineBloodBank.Database;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LifeLineBloodBank.Forms
{
    public partial class ViewPatients : Form
    {
        private PatientsTbl patientsTbl = new PatientsTbl();
        private int key = 0;

        public ViewPatients()
        {
            InitializeComponent();
            populate();
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
                label1.ForeColor = ThemeColor.PrimaryColor;
                label2.ForeColor = ThemeColor.SecondaryColor;
                label3.ForeColor = ThemeColor.PrimaryColor;
                label4.ForeColor = ThemeColor.SecondaryColor;
                label5.ForeColor = ThemeColor.PrimaryColor;
                label6.ForeColor = ThemeColor.SecondaryColor;
                label7.ForeColor = ThemeColor.PrimaryColor;
                label8.ForeColor = ThemeColor.SecondaryColor;
                label10.ForeColor = ThemeColor.PrimaryColor;
                label9.ForeColor = ThemeColor.SecondaryColor;
            }
        }

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
            PatientsDGV.DataSource = patientsTbl.GetPatients();
        }

        private void PatientsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

            key = string.IsNullOrEmpty(PNameTb.Text) ? 0 : Convert.ToInt32(PatientsDGV.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" || PAgeTb.Text == "" || PPhoneTb.Text == "" || PGenderCb.SelectedIndex == -1 || PBGroupCb.SelectedIndex == -1 || PAdressTb.Text == "" || PDListCb.SelectedIndex == -1 || PWNoCb.SelectedIndex == -1 || PBNoCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string phone = PPhoneTb.Text;
                string[] validPrefixes = { "014", "013", "017", "018", "016", "015" };
                bool isPhoneValid = phone.Length == 11 && validPrefixes.Any(prefix => phone.StartsWith(prefix));

                if (!isPhoneValid)
                {
                    MessageBox.Show("Incorrect Number.");
                    return;
                }

                try
                {
                    patientsTbl.UpdatePatient(key, PNameTb.Text, PAgeTb.Text, PPhoneTb.Text, PGenderCb.SelectedItem.ToString(),
                                              PBGroupCb.SelectedItem.ToString(), PAdressTb.Text, PDListCb.SelectedItem.ToString(),
                                              PWNoCb.SelectedItem.ToString(), PBNoCb.SelectedItem.ToString());

                    MessageBox.Show("Patient Successfully Updated");
                    Reset();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Patient to Delete");
            }
            else
            {
                try
                {
                    patientsTbl.DeletePatient(key);
                    MessageBox.Show("Patient Successfully Deleted");
                    Reset();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ViewPatients_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
