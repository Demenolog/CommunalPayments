using CommunalPayments.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunalPayments.Wpf.Infrastructure.Constans;

namespace CommunalPayments.Wpf.Services
{
    public static class ServiceChargesTotalCalculationService
    {
        private static readonly MainWindowViewModel MainWindow = new ViewModelLocator().MainWindowModel;

        public static void Calculate()
        {
            var serviceChargesCold = decimal.Parse(MainWindow.ServiceChargesCold);
            var serviceChargesHotHeatCarrier = decimal.Parse(MainWindow.ServiceChargesHotHeatCarrier);
            var serviceChargesHotHeatEnergy = decimal.Parse(MainWindow.ServiceChargesHotHeatEnergy);
            var serviceChargesEnergy = decimal.Parse(MainWindow.ServiceChargesEnergy);

            var serviceChargesTotal = serviceChargesCold + serviceChargesHotHeatCarrier + serviceChargesHotHeatEnergy + serviceChargesEnergy;

            MainWindow.ServiceChargesTotal = serviceChargesTotal.ToString(CalculatedValuesFormatConstans.Money);
        }
    }
}
