using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using animalShelter.Data;
using animalShelter.Models;

namespace animalShelter.Pages.Cats
{
    public class DetailsModel : PageModel
    {
        private readonly animalShelter.Data.AnimalShelterContext _context;

        public DetailsModel(animalShelter.Data.AnimalShelterContext context)
        {
            _context = context;
        }

        public Cat Cat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cat = await _context.Cats.FirstOrDefaultAsync(m => m.CatID == id);

            if (Cat == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
