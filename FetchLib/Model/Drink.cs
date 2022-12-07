using System;
using System.Text.Json.Serialization;

public record class Drink(
    [property: JsonPropertyName("strDrink")] string DrinkName,
    [property: JsonPropertyName("idDrink")] string DrinkId
);
