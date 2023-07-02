using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var instrumentCurrentValue = double.Parse(MainWindow.InstrumentCurrentValueCold);
            var instrumentPreviousValue = double.Parse(MainWindow.InstrumentPreviousValueCold);
            var rate = double.Parse(MainWindow.RateCold);

            var consumptionValue = instrumentCurrentValue - instrumentPreviousValue;
            var serviceCharges = consumptionValue * rate;

            MainWindow.ConsumptionValueCold = consumptionValue.ToString();
            MainWindow.ServiceChargesCold = serviceCharges.ToString();
        }

        private static void CalculateStandardVolume()
        {
            var numberResidents = int.Parse(MainWindow.NumberResidents);
            var normPerPerson = double.Parse(MainWindow.NormPerPersonCold);
            var rate = double.Parse(MainWindow.RateCold);

            var consumptionValue = numberResidents * normPerPerson;
            var serviceCharges = consumptionValue * rate;

            MainWindow.ConsumptionValueCold = consumptionValue.ToString();
            MainWindow.ServiceChargesCold = serviceCharges.ToString();
        }
    }
}
