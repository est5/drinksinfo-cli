using FetchLib;

var coctail = new CoctailService();
var categories = await coctail.GetCategories();

var s = await coctail.GetDrinksByCategory(new CoctailCategory("Other/Unknown"));
foreach (var item in s)
{
    System.Console.WriteLine(item.DrinkName);
}

