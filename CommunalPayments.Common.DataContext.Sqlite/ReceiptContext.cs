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

        /*
         *
         *
         * CREATE TABLE Receipt (
           Id                     INTEGER PRIMARY KEY
           NOT NULL,
           Год                    TEXT    NOT NULL,
           Месяц                  TEXT    NOT NULL,
           [Счетчик ХВС]          TEXT,
           [Начисления за ХВС]    TEXT    NOT NULL,
           [Счетчик ГВС ТН]       TEXT,
           [Счетчик ГВС ТЭ]       TEXT,
           [Начисления за ГВС ТН] TEXT    NOT NULL,
           [Начисления за ГВС ТЭ] TEXT    NOT NULL,
           [Счетчик ЭЭ день]      TEXT,
           [Счетчик ЭЭ ночь]      TEXT,
           [Счетчик ЭЭ общий]     TEXT,
           [Начисления за ЭЭ]     TEXT    NOT NULL,
           Итого                  TEXT    NOT NULL
           );
         *
         *
         */
    }
}