using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace LifeLineBloodBank.Database
{
    public class PatientsTbl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;

        public void InsertPatient(string name, string age, string phone, string gender, string bloodGroup, string address, string departmentList, string wardNo, string bedNo, byte[] picture)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = $"INSERT INTO PatientsTbl (PName, PAge, PPhone, PGender, PBGroup, PAdress, PDList, PWNo, PBNo, PPicture, CreatedDate) " +
                               $"VALUES (@name, @age, @phone, @gender, @bloodGroup, @address, @departmentList, @wardNo, @bedNo, @picture, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@bloodGroup", bloodGroup);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@departmentList", departmentList);
                    cmd.Parameters.AddWithValue("@wardNo", wardNo);
                    cmd.Parameters.AddWithValue("@bedNo", bedNo);
                    cmd.Parameters.AddWithValue("@picture", picture);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to populate the DataGridView with patients' data
        public DataTable GetPatients()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PatientsTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

        // Method to update a patient's data
        public void UpdatePatient(int key, string name, string age, string phone, string gender, string bloodGroup, string address, string departmentList, string wardNo, string bedNo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE PatientsTbl SET PName = @name, PAge = @age, PPhone = @phone, PGender = @gender, PBGroup = @bloodGroup, " +
                               "PAdress = @address, PDList = @departmentList, PWNo = @wardNo, PBNo = @bedNo WHERE PNum = @key";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@key", key);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@bloodGroup", bloodGroup);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@departmentList", departmentList);
                cmd.Parameters.AddWithValue("@wardNo", wardNo);
                cmd.Parameters.AddWithValue("@bedNo", bedNo);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to delete a patient
        public void DeletePatient(int key)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM PatientsTbl WHERE PNum = @key";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@key", key);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        // Method to get patient data by ID
        public DataTable GetPatientById(int id)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM PatientsTbl WHERE PNum = @id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving patient data.", ex);
                }
            }

            return dt;
        }
    }
}
