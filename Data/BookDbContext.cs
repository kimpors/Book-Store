using Microsoft.EntityFrameworkCore;
using Book_Store.Models;

namespace Book_Store.Data;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options)
    : base(options) { }
    public DbSet<Book> Books { get; set; }
}