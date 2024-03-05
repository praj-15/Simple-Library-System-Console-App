using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }

    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
    }
}

class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        // Check if ISBN is already in use
        if (books.Exists(b => b.ISBN == book.ISBN))
        {
            throw new Exception("ISBN already in use. Please provide a unique ISBN.");
        }

        books.Add(book);
        Console.WriteLine("Book added to the library.");
    }

    public void RemoveBook(string isbn)
    {
        Book bookToRemove = books.Find(b => b.ISBN == isbn);

        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("Book removed from the library.");
        }
        else
        {
            Console.WriteLine("Book not found in the library.");
        }
    }

    public void ListBooks()
    {
        Console.WriteLine("Books in the library:");
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. List Books");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Title:");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter Author:");
                    string author = Console.ReadLine();
                    Console.WriteLine("Enter ISBN:");
                    string isbn = Console.ReadLine();

                    Book newBook = new Book(title, author, isbn);
                    try
                    {
                        library.AddBook(newBook);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;

                case 2:
                    Console.WriteLine("Enter ISBN of the book to remove:");
                    string isbnToRemove = Console.ReadLine();
                    library.RemoveBook(isbnToRemove);
                    break;

                case 3:
                    library.ListBooks();
                    break;

                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
