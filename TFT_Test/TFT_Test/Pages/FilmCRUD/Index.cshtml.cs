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
    public class IndexModel : PageModel
    {
        private readonly TFT_Test.Data.FilmCRUDContext _context;

        public IndexModel(TFT_Test.Data.FilmCRUDContext context)
        {
            _context = context;
        }

        public IList<Film> Film { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Film != null)
            {
                Film = await _context.Film.ToListAsync();
            }
        }
    }
}
