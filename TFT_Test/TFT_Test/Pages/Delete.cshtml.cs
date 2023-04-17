using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TFT_Test.Data;
using TFT_Test.Models;

namespace TFT_Test.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly TFT_Test.Data.DirectorCRUDContext _context;

        public DeleteModel(TFT_Test.Data.DirectorCRUDContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Director Director { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Directors == null)
            {
                return NotFound();
            }

            var director = await _context.Directors.FirstOrDefaultAsync(m => m.DirectorId == id);

            if (director == null)
            {
                return NotFound();
            }
            else 
            {
                Director = director;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Directors == null)
            {
                return NotFound();
            }
            var director = await _context.Directors.FindAsync(id);

            if (director != null)
            {
                Director = director;
                _context.Directors.Remove(Director);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
