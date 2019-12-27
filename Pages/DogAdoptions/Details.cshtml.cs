using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using animalShelter.Data;
using animalShelter.Models;

namespace animalShelter.Pages.DogAdoptions
{
    public class DetailsModel : PageModel
    {
        private readonly animalShelter.Data.AnimalShelterContext _context;

        public DetailsModel(animalShelter.Data.AnimalShelterContext context)
        {
            _context = context;
        }

        public DogAdoption DogAdoption { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DogAdoption = await _context.DogAdoptions
                .Include(d => d.Dog)
                .Include(d => d.User).FirstOrDefaultAsync(m => m.DogAdoptionID == id);

            if (DogAdoption == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}