using Library.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            using BookstoreDbContext db = new BookstoreDbContext();

            foreach (var item in db.Authors)
            {
                Console.WriteLine($"Author: {item.Id} - Name: {item.Name} - Birthday: {item.BirthYear}");
            }

            Console.WriteLine();

            foreach (var item in db.Books)
            {
                Console.WriteLine($"Title: {item.Title} - Genre: {item.Genre} - {item.PublishedYear}");
            }
        }
    }
}
