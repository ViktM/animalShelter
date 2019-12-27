using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using animalShelter.Data;
using animalShelter.Models;

namespace animalShelter.Pages.CatAdoptions
{
    public class DeleteModel : PageModel
    {
        private readonly animalShelter.Data.AnimalShelterContext _context;

        public DeleteModel(animalShelter.Data.AnimalShelterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatAdoption CatAdoption { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CatAdoption = await _context.CatAdoptions
                .Include(d => d.Cat)
                .Include(d => d.User).FirstOrDefaultAsync(m => m.CatAdoptionID == id);

            if (CatAdoption == null)
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

            CatAdoption = await _context.CatAdoptions.FindAsync(id);

            if (CatAdoption != null)
            {
                _context.CatAdoptions.Remove(CatAdoption);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
