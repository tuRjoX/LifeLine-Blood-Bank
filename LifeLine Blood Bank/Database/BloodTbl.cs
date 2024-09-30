using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LifeLineBloodBank.Database
{
    public class BloodTbl
    {
        private readonly string connectionString;

        public BloodTbl()
        {
            connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        }

        // Method to get all blood stock
        public DataTable GetAllBloodStock()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM BloodTbl";

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
                    throw new Exception("Error retrieving blood stock.", ex);
                }
            }

            return dt;
        }

        // Method to get blood stock by blood group
        public int GetStockByBloodGroup(string BGroup)
        {
            int stock = 0;
            string query = "SELECT BStock FROM BloodTbl WHERE BGroup = @BGroup";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BGroup", BGroup);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                stock = Convert.ToInt32(reader["BStock"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving blood stock for the specified blood group.", ex);
                }
            }

            return stock;
        }
        // Method to retrieve blood stocks by blood type
        public DataTable GetBloodStockByType(string bloodType)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM BloodTbl WHERE BGroup = @BT";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.Parameters.AddWithValue("@BT", bloodType);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }
        // Method to update blood stock
        public void UpdateStock(string BGroup, int newStock)
        {
            string query = "UPDATE BloodTbl SET BStock = @newStock WHERE BGroup = @BGroup";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@newStock", newStock);
                        cmd.Parameters.AddWithValue("@BGroup", BGroup);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating blood stock.", ex);
                }
            }
        }
    }
}
