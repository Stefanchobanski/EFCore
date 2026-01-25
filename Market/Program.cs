using Market.Data.Models;

namespace Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new DatabaseFirstGroceryStoreContext();

            foreach (var product in db.Products)
            {
                Console.WriteLine("{0} - {1} per {2}",
                    product.Name,
                    product.Price,
                    product.UnitType);
            }

        }
    }
}
