using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;

namespace Library
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            using BookstoreDbContext db = new BookstoreDbContext();

            //foreach (var item in db.Authors)
            //{
            //    Console.WriteLine($"Author: {item.Id} - Name: {item.Name} - Birthday: {item.BirthYear}");
            //}

            //Console.WriteLine();

            //foreach (var item in db.Books)
            //{
            //    Console.WriteLine($"Title: {item.Title} - Genre: {item.Genre} - {item.PublishedYear}");
            //}

            //var authors = db.Authors
            //                .Select(x => x.Name);


            //foreach (var author in authors) {
            //    Console.WriteLine(author);
            //}

            //var books = db.Books
            //                .Select(x => new { x.Title, x.Genre });


            //foreach (var book in books)
            //{
            //    Console.WriteLine(book);
            //}

            //var authorsNameAndBirth = db.Authors
            //                          .Select(a => new { a.Name, a.BirthYear });

            //foreach(var author in authorsNameAndBirth)
            //{
            //    Console.WriteLine(author);
            //}

            //Console.WriteLine();

            //var booksWihoutAutor = db.Books
            //                       .Select(a => new { a.Title, a.Genre, a.PublishedYear });

            //foreach(var book in booksWihoutAutor)
            //{
            //    Console.WriteLine(book);
            //    Console.WriteLine(book.Genre);
            //    Console.WriteLine(book.Title);
            //    Console.WriteLine(book.PublishedYear);
            //}

            //var booksWithNameAuthors = db.Books
            //                           .Select(a => new { a.Title, a.Genre, a.PublishedYear, NameAuthor = a.Author.Name });


            //foreach( var book in booksWithNameAuthors)
            //{
            //    Console.WriteLine(book);
            //}

            //foreach(var book in db.Books)
            //{
            //    Console.WriteLine(book.Title);
            //}

            //var authorsAfter1900 = db.Authors
            //                        .Where(y => y.BirthYear >= 1900)
            //                           .Select(x => x.Name);
            //foreach(var authors in authorsAfter1900)
            //{
            //    Console.WriteLine(authors);
            //}

            //var filterWithGenre = db.Books
            //                        .Where(x => x.Genre == "Horror")
            //                        .Select(x => new { x.Title, x.Genre });
            //foreach (var filter in filterWithGenre)
            //{
            //    Console.WriteLine(filter);
            //}

            //var last5 = db.Books.OrderByDescending(x => x.Id).Take(5);
            //foreach (var book in last5)
            //{
            //    Console.WriteLine(book.Title);
            //}
            while (true)
            {
                Console.WriteLine("Enter command:\n1-Search for book genre\n2-Books from author\n3-Books after publish year\n4-exit");
                int command = int.Parse(Console.ReadLine());
                if (command == 4) { break; }
                else if (command == 1)
                {
                    Console.Write("Type genre: ");
                    string genre = Console.ReadLine();

                    var filteredBooks = db.Books.Where(x => x.Genre == genre).Select(x => new { x.Author.Name, x.Title, x.Author.BirthYear });

                    Console.WriteLine();
                    //PrintInfo(filteredBooks);

                    Console.WriteLine(filteredBooks);

                    Console.WriteLine();
                }
                else if (command == 2)
                {
                    Console.Write("Enter 1 to ID or 2 to Name: ");
                    string type = Console.ReadLine();

                    if (type == "1")
                    {
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());

                        var books = db.Books.Where(x => x.AuthorId == id).Select(x => new { x.Author.Name, x.Title, x.Author.BirthYear });

                        Console.WriteLine();
                        //PrintInfo(books);

                        Console.WriteLine(books);

                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write("Enter name of author: ");
                        string name = Console.ReadLine();

                        //var books = db.Books.Where(x => x.Author.Name == name);
                        var books = db.Books.Include(x => x.Author).Where(a => a.Author.Name == name)
                                                                    .Select(x => new { x.Author.Name, x.Title, x.Author.BirthYear });

                        Console.WriteLine();
                        // PrintInfo(books);
                        foreach (var book in books)
                        {
                            Console.WriteLine(book);
                        }
                        Console.WriteLine();
                    }

                }
                else if (command == 3)
                {
                    Console.Write("Enter year: ");
                    int year = int.Parse(Console.ReadLine());

                    var books = db.Books.Where(x => x.PublishedYear > year).Select(x => new { x.Author.Name, x.Title, x.Author.BirthYear });

                    Console.WriteLine();
                    // PrintInfo(books);
                    foreach (var item in books)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                }
            }

        }
        public static void PrintInfo(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
