using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace animalShelter.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public IndexModel(AnimalShelterContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<User> Users { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var usersIq = from s in _context.Users
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