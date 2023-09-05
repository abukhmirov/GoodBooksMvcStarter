using GoodBooksMvc.DataAccess;
using GoodBooksMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GoodBooksMvc.Controllers
{
    public class BooksController : Controller
    {
        //private readonly ILogger<BooksController> _logger;

        //public BooksController(ILogger<BooksController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly GoodBooksMvcContext _context;

        public BooksController(GoodBooksMvcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books;

            return View(books);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}