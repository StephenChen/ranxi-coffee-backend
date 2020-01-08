using System;
using System.Linq;
using System.Collections.Generic;
using LibraCoffee.Entities.Models;

namespace LibraCoffee.Entities.Seed
{
    public static class LibraCoffeeDbContextExtensions
    {
        public static void EnsureSeedDataForContext(this LibraCoffeeDbContext context)
        {
            if (context.Orders.Any())
            {
                return;
            }
            Coffee coffee1 = new Coffee { CoffeeName = "Coffee1", Price = 10 };
            Coffee coffee2 = new Coffee { CoffeeName = "Coffee2", Price = 20 };
            Coffee coffee3 = new Coffee { CoffeeName = "Coffee3", Price = 30 };
            Coffee coffee4 = new Coffee { CoffeeName = "Coffee4", Price = 10 };
            Coffee coffee5 = new Coffee { CoffeeName = "Coffee5", Price = 20 };
            Coffee coffee6 = new Coffee { CoffeeName = "Coffee6", Price = 30 };
            Customer customer1 = new Customer { CustomerName = "customer1", Gender = Gender.Man, Date = new DateTime(1994, 10, 01) };
            Customer customer2 = new Customer { CustomerName = "customer2", Gender = Gender.Woman, Date = new DateTime(1994, 10, 02) };
            Customer customer3 = new Customer { CustomerName = "customer3", Gender = Gender.Man, Date = new DateTime(1994, 10, 03) };
            context.Coffees.AddRange(new List<Coffee> { coffee1, coffee2, coffee3, coffee4, coffee5, coffee6 });
            context.Customers.AddRange(new List<Customer> { customer1, customer2, customer3 });
            context.SaveChanges();

            Order order1 = new Order { OrderName = $"{DateTime.Now.Date.ToString("yyyymmdd")}-{1}", DateTime = DateTime.Now.Date, Customer = customer1 };
            Order order2 = new Order { OrderName = $"{DateTime.Now.Date.ToString("yyyymmdd")}-{2}", DateTime = DateTime.Now.Date, Customer = customer2 };
            Order order3 = new Order { OrderName = $"{DateTime.Now.Date.ToString("yyyymmdd")}-{3}", DateTime = DateTime.Now.Date, Customer = customer3 };
            Order order4 = new Order { OrderName = $"{DateTime.Now.Date.ToString("yyyymmdd")}-{4}", DateTime = DateTime.Now.Date, Customer = customer1 };
            context.Orders.Add(order1); context.SaveChanges();
            context.Orders.Add(order2); context.SaveChanges();
            context.Orders.Add(order3); context.SaveChanges();
            context.Orders.Add(order4); context.SaveChanges();

            OrderDetail orderDetail1 = new OrderDetail { OrderId = 1, CoffeeId = 1, CoffeeCount = 1 };
            OrderDetail orderDetail2 = new OrderDetail { OrderId = 1, CoffeeId = 2, CoffeeCount = 1 };
            OrderDetail orderDetail3 = new OrderDetail { OrderId = 2, CoffeeId = 3, CoffeeCount = 1 };
            OrderDetail orderDetail4 = new OrderDetail { OrderId = 2, CoffeeId = 4, CoffeeCount = 1 };
            OrderDetail orderDetail5 = new OrderDetail { OrderId = 3, CoffeeId = 1, CoffeeCount = 1 };
            OrderDetail orderDetail6 = new OrderDetail { OrderId = 3, CoffeeId = 2, CoffeeCount = 1 };
            OrderDetail orderDetail7 = new OrderDetail { OrderId = 3, CoffeeId = 3, CoffeeCount = 1 };
            OrderDetail orderDetail8 = new OrderDetail { OrderId = 3, CoffeeId = 4, CoffeeCount = 1 };
            OrderDetail orderDetail9 = new OrderDetail { OrderId = 3, CoffeeId = 5, CoffeeCount = 1 };
            OrderDetail orderDetail10 = new OrderDetail { OrderId = 3, CoffeeId = 6, CoffeeCount = 1 };
            OrderDetail orderDetail11 = new OrderDetail { OrderId = 4, CoffeeId = 5, CoffeeCount = 2 };
            OrderDetail orderDetail12 = new OrderDetail { OrderId = 4, CoffeeId = 6, CoffeeCount = 2 };
            context.OrderDetails.Add(orderDetail1); context.SaveChanges();
            context.OrderDetails.Add(orderDetail2); context.SaveChanges();
            context.OrderDetails.Add(orderDetail3); context.SaveChanges();
            context.OrderDetails.Add(orderDetail4); context.SaveChanges();
            context.OrderDetails.Add(orderDetail5); context.SaveChanges();
            context.OrderDetails.Add(orderDetail6); context.SaveChanges();
            context.OrderDetails.Add(orderDetail7); context.SaveChanges();
            context.OrderDetails.Add(orderDetail8); context.SaveChanges();
            context.OrderDetails.Add(orderDetail9); context.SaveChanges();
            context.OrderDetails.Add(orderDetail10); context.SaveChanges();
            context.OrderDetails.Add(orderDetail11); context.SaveChanges();
            context.OrderDetails.Add(orderDetail12); context.SaveChanges();
        }
    }
}