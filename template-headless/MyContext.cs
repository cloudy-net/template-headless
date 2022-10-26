using Microsoft.EntityFrameworkCore;

namespace template_headless
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}