using System;

namespace LibraCoffee.Entities.Dtos
{
    public class OrderDto
    {
        public string OrderName { get; set; }
        public DateTime DateTime { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
    }
}