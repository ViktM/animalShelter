using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using animalShelter.Data;
using animalShelter.Models;

namespace animalShelter.Pages.CatAdoptions
{
    public class IndexModel : PageModel
    {
        private readonly animalShelter.Data.AnimalShelterContext _context;

        public IndexModel(animalShelter.Data.AnimalShelterContext context)
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