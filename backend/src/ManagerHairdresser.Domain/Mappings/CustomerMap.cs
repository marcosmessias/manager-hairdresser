using ManagerHairdresser.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagerHairdresser.Domain.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(Customer.Table);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name);
        }
    }
}
