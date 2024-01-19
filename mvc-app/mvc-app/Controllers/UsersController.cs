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

        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var apiEndpoint = "http://localhost:5249/api/User/Login";

            ViewBag.login = "Login";
            // convert to json
            var data = new StringContent(JsonConvert.SerializeObject(loginDTO), Encoding.UTF8, "application/json");


            // make the request
            var  response = await _httpClient.PostAsync(apiEndpoint, data);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/");
            }
           
            return View();
        }

        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var apiEndpoint = "http://localhost:5249/api/User/Register";

            ViewBag.register = "Register";
            // convert to json
            var data = new StringContent(JsonConvert.SerializeObject(registerDTO), Encoding.UTF8, "application/json");


            // make the request
            var response = await _httpClient.PostAsync(apiEndpoint, data);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/");
            }

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
