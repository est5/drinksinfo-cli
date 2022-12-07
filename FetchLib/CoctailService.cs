using System.Text.Json;

namespace FetchLib;

public class CoctailService
{
    private static readonly HttpClient client = new HttpClient();
    public async Task<IList<CoctailCategory>> GetCategories()
    {
        try
        {
            using var stream = await client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
            var categories = await JsonSerializer.DeserializeAsync<DrinksList<CoctailCategory>>(stream);

            return categories?.TList ?? new List<CoctailCategory>();
        }
        catch (Exception e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }

        return new List<CoctailCategory>();
    }

    public async Task<IList<Drink>> GetDrinksByCategory(CoctailCategory category)
    {
        try
        {
            using var stream = await client.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={category.CategoryName}");
            var drinks = await JsonSerializer.DeserializeAsync<DrinksList<Drink>>(stream);

            return drinks?.TList ?? new List<Drink>();
        }
        catch (Exception e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }


        return new List<Drink>();
    }

}
