using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Chapter
{
    [JsonPropertyName("number")]
    public int Number { get; set; }

    [JsonPropertyName("verses")]
    public List<Verse>? Verses { get; set; }
}
