using BooksAssignment.DataModels;
using BooksAssignment.Models;
using System.Collections.Generic;

namespace BooksAssignment.BooksData
{
    public interface IBookData
    {
        List<BooksModel> GetBooks();

        BooksModel GetBooksById(int BookId);

        BooksModel AddBooks(BookModel books);


    }
}
