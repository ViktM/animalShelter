using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace animalShelter.Pages.Cats
{
    public class DeleteModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public DeleteModel(AnimalShelterContext context)
        {
            _context = context;
        }

        [BindProperty] public Cat Cat { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cat = await _context.Cats.FindAsync(id);

            if (Cat != null)
            {
                _context.Cats.Remove(Cat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}