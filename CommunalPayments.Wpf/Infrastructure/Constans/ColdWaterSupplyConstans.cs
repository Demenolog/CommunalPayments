using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPayments.Wpf.Infrastructure.Constans
{
    internal static class ColdWaterSupplyConstans
    {
        private const decimal NormPerPerson = 4.85M;
        private const decimal Rate = 35.78M;

        public static decimal GetNormPerPerson() => NormPerPerson;
        public static decimal GetRate() => Rate;
    }
}
