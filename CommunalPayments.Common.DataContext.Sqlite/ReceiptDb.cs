using System;
using System.Data.SQLite;
using System.IO;

namespace CommunalPayments.Common.DataContext.Sqlite
{
    public static class ReceiptDb
    {
        private static readonly string ConnectionString;

        static ReceiptDb()
        {
            ConnectionString = $@"Data Source={Path.Combine(Environment.CurrentDirectory, "ReceiptDb.db")};Version=3;";
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