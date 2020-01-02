using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace animalShelter.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public DeleteModel(AnimalShelterContext context)
        {
            _context = context;
        }

        [BindProperty] public new User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            User = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);

            if (User == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            User = await _context.Users.FindAsync(id);

            if (User != null)
            {
                _context.Users.Remove(User);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}