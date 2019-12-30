using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace animalShelter.Pages
{
    public class Payment : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}