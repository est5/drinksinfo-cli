using FetchLib;

namespace Cli.Util;

public static class Display
{
    private static readonly CoctailService coctailService = new();
    public static async Task Menu()
    {
        var categories = await coctailService.GetCategories();
        var menuMap = new Dictionary<int, string>();
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
            menuMap.Add(count, c.CategoryName);
            count++;
        }
        var input = GetInput(count);
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

    private static void GetDrinksByCategory()
    {

    }
}
