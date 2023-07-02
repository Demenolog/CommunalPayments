using System;
using System.Data.SQLite;

namespace CommunalPayments.Common.DataContext.Sqlite
{
    public static class ReceiptDb
    {
        private static readonly string ConnectionString;

        static ReceiptDb()
        {
            ConnectionString = $@"Data Source={Environment.CurrentDirectory}mydb.db;Version=3;";
        }

        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);

            try
            {
                connection.Open();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(nameof(ex));
                throw;
            }

            return connection;
        }
    }
}