using Microsoft.EntityFrameworkCore;

namespace BooksAssignment.Models
{
    public class BooksContext:DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options):base(options)
        {

        }
        public DbSet<BookModel> Books { get; set; }
    }
}
