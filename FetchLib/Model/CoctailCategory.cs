using System.Collections.Generic;
using System.Collections;
using System.Text.Json.Serialization;

public record class CoctailCategory(
    [property: JsonPropertyName("strCategory")] string CategoryName
);

public record class Drinks(
    [property: JsonPropertyName("drinks")] IList<CoctailCategory> CategoryList
);

