using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace animalShelter.Models
{
    public class DogAdoption
    {
        public int DogAdoptionID { get; set; }
        public int DogID { get; set; }
        public int UserID { get; set; }
        
        public DateTime AdoptionDate { get; set; }
        
        public Dog Dog { get; set; }
        public User User { get; set; }
    }
}