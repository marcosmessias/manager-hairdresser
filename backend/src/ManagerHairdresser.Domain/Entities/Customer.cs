using ManagerHairdresser.Domain.Entities.Shared;

namespace ManagerHairdresser.Domain.Entities
{
    public class Customer : Entity
    {
        public const string Table = "Customer";
        public string Name { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
