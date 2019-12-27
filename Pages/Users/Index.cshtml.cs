using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using animalShelter.Data;
using animalShelter.Models;

namespace animalShelter.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly animalShelter.Data.AnimalShelterContext _context;

        public IndexModel(animalShelter.Data.AnimalShelterContext context)
        {
            _context = context;
        }

        public new IList<User>  User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}