using CommunalPayments.Wpf.Infrastructure.Constans;
using CommunalPayments.Wpf.ViewModels;
using System;
using CommunalPayments.Wpf.Services;

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
            decimal instrumentCurrentValueDay;
            decimal instrumentPreviousValueDay;
            decimal instrumentCurrentValueNight;
            decimal instrumentPreviousValueNight;
            decimal rateDay;
            decimal rateNight;
            decimal consumptionValueDay;
            decimal consumptionValueNight;
            decimal serviceChargesDay;
            decimal serviceChargesNight;
            decimal serviceChargesTotal;

            checked
            {
                instrumentCurrentValueDay = decimal.Parse(MainWindow.InstrumentCurrentValueEnergyDay);
                instrumentPreviousValueDay = decimal.Parse(MainWindow.InstrumentPreviousValueEnergyDay);
                instrumentCurrentValueNight = decimal.Parse(MainWindow.InstrumentCurrentValueEnergyNight);
                instrumentPreviousValueNight = decimal.Parse(MainWindow.InstrumentPreviousValueEnergyNight);
                rateDay = decimal.Parse(MainWindow.RateEnergyDay);
                rateNight = decimal.Parse(MainWindow.RateEnergyNight);

                consumptionValueDay = instrumentCurrentValueDay - instrumentPreviousValueDay;
                consumptionValueNight = instrumentCurrentValueNight - instrumentPreviousValueNight;

                serviceChargesDay = consumptionValueDay * rateDay;
                serviceChargesNight = consumptionValueNight * rateNight;
                serviceChargesTotal = serviceChargesDay + serviceChargesNight;
            }

            MainWindow.ConsumptionValueEnergyDay = consumptionValueDay.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ConsumptionValueEnergyNight = consumptionValueNight.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ServiceChargesEnergy = serviceChargesTotal.ToString(CalculatedValuesFormatConstans.Money);
        }

        private static void CalculateStandardVolume()
        {
            int numberResidents;
            decimal normPerPerson;
            decimal rateGeneral;
            decimal consumptionValue;
            decimal serviceCharges;

            checked
            {
                numberResidents = int.Parse(MainWindow.NumberResidents);
                normPerPerson = decimal.Parse(MainWindow.NormPerPersonEnergy);
                rateGeneral = decimal.Parse(MainWindow.RateEnergyGeneral);

                consumptionValue = numberResidents * normPerPerson;
                serviceCharges = consumptionValue * rateGeneral;
            }

            MainWindow.ConsumptionValueEnergyGeneral = consumptionValue.ToString(CalculatedValuesFormatConstans.Common);
            MainWindow.ServiceChargesEnergy = serviceCharges.ToString(CalculatedValuesFormatConstans.Money);
        }
    }
}