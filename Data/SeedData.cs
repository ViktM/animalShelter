using System;
using System.Linq;
using animalShelter.Models;

namespace animalShelter.Data
{
    public class SeedData
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
                    Summary = "A cute and fluffy dog", ImageUrl = "www.gizmo.com/gizmo.jpg"
                },
                new Dog
                {
                    Name = "Dexter", Dob = DateTime.Parse("2016-02-14"), Breed = "Chow Chow", Sex = "m",
                    Summary = "Even fluffier!", ImageUrl = "www.dexter.com/dexter.jpg"
                }
            };
            foreach (Dog dog in dogs)
            {
                context.Dogs.Add(dog);
            }

            context.SaveChanges();
            
            if (context.Cats.Any())
            {
                return; 
            }

            var cats = new Cat[]
            {
                new Cat
                {
                    Name = "Peanut", Dob = DateTime.Parse("2012-12-25"), Breed = "Mixed", Sex = "f",
                    Summary = "A cute and fluffy cat", ImageUrl = "www.gizmo.com/gizmo.jpg"
                },
                new Cat
                {
                    Name = "Peacan", Dob = DateTime.Parse("2016-02-14"), Breed = "Bengal", Sex = "f",
                    Summary = "Even fluffier cat!", ImageUrl = "www.dexter.com/dexter.jpg"
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
            foreach (User user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();

            var catAdoptions = new CatAdoption[]
            {
                new CatAdoption {CatID = cats.Single(i => i.CatID == 1).CatID , 
                                 UserID = users.Single(i => i.Id == 1).Id, 
                                 AdoptionDate = DateTime.Parse("2019-12-14")}
            };
            foreach (CatAdoption catAdoption in catAdoptions)
            {
                context.CatAdoptions.Add(catAdoption);
            }

            context.SaveChanges();
            
            var dogAdoptions = new DogAdoption[]
            {
                new DogAdoption {DogID = dogs.Single(i => i.DogID == 1).DogID, 
                                 UserID = users.Single(i => i.Id == 2).Id, 
                                 AdoptionDate = DateTime.Parse("2019-12-14")}
            };
            foreach (DogAdoption dogAdoption in dogAdoptions)
            {
                context.DogAdoptions.Add(dogAdoption);
            }

            context.SaveChanges();
        }
    }
}