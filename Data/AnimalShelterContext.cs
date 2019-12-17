using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using animalShelter.Models;

namespace animalShelter.Data
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext (DbContextOptions<AnimalShelterContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }

        public DbSet<Dog> Dogs { get; set; }
        
        public DbSet<CatAdoption> CatAdoptions { get; set; }
        
        public DbSet<DogAdoption> DogAdoptions { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Dog>().ToTable("Dog");
            modelBuilder.Entity<DogAdoption>().ToTable("DogAdoption");
            modelBuilder.Entity<Cat>().ToTable("Cat");
            modelBuilder.Entity<CatAdoption>().ToTable("CatAdoption");
        }
        
    }
}
