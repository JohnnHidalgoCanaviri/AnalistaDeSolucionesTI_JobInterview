using System.Text.Json.Serialization;

public class Verse
{
    [JsonPropertyName("number")]
    public int Number { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }
}
