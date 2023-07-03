using CommunalPayments.Wpf.Infrastructure.Constans;
using CommunalPayments.Wpf.ViewModels;
using System;

namespace CommunalPayments.Wpf.Models
{
    public static class CalculationServiceChargesTotal
    {
        private static readonly MainWindowViewModel MainWindow = new ViewModelLocator().MainWindowModel;

        public static void Calculate()
        {
            try
            {
                var serviceChargesCold = decimal.Parse(MainWindow.ServiceChargesCold);
                var serviceChargesHotHeatCarrier = decimal.Parse(MainWindow.ServiceChargesHotHeatCarrier);
                var serviceChargesHotHeatEnergy = decimal.Parse(MainWindow.ServiceChargesHotHeatEnergy);
                var serviceChargesEnergy = decimal.Parse(MainWindow.ServiceChargesEnergy);

                decimal serviceChargesTotal = serviceChargesCold + serviceChargesHotHeatCarrier + serviceChargesHotHeatEnergy + serviceChargesEnergy;

                MainWindow.ServiceChargesTotal = serviceChargesTotal.ToString(CalculatedValuesFormatConstans.Money);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}