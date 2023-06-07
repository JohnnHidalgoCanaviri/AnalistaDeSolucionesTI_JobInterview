using consumeAPImvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

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
                client.BaseAddress = new Uri("https://www.abibliadigital.com.br/api/books");
                //HTTP GET
                var responseTask = client.GetAsync("book");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // var readTask = result.Content.ReadAsAsync<IList<Book>>();
                    string responseContent = result.Content.ReadAsStringAsync();
                    var readTask = JsonConverter.DeserializeObject<Book>(responseContent);

                    readTask.Wait();

                    books = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    books = Enumerable.Empty<Book>();

                    ModelState.AddModelError(string.Empty, "Error en el servidor. Por favor contactese con el administrador.");
                }
            }
            return View(books);
        }
    }
}
