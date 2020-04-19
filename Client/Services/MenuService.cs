using Microsoft.AspNetCore.Components;
using PizzaPlace.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaPlace.Client.Services
{
    public class MenuService : IMenuService
    {
        private HttpClient httpClient;
        public MenuService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Menu> GetMenu()
        {
            var pizzas = await httpClient.GetJsonAsync<Pizza[]>("/pizzas");
            return new Menu() { Pizzas = pizzas.ToList() };
        }
    }
}
