namespace BooksAssignment.Contracts
{
    public class ApiRoutes
    {
        public static class Books
        {
            public const string GetBooks = "api/Books";
            public const string GetBooksById = "api/Books/{BookId}";
            public const string AddBook = "api/Books/book";
            public const string UpdateBook = "api/Books/book";
        }
    }
}
