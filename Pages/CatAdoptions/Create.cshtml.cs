using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace animalShelter.Pages.CatAdoptions
{
    public class CreateModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public CreateModel(AnimalShelterContext context)
        {
            _context = context;
        }

        [BindProperty] public CatAdoption CatAdoption { get; set; }

        public IActionResult OnGet()
        {
            ViewData["CatID"] = new SelectList(_context.Cats, "CatID", "Name");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "FullName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.CatAdoptions.Add(CatAdoption);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}