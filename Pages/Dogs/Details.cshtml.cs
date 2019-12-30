using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace animalShelter.Pages.Dogs
{
    public class DetailsModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public DetailsModel(AnimalShelterContext context)
        {
            _context = context;
        }

        public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Dog = await _context.Dogs
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DogID == id);

            if (Dog == null) return NotFound();

            return Page();
        }
    }
}