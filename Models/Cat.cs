using System;
using System.Collections.Generic;

namespace animalShelter.Models
{
    public class Cat
    {
        public int CatID { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<CatAdoption> CatAdoptions { get; set; }
    }
}