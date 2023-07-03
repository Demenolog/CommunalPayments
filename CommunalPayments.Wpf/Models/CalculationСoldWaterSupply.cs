using CommunalPayments.Wpf.Infrastructure.Constans;
using CommunalPayments.Wpf.Services;
using CommunalPayments.Wpf.ViewModels;
using System;

namespace CommunalPayments.Wpf.Models
{
    public static class CalculationСoldWaterSupply
    {
        private static readonly MainWindowViewModel MainWindow = new ViewModelLocator().MainWindowModel;

        public static void Calculate(bool isMeteringDevicesSelected)
        {
            if (isMeteringDevicesSelected)
            {
                CalculateMeteringDevices();
            }
            else
            {
                CalculateStandardVolume();
            }
        }

        private static void CalculateMeteringDevices()
        {
            try
            {
                decimal instrumentCurrentValue;
                decimal instrumentPreviousValue;
                decimal rate;
                decimal consumptionValue;
                decimal serviceCharges;

                checked
                {
                    instrumentCurrentValue = decimal.Parse(MainWindow.InstrumentCurrentValueCold);
                    instrumentPreviousValue = decimal.Parse(MainWindow.InstrumentPreviousValueCold);
                    rate = decimal.Parse(MainWindow.RateCold);

                    consumptionValue = instrumentCurrentValue - instrumentPreviousValue;
                    serviceCharges = consumptionValue * rate;
                }

                SetValues(consumptionValue, serviceCharges);
            }
            catch (OverflowException ex)
            {
                throw;
            }
            catch (ArgumentNullException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void CalculateStandardVolume()
        {
            try
            {
                int numberResidents;
                decimal normPerPerson;
                decimal rate;
                decimal consumptionValue;
                decimal serviceCharges;

                checked
                {
                    numberResidents = int.Parse(MainWindow.NumberResidents);
                    normPerPerson = decimal.Parse(MainWindow.NormPerPersonCold);
                    rate = decimal.Parse(MainWindow.RateCold);

                    consumptionValue = numberResidents * normPerPerson;
                    serviceCharges = consumptionValue * rate;
                }

                SetValues(consumptionValue, serviceCharges);
            }
            catch (OverflowException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void SetValues(decimal consumptionValue, decimal serviceCharges)
        {
            MainWindow.ConsumptionValueCold = consumptionValue.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ServiceChargesCold = serviceCharges.ToString(CalculatedValuesFormatConstans.Money);
        }
    }
}