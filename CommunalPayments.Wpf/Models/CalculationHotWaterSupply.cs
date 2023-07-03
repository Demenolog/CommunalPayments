using CommunalPayments.Wpf.Infrastructure.Constans;
using CommunalPayments.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var instrumentCurrentValue = decimal.Parse(MainWindow.InstrumentCurrentValueHot);
            var instrumentPreviousValue = decimal.Parse(MainWindow.InstrumentPreviousValueHot);
            var rateHeatCarrier = decimal.Parse(MainWindow.RateHotHeatCarrier);
            var rateHeatEnergy = decimal.Parse(MainWindow.RateHotHeatEnergy);
            var normPerMeter = decimal.Parse(MainWindow.NormPerCubicMeter);

            var consumptionValueHeatCarrier = instrumentCurrentValue - instrumentPreviousValue;
            var consumptionValueHeatEnergy = consumptionValueHeatCarrier * normPerMeter;

            var serviceChargesHeatCarrier = consumptionValueHeatCarrier * rateHeatCarrier;
            var serviceChargesHeatEnergy = consumptionValueHeatEnergy * rateHeatEnergy;

            MainWindow.ConsumptionValueHotHeatCarrier = consumptionValueHeatCarrier.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ConsumptionValueHotHeatEnergy = consumptionValueHeatEnergy.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ServiceChargesHotHeatCarrier = serviceChargesHeatCarrier.ToString(CalculatedValuesFormatConstans.Money);
            MainWindow.ServiceChargesHotHeatEnergy = serviceChargesHeatEnergy.ToString(CalculatedValuesFormatConstans.Money);
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

            MainWindow.ConsumptionValueHotHeatCarrier = consumptionValueHeatCarrier.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ConsumptionValueHotHeatEnergy = consumptionValueHeatEnergy.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ServiceChargesHotHeatCarrier = serviceChargesHeatCarrier.ToString(CalculatedValuesFormatConstans.Money);
            MainWindow.ServiceChargesHotHeatEnergy = serviceChargesHeatEnergy.ToString(CalculatedValuesFormatConstans.Money);
        }
    }
}
