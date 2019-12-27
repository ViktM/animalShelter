using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace animalShelter.Models
{
    public class Cat
    {
        public int CatID { get; set; }

        [Required] 
        [StringLength(20, MinimumLength=2, ErrorMessage = "Name must be between 2 and 20 characters")]
        [Display(Name = "Name")] 
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Dob { get; set; }

        [Required] [Display(Name = "Breed")] 
        public string Breed { get; set; }

        [Required] [Display(Name = "Sex")] 
        public string Sex { get; set; }

        [Display(Name = "Summary")] 
        public string Summary { get; set; }

        [Display(Name = "Cat Image")] 
        public string MainImagePath { get; set; }
        
        [NotMapped]
        [Display(Name = "Main Image")] 
        public IFormFile MainImage { get; set; }

        public ICollection<CatAdoption> CatAdoptions { get; set; }
    }
}