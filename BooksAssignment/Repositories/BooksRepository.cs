using AutoMapper;
using BooksAssignment.BooksData;
using BooksAssignment.DataModels;
using BooksAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksAssignment.Repositories
{
    public class BooksRepository : IBookData
    {
        private BooksContext bookContext;
        private readonly IMapper _mapper;

        public BooksRepository()
        {
        }

        public BooksRepository(BooksContext booksContext,IMapper mapper)
        {
            bookContext = booksContext;
           _mapper = mapper;
        }


        public BooksModel AddBooks(BookModel books)
        {
            bookContext.Books.Add(books);
            bookContext.SaveChanges();
            return _mapper.Map<BooksModel>(books); ;
        }

        public List<BooksModel> GetBooks()
        {
            List<BookModel> books = bookContext.Books.ToList();
            return _mapper.Map<List<BooksModel>>(books);
            
        }

        public BooksModel GetBooksById(int BookId)
        {
            BookModel books = bookContext.Books.Find(BookId);
            return _mapper.Map<BooksModel>(books);
        }
      
    }
}
