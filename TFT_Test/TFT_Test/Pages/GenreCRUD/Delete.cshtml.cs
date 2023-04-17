using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TFT_Test.Data;
using TFT_Test.Models;

namespace TFT_Test.Pages.GenreCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly TFT_Test.Data.GenreCRUDContext _context;

        public DeleteModel(TFT_Test.Data.GenreCRUDContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Genre Genre { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Genre == null)
            {
                return NotFound();
            }

            var genre = await _context.Genre.FirstOrDefaultAsync(m => m.GenreId == id);

            if (genre == null)
            {
                return NotFound();
            }
            else 
            {
                Genre = genre;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Genre == null)
            {
                return NotFound();
            }
            var genre = await _context.Genre.FindAsync(id);

            if (genre != null)
            {
                Genre = genre;
                _context.Genre.Remove(Genre);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
