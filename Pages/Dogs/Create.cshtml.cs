using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using animalShelter.Data;
using animalShelter.Models;

namespace animalShelter.Pages.Dogs
{
    public class CreateModel : PageModel
    {
        private readonly animalShelter.Data.AnimalShelterContext _context;

        public CreateModel(animalShelter.Data.AnimalShelterContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dog Dog { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dogs.Add(Dog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
