using System.Text.Json.Serialization;

public record class DrinksList<T>(
    [property: JsonPropertyName("drinks")] IList<T> TList

);
