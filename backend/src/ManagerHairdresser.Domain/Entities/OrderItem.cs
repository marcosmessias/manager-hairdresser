using ManagerHairdresser.Domain.Entities.Shared;

namespace ManagerHairdresser.Domain.Entities
{
    public class OrderItem : Entity
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
    }
}
