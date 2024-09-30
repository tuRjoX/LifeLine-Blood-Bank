using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LifeLineBloodBank.Database
{
    public class RequestTbl
    {
        private readonly string connectionString;

        public RequestTbl()
        {
            connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        }

        // Method to add a blood request
        public void AddRequest(string name, string phone, string email, string bloodGroup)
        {
            string query = "INSERT INTO RequestTbl (RName, RPhone, REmail, RBGroup) VALUES (@RName, @RPhone, @REmail, @RBGroup)";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@RName", name);
                        cmd.Parameters.AddWithValue("@RPhone", phone);
                        cmd.Parameters.AddWithValue("@REmail", email);
                        cmd.Parameters.AddWithValue("@RBGroup", bloodGroup);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding blood request.", ex);
                }
            }
        }
        public DataTable GetAllRequests()
        {
            DataTable dt = new DataTable();
            string query = "SELECT id, RName, RPhone, REmail, RBGroup FROM RequestTbl";

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
                    throw new Exception("Error retrieving requests.", ex);
                }
            }

            return dt;
        }

    }
}
