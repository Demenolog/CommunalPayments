namespace CommunalPayments.Common.DataContext.Sqlite.Models
{
    public class ReceiptData
    {
        public int Id { get; set; }

        public string CalculationYear { get; set; }

        public string CalculationMonth { get; set; }

        public string ConsumptionValueCold { get; set; }

        public string ServiceChargesCold { get; set; }

        public string ConsumptionValueHotHeatCarrier { get; set; }

        public string ConsumptionValueHotHeatEnergy { get; set; }

        public string ServiceChargesHotHeatCarrier { get; set; }

        public string ServiceChargesHotHeatEnergy { get; set; }

        public string ConsumptionValueEnergyDay { get; set; }

        public string ConsumptionValueEnergyNight { get; set; }

        public string ConsumptionValueEnergyGeneral { get; set; }

        public string ServiceChargesEnergy { get; set; }

        public string ServiceChargesTotal { get; set; }
    }
}