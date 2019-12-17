using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using animalShelter.Data;
using animalShelter.Models;

namespace animalShelter.Pages.Dogs
{
    public class DeleteModel : PageModel
    {
        private readonly animalShelter.Data.AnimalShelterContext _context;

        public DeleteModel(animalShelter.Data.AnimalShelterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog = await _context.Dogs.FirstOrDefaultAsync(m => m.DogID == id);

            if (Dog == null)
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

            Dog = await _context.Dogs.FindAsync(id);

            if (Dog != null)
            {
                _context.Dogs.Remove(Dog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
