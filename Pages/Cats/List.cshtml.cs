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
    public class ListModel : PageModel
    {
        private readonly animalShelter.Data.AnimalShelterContext _context;

        public ListModel(animalShelter.Data.AnimalShelterContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Cat> Cats { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Cat> catsIq = from s in _context.Cats
                select s;

            switch (sortOrder)
            {
                case "name_desc":
                    catsIq = catsIq.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    catsIq = catsIq.OrderBy(s => s.Dob);
                    break;
                case "date_desc":
                    catsIq = catsIq.OrderByDescending(s => s.Dob);
                    break;
                default:
                    catsIq = catsIq.OrderBy(s => s.Name);
                    break;
            }

            Cats = await catsIq.AsNoTracking().ToListAsync();
        }
    }
}