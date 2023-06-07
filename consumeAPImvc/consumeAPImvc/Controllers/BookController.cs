using consumeAPImvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace consumeAPImvc.Controllers
{
    public class BookController : Controller
    {
        // GET Books
        public IActionResult Index()
        {
            IEnumerable<Book> books = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64189/api/");
                //HTTP GET
                var responseTask = client.GetAsync("book");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Book>>();
                    readTask.Wait();

                    books = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    books = Enumerable.Empty<Book>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(books);
        }
    }
}
