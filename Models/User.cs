using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace animalShelter.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20, MinimumLength=2,ErrorMessage = "First Name must be between 2 and 20 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength=2, ErrorMessage = "Last Name must be between 2 and 20 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required] [Display(Name = "User")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        [Required] [Display(Name = "Address")] 
        public string AddressLine1 { get; set; }

        [Required]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [Required] 
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        [Display(Name = "E-mail Address")] 
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string Telephone { get; set; }

        
        [Required]
        [Display(Name = "Administrator")]
        public bool IsAdmin { get; set; }

        public ICollection<DogAdoption> DogAdoptions { get; set; }
        public ICollection<CatAdoption> CatAdoptions { get; set; }
    }
}