using CommunalPayments.Wpf.Infrastructure.Constans;
using CommunalPayments.Wpf.ViewModels;
using System;

namespace CommunalPayments.Wpf.Models
{
    public static class CalculationHotWaterSupply
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
                decimal rateHeatCarrier;
                decimal rateHeatEnergy;
                decimal normPerMeter;
                decimal consumptionValueHeatCarrier;
                decimal consumptionValueHeatEnergy;
                decimal serviceChargesHeatCarrier;
                decimal serviceChargesHeatEnergy;

                checked
                {
                    instrumentCurrentValue = decimal.Parse(MainWindow.InstrumentCurrentValueHot);
                    instrumentPreviousValue = decimal.Parse(MainWindow.InstrumentPreviousValueHot);
                    rateHeatCarrier = decimal.Parse(MainWindow.RateHotHeatCarrier);
                    rateHeatEnergy = decimal.Parse(MainWindow.RateHotHeatEnergy);
                    normPerMeter = decimal.Parse(MainWindow.NormPerCubicMeter);

                    consumptionValueHeatCarrier = instrumentCurrentValue - instrumentPreviousValue;
                    consumptionValueHeatEnergy = consumptionValueHeatCarrier * normPerMeter;

                    serviceChargesHeatCarrier = consumptionValueHeatCarrier * rateHeatCarrier;
                    serviceChargesHeatEnergy = consumptionValueHeatEnergy * rateHeatEnergy;
                }

                SetValues(consumptionValueHeatCarrier, consumptionValueHeatEnergy, serviceChargesHeatCarrier,
                    serviceChargesHeatEnergy);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private static void CalculateStandardVolume()
        {
            var numberResidents = int.Parse(MainWindow.NumberResidents);
            var normPerPersonHeatCarrier = decimal.Parse(MainWindow.NormPerPersonHotHeatCarrier);
            var normPerPersonHeatEnergy = decimal.Parse(MainWindow.NormPerPersonHotHeatEnergy);
            var rateHeatCarrier = decimal.Parse(MainWindow.RateHotHeatCarrier);
            var rateHeatEnergy = decimal.Parse(MainWindow.RateHotHeatEnergy);

            var consumptionValueHeatCarrier = numberResidents * normPerPersonHeatCarrier;
            var consumptionValueHeatEnergy = numberResidents * normPerPersonHeatEnergy;

            var serviceChargesHeatCarrier = consumptionValueHeatCarrier * rateHeatCarrier;
            var serviceChargesHeatEnergy = consumptionValueHeatEnergy * rateHeatEnergy;

            SetValues(consumptionValueHeatCarrier, consumptionValueHeatEnergy, serviceChargesHeatCarrier, serviceChargesHeatEnergy);
        }

        private static void SetValues(decimal consumptionValueHeatCarrier, decimal consumptionValueHeatEnergy,
            decimal serviceChargesHeatCarrier, decimal serviceChargesHeatEnergy)
        {
            MainWindow.ConsumptionValueHotHeatCarrier = consumptionValueHeatCarrier.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ConsumptionValueHotHeatEnergy = consumptionValueHeatEnergy.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ServiceChargesHotHeatCarrier = serviceChargesHeatCarrier.ToString(CalculatedValuesFormatConstans.Money);
            MainWindow.ServiceChargesHotHeatEnergy = serviceChargesHeatEnergy.ToString(CalculatedValuesFormatConstans.Money);
        }
    }
}