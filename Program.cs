namespace Solve_task_3
{

    //using System.Security.Cryptography.X509Certificates;

    //{



        class Book
        {
            public Book(string title, string author, string iSBN)
            {
                Title = title;
                Author = author;
                ISBN = iSBN;
                Availability = true;
                Librarys = new List<Library>();
            }

            public string Title { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }
            public bool Availability { get; set; }
            public List<Library> Librarys { get; set; }

        }
        class Library
        {
            public List<Book> books = new List<Book>();

            public void AddBook(Book book)
            {

                books.Add(book);
                Console.WriteLine($"'{book.Title}' Added");
            }

            public Book SearchBook(string Title)
            {
                if (books != null && books.Count > 0)
                {
                    Console.Write("Please Enter A Title  To Search On It: ");
                    string SearchByTitle = Console.ReadLine();
                    string SearchByAuthor = Console.ReadLine();

                    for (int i = 0; i < books.Count; i++)
                    {
                        if (books[i].Title == SearchByTitle || books[i].Author == SearchByAuthor)
                        {
                            books[i].Title = SearchByTitle;
                            books[i].Author = SearchByAuthor;

                            Console.WriteLine($"Book found: {books[i].Title}, {books[i].Author}");
                            return books[i];
                        }
                    }
                    Console.WriteLine("Book not found.");
                    return null;
                }

                else
                {
                    Console.WriteLine("Library is empty. No books to search.");
                    return null;
                }

            }


            public void BorrowBook(string Title)
            {
                Book book = SearchBook(Title);
                if (book != null && book.Availability)
                {
                    book.Availability = false;
                    Console.WriteLine($"You have borrowed the book: {book.Title}");
                }
                else if (book != null)
                {
                    Console.WriteLine($"The book '{book.Title}' is not available.");
                }
            }


            public void ReturnBook(string Title)
            {
                Book book = SearchBook(Title);
                if (book != null && !book.Availability)
                {
                    book.Availability = true;
                    Console.WriteLine($"You have returned the book: {book.Title}");
                }
                else if (book != null)
                {
                    Console.WriteLine($"The book '{book.Title}' was not borrowed.");
                }
            }

        }




        internal class Program
        {
            static void Main(string[] args)
            {

                Library library = new Library();


                // Adding books to the library
                library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
                library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
                library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

                // Searching and borrowing books
                Console.WriteLine("Searching and borrowing books...");
                library.BorrowBook("Gatsby");
                library.BorrowBook("1984");
                library.BorrowBook("Harry Potter"); // This book is not in the library

                // Returning books
                Console.WriteLine("\nReturning books...");
                library.ReturnBook("Gatsby");
                library.ReturnBook("Harry Potter"); // This book is not borrowed

                Console.ReadLine();





            }
        }
    }


