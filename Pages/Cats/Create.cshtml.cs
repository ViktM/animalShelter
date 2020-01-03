using System.IO;
using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace animalShelter.Pages.Cats
{
    public class CreateModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public CreateModel(AnimalShelterContext context)
        {
            _context = context;
        }

        [BindProperty] public Cat Cat { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCat = new Cat();

            if (Cat.MainImage != null)
            {
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/Uploads",
                    Cat.MainImage.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Cat.MainImage.CopyToAsync(stream);
                    emptyCat.MainImagePath = Cat.MainImage.FileName;
                }
            }

            if (await TryUpdateModelAsync(emptyCat, "cat",
                d => d.Name, d => d.Dob, d => d.Breed, d => d.Sex,
                d => d.Summary))

                if (!ModelState.IsValid)
                    return Page();

            _context.Cats.Add(emptyCat);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Administration/Index");
        }
    }
}