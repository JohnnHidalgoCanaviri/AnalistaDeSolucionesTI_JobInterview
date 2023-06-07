using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using CapaModelo;
using Newtonsoft.Json;

namespace CapaNegocio
{
    public class BookNegocio
    {
        public async Task<List<Book>> GetBooks()
        {

            List<Book> books = new List<Book>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.abibliadigital.com.br/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/books");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    // List<Book> data = new List<Book>();
                    List<Book> data = JsonConvert.DeserializeObject<List<Book>>(jsonResponse);
                    //return data;
                    books = data;
                    // var books = await response.Content.ReadAsAsync<Book>();
                }
            }
            return books;

            // return books;
        }

        public static string Serialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.UTF8.GetString(ms.ToArray());
            return retVal;
        }

        public static T Deserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            return obj;
        }
    }
}
