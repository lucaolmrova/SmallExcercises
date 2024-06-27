public class Book
{
    public string Title { get; set; }
    
    public string Author { get; set; }
    
    public bool IsAvailable { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
        IsAvailable = true;  // All new books are available by default
    }
}

public class Library
{
    private List<Book> books;

    public Library() // constructor
    {
        books = new List<Book>();
    }

    public void AddBook(string title, string author) 
    {
        Book book = new Book(title, author);
        books.Add(book);
    }

    public void ViewAvailableBooks()
    {
        int bookAmount = books.Count();
        for (int i = 0; i < bookAmount; i++)
        {
            if (books[i].IsAvailable)
            {
                Console.WriteLine(books[i].Title + ", " + books[i].Author);
            }
        }
    }

    public void BorrowBook()
    {
        Console.WriteLine("Write name of the book you want to borrow:");
        string bookToBorrow = Console.ReadLine();
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Title == bookToBorrow)
            {
                books[i].IsAvailable = false;
                Console.WriteLine(books[i].Title + "|" + books[i].Author + "|" + books[i].IsAvailable);
            }

        }
    }

    public void ReturnBook()
    {
        Console.WriteLine("Write name of the book you want to return:");
        string bookToReturn = Console.ReadLine();
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Title == bookToReturn)
            {
                books[i].IsAvailable = true;
                Console.WriteLine(books[i].Title + "|" + books[i].Author + "|" + books[i].IsAvailable);
            }

        }

    }

    public void SearchBooks(string searchBy)
    {
        
        if (searchBy == "T")
        {
            Console.WriteLine("Write name of the book: ");
            string searchedTitle = Console.ReadLine();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == searchedTitle)
                {
                    Console.WriteLine($"{books[i].Title}|{books[i].Author}|{books[i].IsAvailable}");
                }
            }
        }
        else if (searchBy == "A")
        {
            Console.WriteLine("Write author of the book: ");
            string searchedAuthor = Console.ReadLine();
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author == searchedAuthor)
                {
                    Console.WriteLine($"{books[i].Title}|{books[i].Author}|{books[i].IsAvailable}");
                }
            }
        }
    }
    
    public void SortBooks()
    {
        books.Sort((x, y) => String.Compare(x.Title, y.Title, StringComparison.Ordinal));
    }


    public void SaveLibraryState()
    {
        using (var writer = new StreamWriter("library.txt"))
        {
            foreach (var book in books)
            {
                writer.WriteLine($"{book.Title}|{book.Author}|{book.IsAvailable}");
            }
        }
    }

    public void LoadLibraryState()
    {
        if (!File.Exists("library.txt")) return;
        using (var reader = new StreamReader("library.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string title = line.Split("|")[0];
                string author = line.Split("|")[1];
                bool isAvailable = bool.Parse(line.Split("|")[2]);
                Book book = new Book(title, author) // bypass the constructor :)
                {
                    IsAvailable = isAvailable
                };
                books.Add(book);
            }
        }
    }

    public int GetUserInput()
    {
        int parsedUserChoice;
        string userChoice = Console.ReadLine();
        int.TryParse(userChoice, out parsedUserChoice);
        return (parsedUserChoice);
    }
}


class Program
{
    static void Main(string[] args)
    {
        var library = new Library();
        library.LoadLibraryState();
        
        bool continueProgram = true;
        while (continueProgram)
        {
            Console.WriteLine("\nWelcome to the Library Management System!");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View Available Books");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. Search Books");
            Console.WriteLine("6. Sort Books");
            Console.WriteLine("7. Exit");
            Console.Write("Please enter your choice: ");
            switch (library.GetUserInput())
            {
                case 1:
                    Console.WriteLine("Enter title of the book: ");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter author of the book: ");
                    string author = Console.ReadLine();
                    library.AddBook(title,author);
                    Console.WriteLine($"Book {title} written by {author} was added to the library.");
                    break;
                    
                case 2:
                    library.ViewAvailableBooks();
                    break;
                case 3:
                    library.BorrowBook();
                    break;
                case 4:
                    library.ReturnBook();
                    break;
                
                case 5:
                    Console.WriteLine("Search by title<T> or author <A>: ");
                    string userInput = Console.ReadLine();
                    library.SearchBooks(userInput);
                    break;
                case 6:
                    library.SortBooks();
                    break;
                case 7:
                {
                    library.SaveLibraryState();
                }
                    continueProgram = false;
                    break;
            }
            
        }
    }
}