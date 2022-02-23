using GoogleProducts.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleProducts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        public IActionResult ApiEntries()
        {
            var accessToken = HttpContext.GetTokenAsync("access_token").Result;

            var client = new RestClient("https://34.120.141.153.nip.io/kg-xpo-apis");
            client.AddDefaultHeader("xpo-authorization", accessToken);
            RestRequest restRequest = new RestRequest("/entries", Method.Get);
            var response =  client.GetAsync(restRequest, default(System.Threading.CancellationToken)).Result;

            return View();
        }

        [Authorize]
        public IActionResult ApiCategories()
        {
            return View();
        }

        [Authorize]
        public IActionResult ApiRandom()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //private string GenerateJSONWebToken()
        //{
        //    JwtSecurityTokenHandler.
        //}
    }
}
