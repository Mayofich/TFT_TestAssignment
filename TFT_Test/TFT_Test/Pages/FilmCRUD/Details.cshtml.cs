using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TFT_Test.Data;
using TFT_Test.Models;

namespace TFT_Test.Pages.FilmCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly TFT_Test.Data.FilmCRUDContext _context;

        public DetailsModel(TFT_Test.Data.FilmCRUDContext context)
        {
            _context = context;
        }

      public Film Film { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Film == null)
            {
                return NotFound();
            }

            var film = await _context.Film.FirstOrDefaultAsync(m => m.FilmId == id);
            if (film == null)
            {
                return NotFound();
            }
            else 
            {
                Film = film;
            }
            return Page();
        }
    }
}
