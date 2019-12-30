using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace animalShelter.Pages.DogAdoptions
{
    public class DeleteModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public DeleteModel(AnimalShelterContext context)
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

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

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