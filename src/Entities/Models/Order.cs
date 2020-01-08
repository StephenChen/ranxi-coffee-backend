using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraCoffee.Entities.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public DateTime DateTime { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);
            builder.Property(o => o.OrderName).IsRequired().HasMaxLength(128);
            builder.Property(o => o.DateTime).IsRequired();
            // builder.HasOne(o => o.Customer).WithMany(c => c.Orders)
            //     .HasForeignKey(o => o.CustomerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.Customer).WithMany().HasForeignKey(o => o.CustomerId);
        }
    }
}