using System.Text.Json;
using FetchLib;

var coctail = new CoctailService();
var categories = await coctail.GetCategories();
foreach (var cat in categories)
{
    System.Console.WriteLine(cat.CategoryName);
}
