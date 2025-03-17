using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace HouseholdManagementSystem.Models
{
    public class TechnicianRepository
    {
        private string connectionString = "Data Source=household_management.db;Version=3;";

        // ✅ Create (Add) a new technician
        public void AddTechnician(string name, string contactNum, string assignedArea)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Technicians (Name, ContactNum, AssignedArea) VALUES (@Name, @ContactNum, @AssignedArea)";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@ContactNum", contactNum);
                cmd.Parameters.AddWithValue("@AssignedArea", assignedArea);
                cmd.ExecuteNonQuery();
            }
        }

        // ✅ Read (Retrieve) all technicians
        public List<Technician> GetAllTechnicians()
        {
            List<Technician> technicians = new List<Technician>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Technicians";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    technicians.Add(new Technician
                    {
                        TechnicianID = Convert.ToInt32(reader["TechnicianID"]),
                        Name = reader["Name"].ToString(),
                        ContactNum = reader["ContactNum"].ToString(),
                        AssignedArea = reader["AssignedArea"].ToString()
                    });
                }
            }
            return technicians;
        }

        // ✅ Update a technician
        public void UpdateTechnician(Technician technician)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Technicians SET Name=@Name, ContactNum=@ContactNum, AssignedArea=@AssignedArea WHERE TechnicianID=@TechnicianID";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@TechnicianID", technician.TechnicianID);
                cmd.Parameters.AddWithValue("@Name", technician.Name);
                cmd.Parameters.AddWithValue("@ContactNum", technician.ContactNum);
                cmd.Parameters.AddWithValue("@AssignedArea", technician.AssignedArea);
                cmd.ExecuteNonQuery();
            }
        }

        // ✅ Delete a technician
        public void DeleteTechnician(int technicianID)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Technicians WHERE TechnicianID=@TechnicianID";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@TechnicianID", technicianID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
