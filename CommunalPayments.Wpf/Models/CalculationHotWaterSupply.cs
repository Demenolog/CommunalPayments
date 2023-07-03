using CommunalPayments.Wpf.Infrastructure.Constans;
using CommunalPayments.Wpf.ViewModels;
using System;
using CommunalPayments.Wpf.Services;

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

        private static void CalculateStandardVolume()
        {
            int numberResidents;
            decimal normPerPersonHeatCarrier;
            decimal normPerPersonHeatEnergy;
            decimal rateHeatCarrier;
            decimal rateHeatEnergy;
            decimal consumptionValueHeatCarrier;
            decimal consumptionValueHeatEnergy;
            decimal serviceChargesHeatCarrier;
            decimal serviceChargesHeatEnergy;

            checked
            {
                numberResidents = int.Parse(MainWindow.NumberResidents);
                normPerPersonHeatCarrier = decimal.Parse(MainWindow.NormPerPersonHotHeatCarrier);
                normPerPersonHeatEnergy = decimal.Parse(MainWindow.NormPerPersonHotHeatEnergy);
                rateHeatCarrier = decimal.Parse(MainWindow.RateHotHeatCarrier);
                rateHeatEnergy = decimal.Parse(MainWindow.RateHotHeatEnergy);

                consumptionValueHeatCarrier = numberResidents * normPerPersonHeatCarrier;
                consumptionValueHeatEnergy = numberResidents * normPerPersonHeatEnergy;

                serviceChargesHeatCarrier = consumptionValueHeatCarrier * rateHeatCarrier;
                serviceChargesHeatEnergy = consumptionValueHeatEnergy * rateHeatEnergy;
            }

            SetValues(consumptionValueHeatCarrier, consumptionValueHeatEnergy, serviceChargesHeatCarrier,
                serviceChargesHeatEnergy);
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