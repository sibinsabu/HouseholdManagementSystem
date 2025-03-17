using Computer_Controlled_ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace HouseholdManagementSystem.Models
{
    public class HouseholdRepository
    {
        private string connectionString = "Data Source=household_management.db;Version=3;";

        // ✅ Create (Add) a new household
        public void AddHousehold(Household household)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Households (OwnerName, Address, ContactNum, InstalDate, LastInspect) VALUES (@OwnerName, @Address, @ContactNum, @InstalDate, @LastInspect)";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@OwnerName", household.OwnerName);
                cmd.Parameters.AddWithValue("@Address", household.Address);
                cmd.Parameters.AddWithValue("@ContactNum", household.ContactNum);
                cmd.Parameters.AddWithValue("@InstalDate", household.InstalDate);
                cmd.Parameters.AddWithValue("@LastInspect", household.LastInspect);
                cmd.ExecuteNonQuery();
            }
        }

        // ✅ Read (Retrieve) all households
        public List<Household> GetAllHouseholds()
        {
            List<Household> households = new List<Household>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Households";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    households.Add(new Household
                    {
                        HouseholdID = Convert.ToInt32(reader["HouseholdID"]),
                        OwnerName = reader["OwnerName"].ToString(),
                        Address = reader["Address"].ToString(),
                        ContactNum = reader["ContactNum"].ToString(),
                        InstalDate = Convert.ToDateTime(reader["InstalDate"]),
                        LastInspect = Convert.ToDateTime(reader["LastInspect"])
                    });
                }
            }
            return households;
        }

        // ✅ Update a household
        public void UpdateHousehold(Household household)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Households SET OwnerName=@OwnerName, Address=@Address, ContactNum=@ContactNum, InstalDate=@InstalDate, LastInspect=@LastInspect WHERE HouseholdID=@HouseholdID";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@HouseholdID", household.HouseholdID);
                cmd.Parameters.AddWithValue("@OwnerName", household.OwnerName);
                cmd.Parameters.AddWithValue("@Address", household.Address);
                cmd.Parameters.AddWithValue("@ContactNum", household.ContactNum);
                cmd.Parameters.AddWithValue("@InstalDate", household.InstalDate);
                cmd.Parameters.AddWithValue("@LastInspect", household.LastInspect);
                cmd.ExecuteNonQuery();
            }
        }

        // ✅ Delete a household
        public void DeleteHousehold(int householdID)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Households WHERE HouseholdID=@HouseholdID";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@HouseholdID", householdID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
