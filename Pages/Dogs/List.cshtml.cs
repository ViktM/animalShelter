using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using animalShelter.Data;
using animalShelter.Models;

namespace animalShelter.Pages.Dogs
{
    public class ListModel : PageModel
    {
        private readonly animalShelter.Data.AnimalShelterContext _context;

        public ListModel(animalShelter.Data.AnimalShelterContext context)
        {
            _context = context;
        }

        public IList<Dog>  Dog { get;set; }

        public async Task OnGetAsync()
        {
            Dog = await _context.Dogs.ToListAsync();
        }
    }
}