using System;
using System.Configuration;
using System.Data.SqlClient;

namespace LifeLineBloodBank.Database
{
    public class TransferTbl
    {
        private readonly string connectionString;

        public TransferTbl()
        {
            connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        }

        // Method to add a blood transfer record
        public void AddTransfer(string patientName, string bloodGroup)
        {
            string query = "INSERT INTO TransferTbl (PName, BGroup) VALUES (@PName, @BGroup)";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@PName", patientName);
                        cmd.Parameters.AddWithValue("@BGroup", bloodGroup);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding blood transfer record.", ex);
                }
            }
        }

        // Method to delete a blood request after successful transfer
        public void DeleteRequest(int requestId)
        {
            string query = "DELETE FROM RequestTbl WHERE id = @id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", requestId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting blood request.", ex);
                }
            }
        }
    }
}
