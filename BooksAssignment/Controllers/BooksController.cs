using BooksAssignment.BooksData;
using BooksAssignment.Contracts;
using BooksAssignment.DataModels;
using BooksAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BooksAssignment.Controllers
{

    [ApiController]
    public class BooksController : ControllerBase
    {
        //dependency Injection 
        private IBookData _bookData;
        private readonly ILogger<BooksController> logger;
        public BooksController(IBookData bookData, ILogger<BooksController> logger)
        {
            _bookData = bookData;
            this.logger = logger;
        }

        [HttpGet(ApiRoutes.Books.GetBooks)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(BooksModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetBooks()
        {
            try
            {
                logger.LogInformation("Getting all the books ");
                List<BooksModel> books = _bookData.GetBooks();
                if (books.Count > 0)
                {
                    return Ok(books);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                logger.LogError("exception" + ex.Message);
                return BadRequest();
            }
            finally
            {
                logger.LogInformation("End of Get all Books Method ");
            }

        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BooksModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpGet(ApiRoutes.Books.GetBooksById)]
        public IActionResult GetBooksById(int BookId)
        {
            try
            {
                if (BookId <= 0)
                {
                    logger.LogError("Book Id provided is 0 or lessthan 0 ");
                    return BadRequest();
                }
                else
                {
                    BooksModel book = _bookData.GetBooksById(BookId);
                    if (book != null)
                    {
                        logger.LogInformation("Fetching Books based on Book Id ");
                        return Ok(book);
                    }
                    logger.LogWarning("Provided Book Id is not found in database");
                    return NotFound($"Book with Id : {BookId} is not found");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("exception" + ex.Message);
                return BadRequest();
            }
            finally
            {
                logger.LogInformation("End of Get Books By Book id Block ");
            }

        }
        [HttpPost(ApiRoutes.Books.AddBook)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddBook(BookModel books)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    logger.LogInformation("Passing Book information to Add new Book ");
                    BookModel book = new BookModel();
                    book.BookName = books.BookName;
                    book.AuthorName = books.AuthorName;
                    book.Description = books.Description;
                    BooksModel addedBook = _bookData.AddBooks(book);
                    return Created("~/api/Books/" + addedBook.BookId, addedBook);
                }
                logger.LogInformation("Model state is not Valid ");
                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError("exception" + ex.Message);
                return BadRequest();
            }
            finally
            {
                logger.LogInformation("End of Add Book Block ");
            }

        }
    }
}
