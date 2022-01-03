using CardFileOfTextMaterialsEpam.BL.Auth;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CardFileOfTextMaterialsEpam.DAL
{
    public class CardFileDbContext : IdentityDbContext<User, Role, int>
    {
        public CardFileDbContext(DbContextOptions<CardFileDbContext> options) : base(options)
        {
        }

        public DbSet<Book> EntityBooks { get; set; }
        public DbSet<Card> EntityCards { get; set; }
        public DbSet<MyPerson> EntityUsers { get; set; }
        public DbSet<Category> EntityCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Role>()
                .HasData(
                    new Role()
                    {
                        Id = 1,
                        Name = "testUser",
                        NormalizedName = "USER"
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "testAdmin",
                        NormalizedName = "ADMIN"
                    }
                );
        }
    }
}