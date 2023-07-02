using System;
using System.Data.SQLite;
using System.IO;

namespace CommunalPayments.Common.DataContext.Sqlite
{
    internal static class ReceiptContext
    {
        private static readonly string ConnectionString;

        static ReceiptContext()
        {
            ConnectionString = $@"Data Source={Path.Combine(Environment.CurrentDirectory, "Data", "ReceiptDb.db")};Version=3;";
        }

        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(nameof(ex));
                throw;
            }

            return connection;
        }
    }
}