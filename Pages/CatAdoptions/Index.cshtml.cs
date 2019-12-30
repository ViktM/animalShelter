using System.Collections.Generic;
using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace animalShelter.Pages.CatAdoptions
{
    public class IndexModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public IndexModel(AnimalShelterContext context)
        {
            _context = context;
        }

        public IList<CatAdoption> CatAdoption { get; set; }

        public async Task OnGetAsync()
        {
            CatAdoption = await _context.CatAdoptions
                .Include(d => d.Cat)
                .Include(d => d.User).ToListAsync();
        }
    }
}