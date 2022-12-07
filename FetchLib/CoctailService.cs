using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace FetchLib;

public class CoctailService
{
    static readonly HttpClient client = new HttpClient();
    public async Task<IList<CoctailCategory>> GetCategories()
    {
        try
        {
            using var stream = await client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
            var drinks = await JsonSerializer.DeserializeAsync<Drinks>(stream);

            return drinks?.CategoryList ?? new List<CoctailCategory>();
        }
        catch (Exception e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }

        return new List<CoctailCategory>();
    }


}
