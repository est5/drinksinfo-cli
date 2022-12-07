using FetchLib;

namespace Cli.Util;

public static class Display
{
    private static readonly CoctailService _coctailService = new();
    private static readonly Dictionary<int, string> _menuMap = new();

    public static async Task Menu()
    {
        var categories = await _coctailService.GetCategories();
        int count = 1;

        Console.WriteLine("Select category(enter number): ");
        foreach (var c in categories)
        {
            var toPrint = $"| {count}: {c.CategoryName} |";
            for (int i = 0; i < toPrint.Length; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine("\n" + toPrint);
            for (int i = 0; i < toPrint.Length; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
            _menuMap.Add(count, c.CategoryName);
            count++;
        }
        var input = GetInput(count);

        var drinksList = await GetDrinksAsync(input);
        foreach (var drink in drinksList)
        {
            Console.WriteLine(drink.DrinkName);
        }
    }

    private static int GetInput(int range)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Enter value...");
                var input = Convert.ToInt32(Console.ReadLine());
                if (input < 1 && input > range)
                {
                    Console.WriteLine($"Value must be in range [1..{range}]");
                    continue;
                }

                return input;
            }
            catch (System.Exception)
            {
                Console.WriteLine($"Value must be an integer");
            }
        }
    }

    private static async Task<IList<Drink>> GetDrinksAsync(int category)
    {
        var request = _menuMap[category];
        var drinks = await _coctailService.GetDrinksByCategory(new CoctailCategory(request));

        return drinks;
    }
}
