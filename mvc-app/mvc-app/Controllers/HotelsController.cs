using Microsoft.AspNetCore.Mvc;
using mvc_app.Models;
using mvc_app.Models.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
namespace mvc_app.Controllers
{
    public class HotelsController : Controller
    {
      
        private readonly HttpClient _httpClientFactory;


        public HotelsController( IHttpClientFactory httpClientFactory)
        {
           
            _httpClientFactory = httpClientFactory.CreateClient(); ;
        }

        public async Task<IActionResult> Index()
        {
            var apiEndpoint = "http://localhost:5249/api/Hotels";


            // make the request
            var response = await _httpClientFactory.GetAsync(apiEndpoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                List<Hotel> hotelsList = JsonConvert.DeserializeObject<List<Hotel>>(content);

                return View("Index", hotelsList);
            }
            else
            {
                return Redirect("users/login");
            }
            
        }

        public async Task<IActionResult> Create(Hotel hotel)
        {
            var apiEndpoint = "http://localhost:5249/api/Hotels";

            var data = new StringContent(JsonConvert.SerializeObject(hotel), Encoding.UTF8, "application/json");

            // make the request
            var response = await _httpClientFactory.PostAsync(apiEndpoint,data );

            if (response.IsSuccessStatusCode)
            {
                return Redirect("/hotels");

            }
            else
            {
                return Redirect("/");
            }

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();

        }

    }
}
