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
    public class DeleteModel : PageModel
    {
        private readonly animalShelter.Data.AnimalShelterContext _context;

        public DeleteModel(animalShelter.Data.AnimalShelterContext context)
        {
            _context = context;
        }

        [BindProperty] public DogAdoption DogAdoption { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DogAdoption = await _context.DogAdoptions.FindAsync(id);

            if (DogAdoption != null)
            {
                _context.DogAdoptions.Remove(DogAdoption);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}