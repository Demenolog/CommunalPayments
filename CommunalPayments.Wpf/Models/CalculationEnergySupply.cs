using CommunalPayments.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunalPayments.Wpf.Infrastructure.Constans;

namespace CommunalPayments.Wpf.Models
{
    public static class CalculationEnergySupply
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
            var instrumentCurrentValueDay = decimal.Parse(MainWindow.InstrumentCurrentValueEnergyDay);
            var instrumentPreviousValueDay = decimal.Parse(MainWindow.InstrumentPreviousValueEnergyDay);
            var instrumentCurrentValueNight = decimal.Parse(MainWindow.InstrumentCurrentValueEnergyNight);
            var instrumentPreviousValueNight = decimal.Parse(MainWindow.InstrumentPreviousValueEnergyNight);
            var rateDay = decimal.Parse(MainWindow.RateEnergyDay);
            var rateNight = decimal.Parse(MainWindow.RateEnergyNight);

            var consumptionValueDay = instrumentCurrentValueDay - instrumentPreviousValueDay;
            var consumptionValueNight = instrumentCurrentValueNight - instrumentPreviousValueNight;

            var serviceChargesDay = consumptionValueDay * rateDay;
            var serviceChargesNight = consumptionValueNight * rateNight;
            var serviceChargesTotal = serviceChargesDay + serviceChargesNight;

            MainWindow.ConsumptionValueEnergyDay = consumptionValueDay.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ConsumptionValueEnergyNight = consumptionValueNight.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ServiceChargesEnergy = serviceChargesTotal.ToString(CalculatedValuesFormatConstans.Money);
        }

        private static void CalculateStandardVolume()
        {
            var numberResidents = int.Parse(MainWindow.NumberResidents);
            var normPerPerson = decimal.Parse(MainWindow.NormPerPersonEnergy);
            var rateGeneral = decimal.Parse(MainWindow.RateEnergyGeneral);

            var consumptionValue = numberResidents * normPerPerson;
            var serviceCharges = consumptionValue * rateGeneral;

            MainWindow.ConsumptionValueEnergyGeneral = consumptionValue.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ServiceChargesEnergy = serviceCharges.ToString(CalculatedValuesFormatConstans.Money);
        }
    }
}
