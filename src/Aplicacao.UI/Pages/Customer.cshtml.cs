using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using System;
using System.Text.Json;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Aplicacao.UI.Pages
{
    public class CustomerModel : PageModel
    {
        public async Task OnGetAsync()
        {
            var customer = await "https://localhost:44352/api/customers/v1/GetAll".GetAsync();

            //var string = customer.Content.ReadAsStringAsync();
            //var item = JsonSerializer.Deserialize(customer);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {


                return Page();
            }

            //_context.Movie.Add(Movie);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Customer");
        }
    }

    public class CustomerDTO 
    {
        public int identificador { get; set; }
        public string nomecompleto { get; set; }

        public DateTime datacadastro { get; set; }

        public string documento { get; set; }
    }

    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonConvert.SerializeObject(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpClient.PostAsync(url, content);
        }
        public static Task<HttpResponseMessage> PutAsJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonConvert.SerializeObject(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpClient.PutAsync(url, content);
        }

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var dataAsString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(dataAsString);
        }

        public static Task<HttpResponseMessage> DeleteAsync<T>(
           this HttpClient httpClient, string url, T data)
        {
            return httpClient.DeleteAsync(url);
        }
    }
}