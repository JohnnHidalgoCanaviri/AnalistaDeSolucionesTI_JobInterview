using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        //configuramos el envio del http
        HttpClient client = new HttpClient();
        string apiUrl = "https://www.abibliadigital.com.br/api/books";
        HttpResponseMessage response = await client.GetAsync(apiUrl);

        //Si la conexión satisfactoria consumimos el http
        if (response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<ResponseModel>(responseContent, options);

            // Leer datos deserializados
            foreach (var verseInfo in data.Verses)
            {
                Console.WriteLine($"Libro: {verseInfo.Book.Name}");
                Console.WriteLine($"Capítulo: {verseInfo.Chapter.Number}");

                foreach (var verse in verseInfo.Chapter.Verses)
                {
                    Console.WriteLine($"Versículo {verse.Number}: {verse.Text}");
                }

                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine($"Error al obtener la respuesta. Código de estado: {response.StatusCode}");
        }
    }
}
