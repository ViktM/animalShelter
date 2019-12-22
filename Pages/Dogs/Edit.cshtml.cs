using System.Linq;
using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace animalShelter.Pages.Dogs
{
    public class EditModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public EditModel(AnimalShelterContext context)
        {
            _context = context;
        }

        [BindProperty] public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog = await _context.Dogs.FirstOrDefaultAsync(m => m.DogID == id);

            if (Dog == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var dogToUpdate = await _context.Dogs.FindAsync(id);

            if (dogToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Dog>(
                dogToUpdate,
                "dog",
                d => d.Name, d => d.Breed, d => d.Sex,
                d => d.Summary, d => d.DogAdoptions))

            {
                await _context.SaveChangesAsync();
                return RedirectToPage("../Administration/Index");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(Dog.DogID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Administration/Index");
        }

        private bool DogExists(int id)
        {
            return _context.Dogs.Any(e => e.DogID == id);
        }
    }
}