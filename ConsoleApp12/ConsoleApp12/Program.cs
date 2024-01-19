
using System;
using System.Collections.Generic;
using System.Linq;
 
class Program
{
    static void Main()
    {
        Library library = new Library();

        // Adding books to the library
        library.AddBook(new FictionBook("book a", "author a"));
        library.AddBook(new NonFictionBook("book b", "author b"));
        library.AddBook(new FictionBook("book c", "author c"));
        library.AddBook(new FictionBook("book a", "author a")); // Adding another copy
        library.AddBook(new FictionBook("book a", "author a")); // Adding another copy


        // Display available books with count
        Console.WriteLine("Available Books with Count:");
        library.DisplayAvailableBooks();


        // Borrowing a book
        library.BorrowBook("book a");
        Console.WriteLine("\nAfter borrowing 'book a':");
        library.DisplayAvailableBooks();

        library.BorrowBook("book a");
        Console.WriteLine("\nAfter borrowing 'book a':");
        library.DisplayAvailableBooks();


        // Returning a book
        library.ReturnBook("book a");
        Console.WriteLine("\nAfter returning 'book a':");
        library.DisplayAvailableBooks();
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}

class FictionBook : Book
{
    public FictionBook(string title, string author) : base(title, author)
    {
        // Additional properties or methods specific to fiction books can be added here
    }
}

class NonFictionBook : Book
{
    public NonFictionBook(string title, string author) : base(title, author)
    {
        // Additional properties or methods specific to non-fiction books can be added here
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
        books.Add(book);
    }

    public void BorrowBook(string title)
    {
        Book bookToBorrow = books.FirstOrDefault(b => b.Title == title);

        if (bookToBorrow != null)
        {
            books.Remove(bookToBorrow);
            Console.WriteLine($"Book '{title}' borrowed successfully.");
        }
        else
        {
            Console.WriteLine($"Book '{title}' is not available for borrowing.");
        }
    }

    public void ReturnBook(string title)
    {
        Book bookToReturn = books.FirstOrDefault(b => b.Title == title);

        if (bookToReturn != null)
        {
            books.Add(bookToReturn);
            Console.WriteLine($"Book '{title}' returned successfully.");
        }
        else
        {
            Console.WriteLine($"Book '{title}' is not in the list of borrowed books.");
        }
    }

    public void DisplayAvailableBooks()
    {
        var groupedBooks = books.GroupBy(b => new { b.Title, b.Author })
                               .Select(group => new { Book = group.Key, Count = group.Count() });

        foreach (var entry in groupedBooks)
        {
            Console.WriteLine($"{entry.Book.Title} by {entry.Book.Author} - Count: {entry.Count}");
        }
    }
}

