using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraCoffee.Entities.Models
{
    public class Coffee
    {
        public int CoffeeId { get; set; }
        public string CoffeeName { get; set; }
        public int Price { get; set; }
    }

    public class CoffeeConfiguration : IEntityTypeConfiguration<Coffee>
    {
        public void Configure(EntityTypeBuilder<Coffee> builder)
        {
            builder.HasKey(c => c.CoffeeId);
            builder.Property(c => c.CoffeeName).IsRequired().HasMaxLength(64);
            builder.Property(c => c.Price).IsRequired();
        }
    }
}