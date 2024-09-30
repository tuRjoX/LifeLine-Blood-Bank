using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LifeLineBloodBank.Database
{
    public class DonorTbl
    {
        private readonly string connectionString;

        public DonorTbl()
        {
            connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        }
        public void AddDonor(string name, int age, string gender, string phone, string address, string bloodGroup)
        {
            string query = "INSERT INTO DonorTbl (DName, DAge, DGender, DPhone, DAddress, DBGroup) VALUES (@DName, @DAge, @DGender, @DPhone, @DAddress, @DBGroup)";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@DName", name);
                        cmd.Parameters.AddWithValue("@DAge", age);
                        cmd.Parameters.AddWithValue("@DGender", gender);
                        cmd.Parameters.AddWithValue("@DPhone", phone);
                        cmd.Parameters.AddWithValue("@DAddress", address);
                        cmd.Parameters.AddWithValue("@DBGroup", bloodGroup);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding donor.", ex);
                }
            }
        }
        // Method to retrieve all donors
        public DataTable GetAllDonors()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM DonorTbl";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                    {
                        sda.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching donor data.", ex);
                }
            }
            return dt;
        }
        // Method to filter donors by name
        public DataTable FilterDonorsByName(string donorName)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM DonorTbl WHERE DName LIKE @DN";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@DN", "%" + donorName + "%");
                        sda.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error filtering donors by name.", ex);
                }
            }

            return dt;
        }
        // Method to delete a donor
        public void DeleteDonor(int donorId)
        {
            string query = "DELETE FROM DonorTbl WHERE DNum = @DNum";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@DNum", donorId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting donor.", ex);
                }
            }
        }

        // Method to update a donor
        public void UpdateDonor(int donorId, string name, int age, string gender, string phone, string address, string bloodGroup)
        {
            string query = "UPDATE DonorTbl SET DName = @DName, DAge = @DAge, DGender = @DGender, " +
                           "DPhone = @DPhone, DAddress = @DAddress, DBGroup = @DBGroup WHERE DNum = @DNum";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@DName", name);
                        cmd.Parameters.AddWithValue("@DAge", age);
                        cmd.Parameters.AddWithValue("@DGender", gender);
                        cmd.Parameters.AddWithValue("@DPhone", phone);
                        cmd.Parameters.AddWithValue("@DAddress", address);
                        cmd.Parameters.AddWithValue("@DBGroup", bloodGroup);
                        cmd.Parameters.AddWithValue("@DNum", donorId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating donor.", ex);
                }
            }
        }
    }
}
