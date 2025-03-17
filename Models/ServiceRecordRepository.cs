using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace HouseholdManagementSystem.Models
{
    public class ServiceRecordRepository
    {
        private string connectionString = "Data Source=household_management.db;Version=3;";

        // ✅ Create (Add) a new service record
        public void AddServiceRecord(int householdID, int technicianID, string problem, string actionTaken, string status)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO ServiceRecords (HouseholdID, TechnicianID, ServiceDate, Problem, ActionTaken, Status) VALUES (@HouseholdID, @TechnicianID, @ServiceDate, @Problem, @ActionTaken, @Status)";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@HouseholdID", householdID);
                cmd.Parameters.AddWithValue("@TechnicianID", technicianID);
                cmd.Parameters.AddWithValue("@ServiceDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Problem", problem);
                cmd.Parameters.AddWithValue("@ActionTaken", actionTaken);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.ExecuteNonQuery();
            }
        }

        // ✅ Retrieve all service records
        public List<ServiceRecord> GetAllServiceRecords()
        {
            List<ServiceRecord> records = new List<ServiceRecord>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM ServiceRecords";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    records.Add(new ServiceRecord
                    {
                        ServiceID = Convert.ToInt32(reader["ServiceID"]),
                        HouseholdID = Convert.ToInt32(reader["HouseholdID"]),
                        TechnicianID = Convert.ToInt32(reader["TechnicianID"]),
                        ServiceDate = Convert.ToDateTime(reader["ServiceDate"]),
                        Problem = reader["Problem"].ToString(),
                        ActionTaken = reader["ActionTaken"].ToString(),
                        Status = reader["Status"].ToString()
                    });
                }
            }
            return records;
        }
    }
}
