using System.Text.Json.Serialization;

public record class CoctailCategory(
    [property: JsonPropertyName("strCategory")] string CategoryName
);

