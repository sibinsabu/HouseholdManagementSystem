using System.Data.SQLite;

namespace HouseholdManagementSystem.Repositories
{
    public class AdminRepository
    {
        private readonly string _connectionString = "Data Source=household_management.db;Version=3;";

        public bool ValidateUser(string username, string password)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Password FROM AdminUsers WHERE UserName = @UserName";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string storedHash = result.ToString();
                        return BCrypt.Net.BCrypt.Verify(password, storedHash);
                    }
                }
            }
            return false;
        }
    }
}
