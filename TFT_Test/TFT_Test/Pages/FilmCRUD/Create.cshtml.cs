using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFT_Test.Data;
using TFT_Test.Models;

namespace TFT_Test.Pages.FilmCRUD
{
    public class CreateModel : PageModel
    {
        private readonly TFT_Test.Data.FilmCRUDContext _context;

        public CreateModel(TFT_Test.Data.FilmCRUDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Film Film { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Film == null || Film == null)
            {
                return Page();
            }

            _context.Film.Add(Film);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
