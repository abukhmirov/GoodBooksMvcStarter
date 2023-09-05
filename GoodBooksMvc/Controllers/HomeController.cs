using GoodBooksMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GoodBooksMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!Request.Cookies.ContainsKey("PageVisitCounter"))
            {
                Response.Cookies.Append("PageVisitCounter", "1");
            }
            else
            {
                if (int.TryParse(Request.Cookies["PageVisitCounter"], out int pageCount))
                {
                    pageCount++;
                    Response.Cookies.Append("PageVisitCounter", pageCount.ToString());
                    ViewData["visitCount"] = pageCount;
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}