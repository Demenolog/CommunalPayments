using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunalPayments.Wpf.Infrastructure.Constans;
using CommunalPayments.Wpf.ViewModels;

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
            var instrumentCurrentValue = decimal.Parse(MainWindow.InstrumentCurrentValueCold);
            var instrumentPreviousValue = decimal.Parse(MainWindow.InstrumentPreviousValueCold);
            var rate = decimal.Parse(MainWindow.RateCold);

            var consumptionValue = instrumentCurrentValue - instrumentPreviousValue;
            var serviceCharges = consumptionValue * rate;

            MainWindow.ConsumptionValueCold = consumptionValue.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ServiceChargesCold = serviceCharges.ToString(CalculatedValuesFormatConstans.Money);
        }

        private static void CalculateStandardVolume()
        {
            var numberResidents = int.Parse(MainWindow.NumberResidents);
            var normPerPerson = decimal.Parse(MainWindow.NormPerPersonCold);
            var rate = decimal.Parse(MainWindow.RateCold);

            var consumptionValue = numberResidents * normPerPerson;
            var serviceCharges = consumptionValue * rate;

            MainWindow.ConsumptionValueCold = consumptionValue.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ServiceChargesCold = serviceCharges.ToString(CalculatedValuesFormatConstans.Money);
        }
    }
}
