namespace LibraCoffee.Entities.Dtos
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public int CoffeeId { get; set; }
        public int CoffeeCount { get; set; }
    }
}