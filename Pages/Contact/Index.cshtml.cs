using animalShelter.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace animalShelter.Pages.Account
{
    public class ContactUs : PageModel
    {
        private readonly AnimalShelterContext _context;

        public ContactUs(AnimalShelterContext context)
        {
            _context = context;
        }
    }
}