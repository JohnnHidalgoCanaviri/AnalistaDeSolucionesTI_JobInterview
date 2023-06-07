using System.Text.Json.Serialization;

public class VerseInfo
{
    [JsonPropertyName("book")]
    public Book Book { get; set; }

    [JsonPropertyName("chapter")]
    public Chapter Chapter { get; set; }
}
