using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using animalShelter.Data;
using animalShelter.Models;

namespace animalShelter.Pages.CatAdoptions
{
    public class EditModel : PageModel
    {
        private readonly animalShelter.Data.AnimalShelterContext _context;

        public EditModel(animalShelter.Data.AnimalShelterContext context)
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
           ViewData["CatID"] = new SelectList(_context.Cats, "CatID", "Name");
           ViewData["UserID"] = new SelectList(_context.Users, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CatAdoption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatAdoptionExists(CatAdoption.CatAdoptionID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CatAdoptionExists(int id)
        {
            return _context.CatAdoptions.Any(e => e.CatAdoptionID == id);
        }
    }
}
