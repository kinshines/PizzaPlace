using Microsoft.AspNetCore.Components;
using PizzaPlace.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaPlace.Client.Services
{
    public class OrderService : IOrderService
    {
        private HttpClient httpClient;
        public OrderService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task PlaceOrder(Basket basket)
        {
            await httpClient.PostJsonAsync("/orders", basket);
        }
    }
}
