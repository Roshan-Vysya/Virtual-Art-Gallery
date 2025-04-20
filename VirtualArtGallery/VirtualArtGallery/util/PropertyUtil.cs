using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace util
{
    public static class DBPropertyUtil
    {
        public static string GetConnectionString(string fileName = "connectionDetails.json")
        {
            try
            {
                // Set up the ConfigurationBuilder to read the JSON file in the current directory
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()) // Gets the application's working directory
                    .AddJsonFile(fileName); // Add the JSON file to the configuration

                // Build the configuration
                var config = builder.Build();

                // Retrieve the connection string from the "ConnectionStrings" section
                return config.GetConnectionString("DefaultConnection");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the configuration file: {ex.Message}");
                throw;
            }
        }
    }
}