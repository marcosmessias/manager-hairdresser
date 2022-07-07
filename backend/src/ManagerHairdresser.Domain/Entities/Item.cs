using ManagerHairdresser.Domain.Entities.Shared;

namespace ManagerHairdresser.Domain.Entities
{
    public class Item : Entity
    {
        public int ItemTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal InputPrice { get; set; } = 0;
        public decimal OutputPrice { get; set; } = 0;
        public int Status { get; set; } = 1;
    }
}
