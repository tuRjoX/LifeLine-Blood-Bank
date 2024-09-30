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
        public DataRow AuthenticateUser(string username, string password)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM UsersTbl WHERE [UName] COLLATE SQL_Latin1_General_CP1_CS_AS = @UserName AND [UPassword] = @Password";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserName", username);
                        cmd.Parameters.AddWithValue("@Password", password);
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
                        return null; // No user found
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error during user authentication.", ex);
                }
            }
        }
        // Check if username already exists
        public bool IsUsernameTaken(string username)
        {
            string query = "SELECT COUNT(*) FROM UsersTbl WHERE UName = @UN";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UN", username);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Check if email already exists
        public bool IsEmailTaken(string email)
        {
            string query = "SELECT COUNT(*) FROM UsersTbl WHERE UEmail = @UE";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UE", email);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Register a new user
        public void RegisterUser(string username, string fullName, string phone, string email, string password)
        {
            string query = "INSERT INTO UsersTbl (UName, UFullName, UPhone, UEmail, UPassword) VALUES (@UN, @UFN, @UP, @UE, @UPASS)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UN", username);
                    cmd.Parameters.AddWithValue("@UFN", fullName);
                    cmd.Parameters.AddWithValue("@UP", phone);
                    cmd.Parameters.AddWithValue("@UE", email);
                    cmd.Parameters.AddWithValue("@UPASS", password);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Check if email exists
        public bool IsEmailExists(string email)
        {
            string query = "SELECT COUNT(*) FROM UsersTbl WHERE UEmail = @Email";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Update password
        public void UpdatePassword(string email, string newPassword)
        {
            string query = "UPDATE UsersTbl SET UPassword = @Password WHERE UEmail = @Email";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Password", newPassword);
                    cmd.Parameters.AddWithValue("@Email", email);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
