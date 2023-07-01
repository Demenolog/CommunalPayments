using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPayments.Wpf.Infrastructure.Constans
{
    internal static class ElectricPowerSupplyConstans
    {
        private const decimal NormPerPersonEnergy = 164M;
        private const decimal RateEnergyGeneral = 4.28M;
        private const decimal RateEnergyDay = 4.9M;
        private const decimal RateEnergyNight = 2.31M;

        public static decimal GetNormPerPersonEnergy() => NormPerPersonEnergy;

        public static decimal GetRateEnergyGeneral() => RateEnergyGeneral;

        public static decimal GetRateEnergyDay() => RateEnergyDay;

        public static decimal GetRateEnergyNight() => RateEnergyNight;
    }
}
