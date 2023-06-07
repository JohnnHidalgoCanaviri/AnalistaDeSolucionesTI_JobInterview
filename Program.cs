using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
        static HttpClient client = new HttpClient();
        
        //Metodo implementada
        static void ShowBook(Book book)
        {
            Console.WriteLine($"Author: {book.author}\tChapters: " +
                $"{book.chapters}\tGroup: {book.group}\tName: {book.name}\ttestament: {book.testamenent}" +
                $"\tAbbrev\tPt: {book.abbrev.pt}\tEn: {book.abbrev.en}");
        }
        
        //no implementada
        static async Task<Uri> CreateBookAsync(Book book)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/books", book);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        //no implementada
        static async Task<Book> GetBookAsync(string path)
        {
            Product book = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                book = await response.Content.ReadAsAsync<Book>();
            }
            return product;
        }


        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://www.abibliadigital.com.br/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                
                // Get the product
                product = await GetProductAsync(url.PathAndQuery);
                ShowProduct(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
}
