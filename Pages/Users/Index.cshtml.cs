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

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<User> Users { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            IQueryable<User> usersIq = from s in _context.Users
                select s;

            switch (sortOrder)
            {
                case "name_desc":
                    usersIq = usersIq.OrderByDescending(s => s.LastName);
                    break;
                default:
                    usersIq = usersIq.OrderBy(s => s.LastName);
                    break;
            }

            Users = await usersIq.AsNoTracking().ToListAsync();
        }
    }
}