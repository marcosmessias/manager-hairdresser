using ManagerHairdresser.Domain.Entities.Shared;

namespace ManagerHairdresser.Domain.Entities
{
    public class Payment : Entity
    {
        public int OrderId { get; set; }
        public int PaymentTypeId { get; set; }
        public string Note { get; set; } = string.Empty;
        public int WasPaid { get; set; }
        public DateTime PaymentForecastDate { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
