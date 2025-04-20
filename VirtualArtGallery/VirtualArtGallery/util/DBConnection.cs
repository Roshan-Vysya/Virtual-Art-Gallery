using System;

using System.Data.SqlClient; // Include System.Data.SqlClient for SQL Server connection

namespace util
{
    public static class DBConnection
    {
        private static SqlConnection connection;

        // Method to get the SQL connection object
        public static SqlConnection GetConnection(string jsonFilePath)
        {
            if (connection == null || connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // Get the connection string from the JSON file
                    string connectionString = DBPropertyUtil.GetConnectionString(jsonFilePath);

                    // Initialize the connection
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    Console.WriteLine("Database connection established successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error establishing the database connection: {ex.Message}");
                    throw;
                }
            }
            return connection;
        }
    }
}