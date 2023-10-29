using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookManager.Models
{
  public class BookManagerContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Book> Books { get; set; }
    public BookManagerContext (DbContextOptions options) : base(options) { }
  }
}