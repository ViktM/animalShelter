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

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Dog> Dogs { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Dog> dogsIq = from s in _context.Dogs
                select s;

            switch (sortOrder)
            {
                case "name_desc":
                    dogsIq = dogsIq.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    dogsIq = dogsIq.OrderBy(s => s.Dob);
                    break;
                case "date_desc":
                    dogsIq = dogsIq.OrderByDescending(s => s.Dob);
                    break;
                default:
                    dogsIq = dogsIq.OrderBy(s => s.Name);
                    break;
            }

            Dogs = await dogsIq.AsNoTracking().ToListAsync();
        }
    }
}