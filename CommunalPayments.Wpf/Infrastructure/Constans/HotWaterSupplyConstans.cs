using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPayments.Wpf.Infrastructure.Constans
{
    internal static class HotWaterSupplyConstans
    {
        private const decimal NormPerPersonHeatCarrier = 4.01M;
        private const decimal NormPerPersonHeatEnergy = 0.05349M;
        private const decimal RateHeatCarrier = 35.78M;
        private const decimal RateHeatEnergy = 998.69M;

        public static decimal GetNormPerPersonHeatCarrier() => NormPerPersonHeatCarrier;

        public static decimal GetNormPerPersonHeatEnergy() => NormPerPersonHeatEnergy;

        public static decimal GetRateHeatCarrier() => RateHeatCarrier;

        public static decimal GetRateHeatEnergy() => RateHeatEnergy;
    }
}
