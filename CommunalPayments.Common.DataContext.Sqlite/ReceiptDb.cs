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
            try
            {
                var connection = GetConnection();

                string insertQuery = @"INSERT INTO Receipt ([Год], [Месяц], [Счетчик ХВС], [Начисления за ХВС], [Счетчик ГВС ТН], [Счетчик ГВС ТЭ], [Начисления за ГВС ТН], [Начисления за ГВС ТЭ], [Счетчик ЭЭ день], [Счетчик ЭЭ ночь], [Счетчик ЭЭ общий], [Начисления за ЭЭ], [Итого])
                       VALUES (@Param1, @Param2, @Param3, @Param4, @Param5, @Param6, @Param7, @Param8, @Param9, @Param10 , @Param11, @Param12, @Param13)";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    for (int i = 0; i < storedValues.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@Param{i + 1}", storedValues[i]);
                    }

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<string> GetPreviousData(string year, string month)
        {
            try
            {
                var connection = GetConnection();
                var columns = 4;

                var selectQuery = @"SELECT [Счетчик ХВС], [Счетчик ГВС ТН], [Счетчик ЭЭ день], [Счетчик ЭЭ ночь] FROM Receipt WHERE [Год] = @Year AND [Месяц] = @Month";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Month", month);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var result = new List<string>();

                            for (int i = 0; i < columns; i++)
                            {
                                var value = reader[i].ToString();

                                result.Add(string.IsNullOrEmpty(value) ? "0" : value);
                            }

                            return result;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public bool IsPreviousDataExist(string year, string month)
        {
            try
            {
                var connection = GetConnection();

                string selectQuery = @"SELECT COUNT(*) FROM Receipt WHERE [Год] = @Year AND [Месяц] = @Month";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Month", month);

                    int result = Convert.ToInt32(command.ExecuteScalar());

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}