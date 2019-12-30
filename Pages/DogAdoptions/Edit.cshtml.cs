using System.Linq;
using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace animalShelter.Pages.DogAdoptions
{
    public class EditModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public EditModel(AnimalShelterContext context)
        {
            _context = context;
        }

        [BindProperty] public DogAdoption DogAdoption { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            DogAdoption = await _context.DogAdoptions
                .Include(d => d.Dog)
                .Include(d => d.User).FirstOrDefaultAsync(m => m.DogAdoptionID == id);

            if (DogAdoption == null) return NotFound();

            ViewData["DogID"] = new SelectList(_context.Dogs, "DogID", "Name");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(DogAdoption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogAdoptionExists(DogAdoption.DogAdoptionID))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool DogAdoptionExists(int id)
        {
            return _context.DogAdoptions.Any(e => e.DogAdoptionID == id);
        }
    }
}