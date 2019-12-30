using System;
using System.Linq;
using System.Threading.Tasks;
using animalShelter.Data;
using animalShelter.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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