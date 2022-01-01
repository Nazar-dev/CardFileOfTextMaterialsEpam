using CardFileOfTextMaterialsEpam.DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace CardFileOfTextMaterialsEpam.DAL {
	public class CardFileDbContext: DbContext {
		public CardFileDbContext(DbContextOptions<CardFileDbContext> options) : base(options)
        {
        }
		public DbSet<Book> EntityBooks { get; set; }
        public DbSet<Card> EntityCards { get; set; }
		public DbSet<User> EntityUsers { get; set; }
		public DbSet<Category> EntityCategories { get; set; }
	}
}