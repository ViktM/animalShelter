using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using animalShelter.Data;
using animalShelter.Models;

namespace animalShelter.Pages.Cats
{
    public class IndexModel : PageModel
    {
        private readonly animalShelter.Data.AnimalShelterContext _context;

        public IndexModel(animalShelter.Data.AnimalShelterContext context)
        {
            _context = context;
        }

        public IList<Cat> Cat { get;set; }

        public async Task OnGetAsync()
        {
            Cat = await _context.Cats.ToListAsync();
        }
    }
}
