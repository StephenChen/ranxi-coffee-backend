using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraCoffee.Entities.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Date { get; set; }
    }

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);
            builder.Property(c => c.CustomerName).IsRequired().HasMaxLength(64);
            builder.Property(c => c.Gender).IsRequired();
            builder.Property(c => c.Date).IsRequired();
        }
    }
}