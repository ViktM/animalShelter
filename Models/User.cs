using System.Collections.Generic;

namespace animalShelter.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool IsAdmin { get; set; }
        
        public ICollection<CatAdoption> CatAdoptions { get; set; }
        public ICollection<DogAdoption> DogAdoptions { get; set; }
        
    }
}