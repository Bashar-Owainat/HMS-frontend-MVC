using Microsoft.AspNetCore.Mvc;
using mvc_app.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace mvc_app.Controllers
{
    public class UsersController : Controller
    {

        private readonly HttpClient _httpClient;

        public UsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Login(UserDto userDto)
        {
            var apiEndpoint = "http://localhost:5249/api/User/Login";


            // convert to json
            var data = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");


            // make the request
            await _httpClient.PostAsync(apiEndpoint, data);

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
