using System.Collections.Generic;
using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace animalShelter.Pages.DogAdoptions
{
    public class IndexModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public IndexModel(AnimalShelterContext context)
        {
            _context = context;
        }

        public IList<DogAdoption> DogAdoption { get; set; }

        public async Task OnGetAsync()
        {
            DogAdoption = await _context.DogAdoptions
                .Include(d => d.Dog)
                .Include(d => d.User).ToListAsync();
        }
    }
}