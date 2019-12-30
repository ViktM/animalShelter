using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace animalShelter.Pages.CatAdoptions
{
    public class DeleteModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public DeleteModel(AnimalShelterContext context)
        {
            _context = context;
        }

        [BindProperty] public CatAdoption CatAdoption { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            CatAdoption = await _context.CatAdoptions
                .Include(d => d.Cat)
                .Include(d => d.User).FirstOrDefaultAsync(m => m.CatAdoptionID == id);

            if (CatAdoption == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

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