using AppBooks.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CapaNegocio;
using CapaModelo;

namespace AppBooks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            BookNegocio n = new BookNegocio();
            List<Book> books = new List<Book>();
            books = await n.GetBooks();
            return View(books);
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