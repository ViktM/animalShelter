using System;
using System.Linq;
using animalShelter.Models;

namespace animalShelter.Data

{
    public static class SeedData
    {
        public static void Initialise(AnimalShelterContext context)
        {
            context.Database.EnsureCreated();

            if (context.Dogs.Any()) return;

            var dogs = new[]
            {
                new Dog
                {
                    Name = "Gizmo", Dob = DateTime.Parse("2012-12-25"), Breed = "Mixed", Sex = "M",
                    Summary = "A cute and fluffy dog"
                },
                new Dog
                {
                    Name = "Dexter", Dob = DateTime.Parse("2016-02-14"), Breed = "Chow Chow", Sex = "M",
                    Summary = "Even fluffier!"
                }
            };
            foreach (var d in dogs) context.Dogs.Add(d);

            context.SaveChanges();

            var cats = new[]
            {
                new Cat
                {
                    Name = "Peanut", Dob = DateTime.Parse("2012-12-25"), Breed = "Mixed", Sex = "F",
                    Summary = "A cute and fluffy cat"
                },
                new Cat
                {
                    Name = "Pecan", Dob = DateTime.Parse("2016-02-14"), Breed = "Bengal", Sex = "F",
                    Summary = "Even fluffier cat!"
                }
            };
            foreach (var cat in cats) context.Cats.Add(cat);

            context.SaveChanges();

            var users = new[]
            {
                new User
                {
                    FirstName = "Vik", LastName = "Mezei", AddressLine1 = "Syon Lane Castle",
                    Postcode = "TW97QD", Email = "ilovemario@gmail.com", Telephone = "1234567890", IsAdmin = true
                },

                new User
                {
                    FirstName = "Claire", LastName = "Cunliffe", AddressLine1 = "Tooting Palace",
                    Postcode = "SW1A2BC",
                    Email = "yogaiscool@gmail.com", Telephone = "2345678901", IsAdmin = true
                }
            };
            foreach (var u in users) context.Users.Add(u);

            context.SaveChanges();

            var catAdoptions = new[]
            {
                new CatAdoption
                {
                    CatID = cats.Single(i => i.CatID == 1).CatID,
                    UserID = users.Single(i => i.ID == 1).ID,
                    AdoptionDate = DateTime.Parse("2019-12-14")
                }
            };
            foreach (var catAdoption in catAdoptions) context.CatAdoptions.Add(catAdoption);

            context.SaveChanges();

            var dogAdoptions = new[]
            {
                new DogAdoption
                {
                    DogID = dogs.Single(i => i.DogID == 1).DogID,
                    UserID = users.Single(i => i.ID == 1).ID,
                    AdoptionDate = DateTime.Parse("2019-12-14")
                }
            };
            foreach (var dogAdoption in dogAdoptions) context.DogAdoptions.Add(dogAdoption);

            context.SaveChanges();
        }
    }
}