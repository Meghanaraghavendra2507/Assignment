using AutoMapper;
using BooksAssignment.DataModels;
using BooksAssignment.Models;

namespace BooksAssignment.Helpers
{
    public class BooksAssignmentMapper:Profile
    {
        public BooksAssignmentMapper()
        {
            CreateMap<BookModel,BooksModel>();
        }
    }
}
