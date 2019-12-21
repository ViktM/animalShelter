using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace animalShelter.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required] [Display(Name = "Address")] 
        public string AddressLine1 { get; set; }

        [Required]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [Required] [Display(Name = "Email")] 
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        public string Telephone { get; set; }

        [Required] public bool IsAdmin { get; set; }

        public ICollection<Adoption> Adoptions { get; set; }
        public ICollection<CatAdoption> CatAdoptions { get; set; }
    }
}