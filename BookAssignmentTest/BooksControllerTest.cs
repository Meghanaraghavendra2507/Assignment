using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksAssignment;
using BooksAssignment.Controllers;
using Xunit;
using BooksAssignment.Contracts;
using System.Net;
using FluentAssertions;
using System.Net.Http.Json;
using BooksAssignment.Models;
using Newtonsoft.Json;
using System.Net.Http;
using static BooksAssignment.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Hosting.Server;

namespace BookAssignmentTest
{
    public class BooksControllerTest:IntegrationTesting
    {

        // GetBooks Should Return Ok Response when Data Found
        [Fact]
        public void  GetBooks()
        {
            var response = _httpClient.GetAsync(ApiRoutes.Books.GetBooks);
             response.Result.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Result.Should().NotBeNull();
        }
        // // GetBooks Should return NotFound Response when Data Not Found
        [Fact]
        public void GetBooks_NotFound()
        {
            var response = _httpClient.GetAsync(ApiRoutes.Books.GetBooks);
            response.Result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            response.Result.Should().BeNull();
        }
        // GetBooks By BookId Should Return Ok Response when Data Found
        [Fact]
        
        public void GetBooksByBookId_Ok()
        {

            var response = _httpClient.GetAsync("https://localhost:44375/Api/Books/1");

            response.Result.StatusCode.Should().Be(HttpStatusCode.OK);
           
        }
        // GetBooks By BookId Should Return Not Found Response when Data Not Found
        [Fact]
      
        public void GetBooksByBookId_DataNotFound()
        {
            var response = _httpClient.GetAsync("https://localhost:44375/Api/Books/51");
            response.Result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        // GetBooks By BookId Should Return Bad Request Response when invalid input value entered
        [Fact]
        public void GetBooksByBookId_BadRequest()
        {
            var response = _httpClient.GetAsync("https://localhost:44375/Api/Books/0");
            response.Result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        // GetBooks By BookId Should Return Bad Request Response when invalid input value entered

        [Fact]
        public void GetBooksByBookId_BadRequest_neg()
        {
            var response = _httpClient.GetAsync("https://localhost:44375/Api/Books/-1");
            response.Result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        //Create Books should return Created Response when new Book created
        [Fact]
        public void PostBooks()
        {
            BooksAssignment.Models.BookModel book = new BooksAssignment.Models.BookModel();
            book.BookName = "Book2";
            book.AuthorName = "Author2";
            var response = CreatePostAsync(book);
            response.Result.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        //Create Books should return Bad Request Response when invalid inputs entered

        [Fact]
        public void PostBooks_BadRequest()
        {
            BooksAssignment.Models.BookModel book = new BooksAssignment.Models.BookModel();
            book.BookName = "";
            book.AuthorName = "";
            var response = CreatePostAsync(book);
            response.Result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

    }
}
