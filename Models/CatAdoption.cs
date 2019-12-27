using System;
using System.ComponentModel.DataAnnotations;

namespace animalShelter.Models
{
    public class CatAdoption
    {
        public int CatAdoptionID { get; set; }

        [Required] [Display(Name = "Cat")] public int CatID { get; set; }

        [Required] [Display(Name = "User")] public int UserID { get; set; }
        public Cat Cat { get; set; }
        public User User { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Adoption Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AdoptionDate { get; set; }
    }
}