﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeLineBloodBank.Forms
{
    public partial class DonateBlood : Form
    {
        public DonateBlood()
        {
            InitializeComponent();
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
                label1.ForeColor = ThemeColor.PrimaryColor;
                label11.ForeColor = ThemeColor.SecondaryColor;
                label12.ForeColor = ThemeColor.PrimaryColor;
                label13.ForeColor = ThemeColor.SecondaryColor;
                label14.ForeColor = ThemeColor.PrimaryColor;
                label15.ForeColor = ThemeColor.SecondaryColor;
                label16.ForeColor = ThemeColor.PrimaryColor;
            }
        }
        
        SqlConnection Con = new SqlConnection("Data Source=TURJO\\SQLEXPRESS02;Initial Catalog=BloodBankDb;Integrated Security=True;TrustServerCertificate=True");
        private void Reset()
        {
            DNameTb.Text = "";
            DAgeTb.Text = "";
            DPhone.Text = "";
            DGenderCB.SelectedIndex = -1;
            DBGroupCB.SelectedIndex = -1;
            DAddressTbl.Text = "";
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (DNameTb.Text == "" || DPhone.Text == "" || DAgeTb.Text == "" || DGenderCB.SelectedIndex == -1 || DBGroupCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information.");
            }
            else if (DPhone.Text.Length != 11 || !long.TryParse(DPhone.Text, out _))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.");
            }
            else
            {
                try
                {
                    String query = "insert into DonorTbl values('" + DNameTb.Text + "','" + DAgeTb.Text + "','" + DGenderCB.SelectedItem.ToString() + "','" + DPhone.Text + "','" + DAddressTbl.Text + "','" + DBGroupCB.SelectedItem.ToString() + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Successfully Saved.");
                    Con.Close();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void LoadUserData(int userId) // Pass the user ID
        {
            try
            {
                string query = "SELECT UName,UFullName, UPhone FROM UsersTbl WHERE Id = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId); // Use parameters to prevent SQL injection
                    Con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        DNameTb.Text = reader["UFullName"].ToString();
                        txtUName.Text = reader["UName"].ToString();
                        DPhone.Text = reader["UPhone"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("User not found.");
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DonateBlood_Load(object sender, EventArgs e)
        {
            LoadUserData(100);
            LoadTheme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DNameTb.Text == "" || DPhone.Text == "" || DAgeTb.Text == "" || DGenderCB.SelectedIndex == -1 || DBGroupCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information.");
            }
            else if (DPhone.Text.Length != 11 || !long.TryParse(DPhone.Text, out _))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.");
            }
            else if (!int.TryParse(DAgeTb.Text, out int age) || age <= 17)
            {
                MessageBox.Show("Age must be greater than 17.");
            }
            else
            {
                try
                {
                    String query = "insert into DonorTbl values('" + DNameTb.Text + "','" + DAgeTb.Text + "','" + DGenderCB.SelectedItem.ToString() + "','" + DPhone.Text + "','" + DAddressTbl.Text + "','" + DBGroupCB.SelectedItem.ToString() + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Successfully Saved.");
                    Con.Close();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
