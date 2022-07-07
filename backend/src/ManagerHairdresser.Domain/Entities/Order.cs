using ManagerHairdresser.Domain.Entities.Shared;

namespace ManagerHairdresser.Domain.Entities
{
    public class Order : Entity
    {
        public Order()
        {
            Customers = new List<Customer>();
            OrderItems = new List<OrderItem>();
        }

        public int CustomerId { get; set; }
        public int Status { get; set; } = 1;

        public virtual List<Customer> Customers { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
