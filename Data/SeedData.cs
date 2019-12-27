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

            if (context.Dogs.Any())
            {
                return;
            }

            var dogs = new Dog[]
            {
                new Dog
                {
                    Name = "Gizmo", Dob = DateTime.Parse("2012-12-25"), Breed = "Mixed", Sex = "m",
                    Summary = "A cute and fluffy dog"
                },
                new Dog
                {
                    Name = "Dexter", Dob = DateTime.Parse("2016-02-14"), Breed = "Chow Chow", Sex = "m",
                    Summary = "Even fluffier!"
                }
            };
            foreach (Dog d in dogs)
            {
                context.Dogs.Add(d);
            }

            context.SaveChanges();

            var cats = new Cat[]
            {
                new Cat
                {
                    Name = "Peanut", Dob = DateTime.Parse("2012-12-25"), Breed = "Mixed", Sex = "f",
                    Summary = "A cute and fluffy cat"
                },
                new Cat
                {
                    Name = "Pecan", Dob = DateTime.Parse("2016-02-14"), Breed = "Bengal", Sex = "f",
                    Summary = "Even fluffier cat!"
                }
            };
            foreach (Cat cat in cats)
            {
                context.Cats.Add(cat);
            }

            context.SaveChanges();

            var users = new User[]
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
            foreach (User u in users)
            {
                context.Users.Add(u);
            }

            context.SaveChanges();

            var catAdoptions = new CatAdoption[]
            {
                new CatAdoption
                {
                    CatID = cats.Single(i => i.CatID == 1).CatID,
                    UserID = users.Single(i => i.ID == 1).ID,
                    AdoptionDate = DateTime.Parse("2019-12-14")
                }
            };
            foreach (CatAdoption catAdoption in catAdoptions)
            {
                context.CatAdoptions.Add(catAdoption);
            }

            context.SaveChanges();

            var dogAdoptions = new DogAdoption[]
            {
                new DogAdoption()
                {
                    DogID = dogs.Single(i => i.DogID == 1).DogID,
                    UserID = users.Single(i => i.ID == 1).ID,
                    AdoptionDate = DateTime.Parse("2019-12-14")
                }
            };
            foreach (DogAdoption dogAdoption in dogAdoptions)
            {
                context.DogAdoptions.Add(dogAdoption);
            }

            context.SaveChanges();
        }
    }
}