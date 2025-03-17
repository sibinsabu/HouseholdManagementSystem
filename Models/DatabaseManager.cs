using System;
using System.Data.SQLite;
using System.IO;

namespace HouseholdManagementSystem.Models
{
    public class DatabaseManager
    {
        private string dbFile = "household_management.db";
        private string connectionString;

        public DatabaseManager()
        {
            connectionString = $"Data Source={dbFile};Version=3;";
            if (!File.Exists(dbFile))
            {
                CreateDatabase();
            }
        }

        private void CreateDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                CREATE TABLE IF NOT EXISTS Households (
                    HouseholdID INTEGER PRIMARY KEY AUTOINCREMENT,
                    OwnerName TEXT NOT NULL,
                    Address TEXT NOT NULL,
                    ContactNum TEXT NOT NULL UNIQUE,
                    InstalDate DATE NOT NULL,
                    LastInspect DATE NOT NULL
                );
                
                CREATE TABLE IF NOT EXISTS Technicians (
                    TechnicianID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    ContactNum TEXT NOT NULL UNIQUE,
                    AssignedArea TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS ServiceRecords (
                    ServiceID INTEGER PRIMARY KEY AUTOINCREMENT,
                    HouseholdID INTEGER NOT NULL,
                    TechnicianID INTEGER NOT NULL,
                    ServiceDate DATE NOT NULL,
                    Problem TEXT NOT NULL,
                    ActionTaken TEXT,
                    Status TEXT CHECK(Status IN ('Pending', 'In Progress', 'Completed')) NOT NULL DEFAULT 'Pending',
                    FOREIGN KEY (HouseholdID) REFERENCES Households(HouseholdID) ON DELETE CASCADE,
                    FOREIGN KEY (TechnicianID) REFERENCES Technicians(TechnicianID) ON DELETE SET NULL
                );

                CREATE TABLE IF NOT EXISTS Inventory (
                    ItemID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ItemType TEXT CHECK(ItemType IN ('Controller', 'Inverter', 'Battery', 'Panel', 'Wiring', 'Charger', 'Cable')) NOT NULL,
                    TotalQuantity INTEGER NOT NULL DEFAULT 0,
                    UsedQuantity INTEGER NOT NULL DEFAULT 0,
                    LastRestockedDate DATE
                );

                CREATE TABLE IF NOT EXISTS UsedInventory (
                    UsedID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ServiceID INTEGER NOT NULL,
                    ItemID INTEGER NOT NULL,
                    QuantityUsed INTEGER NOT NULL CHECK(QuantityUsed > 0),
                    UsedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (ServiceID) REFERENCES ServiceRecords(ServiceID) ON DELETE CASCADE,
                    FOREIGN KEY (ItemID) REFERENCES Inventory(ItemID) ON DELETE CASCADE
                );

                CREATE TABLE IF NOT EXISTS AdminUsers (
                    AdminID INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserName TEXT NOT NULL UNIQUE,
                    PasswordHash TEXT NOT NULL
                );";

                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}
