using System;

namespace LibraCoffee.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var service = new Service())
            {
                service.Start(args);
            }
        }
    }
}
