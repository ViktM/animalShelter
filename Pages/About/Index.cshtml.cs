using animalShelter.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace animalShelter.Pages.About
{
    public class IndexModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public IndexModel(AnimalShelterContext context)
        {
            _context = context;
        }
    }
}