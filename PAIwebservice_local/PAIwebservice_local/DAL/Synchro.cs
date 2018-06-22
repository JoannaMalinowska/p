using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PAIwebservice_local.Models;
using PAIwebservice_local.Controllers;

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
        }
        }
}