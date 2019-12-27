using System;
using System.ComponentModel.DataAnnotations;

namespace animalShelter.Models
{
    public class DogAdoption
    {
        public int DogAdoptionID { get; set; }
        
        [Required] [Display(Name = "Dog")] 
        public int DogID { get; set; }
        
        [Required] [Display(Name = "User")] 
        public int UserID { get; set; }
        public Dog Dog { get; set; }
        public User User { get; set; }
        
        [DataType(DataType.Date)]
        [Required] [Display(Name = "Adoption Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AdoptionDate { get; set; }
    }
}