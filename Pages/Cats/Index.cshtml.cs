using System;
using System.Linq;
using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace animalShelter.Pages.Cats
{
    public class IndexModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public IndexModel(AnimalShelterContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Cat> Cats { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Cat> catsIq = from s in _context.Cats
                select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                catsIq = catsIq.Where(d => d.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    catsIq = catsIq.OrderByDescending(d => d.Name);
                    break;
                case "Date":
                    catsIq = catsIq.OrderBy(d => d.Dob);
                    break;
                case "date_desc":
                    catsIq = catsIq.OrderByDescending(d => d.Dob);
                    break;
                default:
                    catsIq = catsIq.OrderBy(d => d.Name);
                    break;
            }

            int pageSize = 6;
            Cats = await PaginatedList<Cat>.CreateAsync(
                catsIq.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}