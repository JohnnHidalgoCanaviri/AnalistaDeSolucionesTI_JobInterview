using System.Collections.Generic;
using System.Text.Json.Serialization;

public class ResponseModel
{
    [JsonPropertyName("verses")]
    public List<VerseInfo> Verses { get; set; }
}
