using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CardFileOfTextMaterialsEpam.DAL
{
    public class CardFileDbContext : IdentityDbContext<User, Role, int>
    {
        public CardFileDbContext(DbContextOptions<CardFileDbContext> options) : base(options)
        {
        }
        public DbSet<Book> EBooks { get; set; }
        public DbSet<Card> ECards { get; set; }
        public DbSet<Person> EPersons { get; set; }
        public DbSet<Category> ECategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Role>()
                .HasData(
                    new Role()
                    {
                        Id = 1,
                        Name = "User",
                        NormalizedName = "USER"
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    }
                );
        }
    }
}