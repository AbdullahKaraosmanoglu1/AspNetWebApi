using BookApplication.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.Data.BookApplicationDbContext
{
    public class BookAppDataBaseContext : DbContext
    {
        public BookAppDataBaseContext(DbContextOptions options) : base(options) { }

        DbSet<Book> Books { get; set; }
        DbSet<BookCategory> BookCategories { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserBook> UserBooks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
