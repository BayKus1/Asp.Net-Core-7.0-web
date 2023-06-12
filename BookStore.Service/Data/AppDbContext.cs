using BookStore.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Service.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            

        }

        public DbSet<Category> Categories { get; set; }
		public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
