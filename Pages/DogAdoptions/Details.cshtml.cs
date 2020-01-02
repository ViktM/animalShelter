using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace animalShelter.Pages.DogAdoptions
{
    public class DetailsModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public DetailsModel(AnimalShelterContext context)
        {
            _context = context;
        }

        public DogAdoption DogAdoption { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            DogAdoption = await _context.DogAdoptions
                .Include(d => d.Dog)
                .Include(d => d.User).FirstOrDefaultAsync(m => m.DogAdoptionID == id);

            if (DogAdoption == null) return NotFound();

            return Page();
        }
    }
}