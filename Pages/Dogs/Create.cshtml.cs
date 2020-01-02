using System.IO;
using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace animalShelter.Pages.Dogs
{
    public class CreateModel : PageModel
    {
        private readonly AnimalShelterContext _context;

        public CreateModel(AnimalShelterContext context)
        {
            _context = context;
        }

        [BindProperty] public Dog Dog { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyDog = new Dog();

            if (Dog.MainImage != null)
            {
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/uploads",
                    Dog.MainImage.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Dog.MainImage.CopyToAsync(stream);
                    emptyDog.MainImagePath = Dog.MainImage.FileName;
                }
            }

            if (await TryUpdateModelAsync(emptyDog, "dog",
                d => d.Name, d => d.Breed, d => d.Sex,

                d => d.Summary))

                if (!ModelState.IsValid)
                    return Page();

            _context.Dogs.Add(emptyDog);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Administration/Index");
        }
    }
}