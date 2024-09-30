using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LifeLineBloodBank.Database
{
    public class UserTbl
    {
        private readonly string connectionString;

        public UserTbl()
        {
            connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        }

        // Method to load user data by ID
        public DataRow LoadUserData(int userId)
        {
            DataTable dt = new DataTable();
            string query = "SELECT UName, UFullName, UPhone,UEmail FROM UsersTbl WHERE Id = @UserId";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }

                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows[0];
                    }
                    else
                    {
                        throw new Exception("User not found.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving user data.", ex);
                }
            }
        }
    }
}
