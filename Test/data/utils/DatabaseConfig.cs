using System.Data.SqlClient;
using Test.domain.model;

namespace Test.data.utils
{
    internal class DatabaseConfig
    {

        private const String configFilePath = @"config.txt";

        private SqlConnection? databaseConnectionInstance = null;

        public Response<SqlConnection> getDatabaseInstance()
        {
            if (databaseConnectionInstance == null)
            {
                string? connectionString = getConnectionString();
                if (connectionString == null)
                    return new Response<SqlConnection>.Error("Не удалось найти файл config.txt");
                try
                {
                    databaseConnectionInstance = new SqlConnection(connectionString);
                }
                catch
                {
                    return new Response<SqlConnection>.Error("Не удалось подключиться к базе данных. Пожалуйста, проверьте правильно ли указан путь к базе данных в файле config.txt");
                }
                return new Response<SqlConnection>.Success(databaseConnectionInstance);
            }
            else return new Response<SqlConnection>.Success(databaseConnectionInstance);
        }

        private string? getConnectionString()
        {
            try
            {
                string file = File.ReadAllText(configFilePath);
                return file.Substring(file.IndexOf(':') + 1);
            } catch {
                return null;
            }
        }
    }
}
