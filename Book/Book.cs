using System.Text.Json.Serialization;

public class Book
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("abbrev")]
    public string Abbrev { get; set; }

    [JsonPropertyName("author")]
    public string Author { get; set; }
}
