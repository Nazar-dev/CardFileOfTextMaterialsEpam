using CardFileOfTextMaterialsEpam.DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace CardFileOfTextMaterialsEpam.DAL {
	public class CardFileDbContext: DbContext {
		public CardFileDbContext(DbContextOptions<CardFileDbContext> options) : base(options)
		{
		}
		public DbSet<Book> Books { get; set; }
		public DbSet<Card> Cards { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}