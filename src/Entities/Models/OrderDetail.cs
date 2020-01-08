using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraCoffee.Entities.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CoffeeId { get; set; }
        public int CoffeeCount { get; set; }
    }

    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderId).IsRequired();
            builder.Property(o => o.CoffeeId).IsRequired();
            builder.Property(o => o.CoffeeCount).IsRequired();
        }
    }
}