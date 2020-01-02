using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace animalShelter.Pages.DogAdoptions
{
    public class CreateModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public CreateModel(AnimalShelterContext context)
        {
            _context = context;
        }

        [BindProperty] public DogAdoption DogAdoption { get; set; }

        public IActionResult OnGet()
        {
            ViewData["DogID"] = new SelectList(_context.Dogs, "DogID", "Name");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.DogAdoptions.Add(DogAdoption);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}