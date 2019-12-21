using animalShelter.Models;
using Microsoft.EntityFrameworkCore;

namespace animalShelter.Data
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<CatAdoption> CatAdoptions { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adoption>().ToTable("Adoption");
            modelBuilder.Entity<Dog>().ToTable("Dog");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Cat>().ToTable("Cat");
            modelBuilder.Entity<CatAdoption>().ToTable("CatAdoption");
        }
    }
}