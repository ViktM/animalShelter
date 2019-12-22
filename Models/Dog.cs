using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace animalShelter.Models
{
    public class Dog
    {
        public int DogID { get; set; }

        [Required] [Display(Name = "Name")] 
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Dob { get; set; }

        [Required] [Display(Name = "Breed")] 
        public string Breed { get; set; }

        [Required] [Display(Name = "Sex")] 
        public string Sex { get; set; }

        [Display(Name = "Summary")] 
        public string Summary { get; set; }

        [Display(Name = "DogImage")] 
        public string MainImagePath { get; set; }
        
        [NotMapped]
        public IFormFile MainImage { get; set; }
        public ICollection<DogAdoption> DogAdoptions { get; set; }
    }
}