namespace netschool.Helpers;

using MySql.Data.MySqlClient;

public static class DatabaseHelper
{
    private static string connectionString;

    static DatabaseHelper()
    {
        // Load the connection string from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}