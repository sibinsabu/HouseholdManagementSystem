using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace HouseholdManagementSystem.Models
{
    public class InventoryRepository
    {
        private string connectionString = "Data Source=household_management.db;Version=3;";

        // ✅ Create (Add) a new inventory item
        public void AddItem(string itemType, int quantity)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Inventory (ItemType, TotalQuantity, UsedQuantity, LastRestockedDate) VALUES (@ItemType, @TotalQuantity, 0, @LastRestockedDate)";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@ItemType", itemType);
                cmd.Parameters.AddWithValue("@TotalQuantity", quantity);
                cmd.Parameters.AddWithValue("@LastRestockedDate", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

        // ✅ Read (Retrieve) all inventory items → Renamed to `GetAllInventory()`
        public List<InventoryItem> GetAllItems() // 🔥 Renamed from GetAllInventory() to GetAllItems()
        {
            List<InventoryItem> inventory = new List<InventoryItem>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Inventory";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    inventory.Add(new InventoryItem
                    {
                        ItemID = Convert.ToInt32(reader["ItemID"]),
                        ItemType = reader["ItemType"].ToString(),
                        TotalQuantity = Convert.ToInt32(reader["TotalQuantity"]),
                        UsedQuantity = Convert.ToInt32(reader["UsedQuantity"]),
                        LastRestockedDate = reader.GetDateTime(4).ToString("yyyy-MM-dd HH:mm:ss") // ✅ Convert DateTime to string

                    });
                }
            }
            return inventory;
        }

        // ✅ Update stock when new items are restocked
        public void UpdateStock(int itemID, int additionalQuantity)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Inventory SET TotalQuantity = TotalQuantity + @Qty, LastRestockedDate = @LastRestockedDate WHERE ItemID = @ItemID";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@Qty", additionalQuantity);
                cmd.Parameters.AddWithValue("@ItemID", itemID);
                cmd.Parameters.AddWithValue("@LastRestockedDate", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

        // ✅ Deduct stock when used in repairs
        public void DeductStock(int itemID, int quantityUsed)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Inventory SET UsedQuantity = UsedQuantity + @qty, TotalQuantity = TotalQuantity - @qty WHERE ItemID = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@qty", quantityUsed);
                cmd.Parameters.AddWithValue("@id", itemID);
                cmd.ExecuteNonQuery();
            }
        }

        // ✅ Get low stock items (Threshold: 5 items)
        public List<InventoryItem> GetLowStockItems()
        {
            List<InventoryItem> lowStockItems = new List<InventoryItem>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Inventory WHERE TotalQuantity < 5";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lowStockItems.Add(new InventoryItem
                    {
                        ItemID = Convert.ToInt32(reader["ItemID"]),
                        ItemType = reader["ItemType"].ToString(),
                        TotalQuantity = Convert.ToInt32(reader["TotalQuantity"]),
                        UsedQuantity = Convert.ToInt32(reader["UsedQuantity"]),
                        LastRestockedDate = reader.GetDateTime(4).ToString("yyyy-MM-dd HH:mm:ss") // ✅ Convert DateTime to string

                    });
                }
            }
            return lowStockItems;
        }
    }
}
