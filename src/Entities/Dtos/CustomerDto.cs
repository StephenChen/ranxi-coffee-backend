using System;

namespace LibraCoffee.Entities.Dtos
{
    public class CustomerDto
    {
        public string CustomerName { get; set; }
        public LibraCoffee.Entities.Models.Gender Gender { get; set; }
        public DateTime Date { get; set; }
    }
}