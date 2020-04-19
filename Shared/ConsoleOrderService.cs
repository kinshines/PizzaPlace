using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPlace.Shared
{
    public class ConsoleOrderService : IOrderService
    {
        public Task PlaceOrder(Basket basket)
        {
            Console.WriteLine($"Placing order for {basket.Customer.Name}");
            return Task.CompletedTask;
        }
    }
}
