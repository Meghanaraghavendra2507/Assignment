using BooksAssignment;
using BooksAssignment.BooksData;
using BooksAssignment.Contracts;
using BooksAssignment.Controllers;
using BooksAssignment.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace BookAssignmentTest
{
    public class IntegrationTesting
    {
        protected readonly HttpClient _httpClient;
        protected IntegrationTesting()
        {
           
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder (builder=> 
                {
                    builder.ConfigureServices(services =>
                    {
                        services.AddDbContextPool<BooksContext>(options =>
                        options.UseSqlServer("server=LAPTOP-IHCLV8PP;database=Books;Trusted_Connection=true"));
                    });
                });
            _httpClient = appFactory.CreateClient();

           
        }

        protected Task<HttpResponseMessage> CreatePostAsync(BookModel books)
        {
            var response = _httpClient.PostAsJsonAsync(ApiRoutes.Books.AddBook, books);
            return response;
        }
        

    }
}
