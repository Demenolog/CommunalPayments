using CommunalPayments.Common.DataContext.Sqlite.Models;
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

        public bool InsertData(List<string> storedValues)
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

        public bool DeleteData(int deleteNumber)
        {
            var connection = GetConnection();
            var query = @"DELETE FROM Receipt WHERE Id = @Id;";

            try
            {
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("Id", deleteNumber);

                    var rowsAffected = command.ExecuteNonQuery();

                    return (rowsAffected > 0);
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
                var numberColumns = 4;

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

                            for (int i = 0; i < numberColumns; i++)
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
            var connection = GetConnection();
            string selectQuery = @"SELECT COUNT(*) FROM Receipt WHERE [Год] = @Year AND [Месяц] = @Month";

            try
            {
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

        public List<ReceiptData> GetAllData()
        {
            var result = new List<ReceiptData>();
            var connection = GetConnection();
            var selectQuery = "SELECT * FROM Receipt";

            try
            {
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data = new ReceiptData()
                            {
                                Id = reader.GetInt32(0),
                                CalculationYear = reader.GetString(1),
                                CalculationMonth = reader.GetString(2),
                                ConsumptionValueCold = reader[3].ToString(),
                                ServiceChargesCold = reader.GetString(4),
                                ConsumptionValueHotHeatCarrier = reader[5].ToString(),
                                ConsumptionValueHotHeatEnergy = reader[6].ToString(),
                                ServiceChargesHotHeatCarrier = reader.GetString(7),
                                ServiceChargesHotHeatEnergy = reader.GetString(8),
                                ConsumptionValueEnergyDay = reader[9].ToString(),
                                ConsumptionValueEnergyNight = reader[10].ToString(),
                                ConsumptionValueEnergyGeneral = reader[11].ToString(),
                                ServiceChargesEnergy = reader.GetString(12),
                                ServiceChargesTotal = reader.GetString(13),
                            };

                            result.Add(data);
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public bool IsAnyData()
        {
            var connection = GetConnection();
            var selectQuery = "SELECT 1 FROM Receipt LIMIT 1";

            try
            {
                object result;

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    result = command.ExecuteScalar();
                }

                return (result != null && result != DBNull.Value);
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