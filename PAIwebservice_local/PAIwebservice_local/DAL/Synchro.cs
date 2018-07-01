using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PAIwebservice_local.Models;
using PAIwebservice_local.Controllers;
using PAIwebservice_local.DAL.repositories;

namespace PAIwebservice_local.DAL
{
    public class Synchro
    {
        private static HttpClient httpClient;

        public Synchro()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:62825/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        private static async Task<T> GetItemAsync<T>(string path) where T : class
        {
            T item = null;
            HttpResponseMessage response = await httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                item = await response.Content.ReadAsAsync<T>();
            }
            return item;
        }
        public async Task RunAsync()
        {
            List<Product> produkty = await GetItemAsync<List<Product>>("api/products");
            if (produkty != null)
            {
                DateTime lastUpdate = produkty.Max(x => x.data);
                List<Product> productsToUpdate = ProductRepository.GetProducts().Where(x => x.data > lastUpdate).ToList();
                foreach (Product productToUpdate in productsToUpdate)
                { 
                    await httpClient.PostAsJsonAsync("api/products", productToUpdate);
                }
            }
            List<Category> categories = await GetItemAsync<List<Category>>("api/categories");
            if (categories != null)
            {
                DateTime lastUpdate = categories.Max(x => x.data);
                List<Category> categoriesToUpdate = CategoryRepository.GetCategories().Where(x => x.data > lastUpdate).ToList();
                foreach (Category categoryToUpdate in categoriesToUpdate)
                {
                    await httpClient.PostAsJsonAsync("api/categories", categoryToUpdate);
                }
            }
            List<Order> orders = await GetItemAsync<List<Order>>("api/orders");
            if (orders != null)
            {
                DateTime lastUpdate = orders.Max(x => x.data);
                List<Order> ordersToUpdate = OrderRepository.GetOrders().Where(x => x.data > lastUpdate).ToList();
                foreach (Order orderToUpdate in ordersToUpdate)
                {
                    await httpClient.PostAsJsonAsync("api/orders", orderToUpdate);
                }
            }
            List<Client> clients = await GetItemAsync<List<Client>>("api/clients");
            if (clients != null)
            {
                DateTime lastUpdate = clients.Max(x => x.data);
                List<Client> clientsToUpdate = ClientRepository.GetClients().Where(x => x.data > lastUpdate).ToList();
                foreach(Client clientToUpdate in clientsToUpdate)
                {
                    await httpClient.PostAsJsonAsync("api/clients", clientToUpdate);
                }
            }
        }
        }
}