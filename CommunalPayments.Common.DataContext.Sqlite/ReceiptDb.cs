using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace CommunalPayments.Common.DataContext.Sqlite
{
    public class ReceiptDb : IDisposable
    {
        private readonly SQLiteConnection _connection;

        public ReceiptDb()
        {
            _connection = ReceiptContext.CreateConnection();
        }

        public SQLiteConnection GetConnection()
        {
            return _connection;
        }

        public bool Insert(List<string> storedValues)
        {
            int result;

            try
            {
                using (var connection = GetConnection())
                {
                    string insertQuery = @"INSERT INTO Receipt ([Год], [Месяц], [Счетчик ХВС], [Начисления за ХВС], [Счетчик ГВС ТН], [Счетчик ГВС ТЭ], [Начисления за ГВС ТН], [Начисления за ГВС ТЭ], [Счетчик ЭЭ день], [Счетчик ЭЭ ночь], [Начисления за ЭЭ], [Итого])
                       VALUES (@Param1, @Param2, @Param3, @Param4, @Param5, @Param6, @Param7, @Param8, @Param9, @Param10 , @Param11, @Param12)";

                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        for (int i = 0; i < storedValues.Count; i++)
                        {
                            command.Parameters.AddWithValue($"@Param{i + 1}", storedValues[i]);
                        }

                        result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return (result > 0);
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}