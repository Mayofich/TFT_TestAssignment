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
    public class IndexModel : PageModel
    {
        private readonly TFT_Test.Data.GenreCRUDContext _context;

        public IndexModel(TFT_Test.Data.GenreCRUDContext context)
        {
            _context = context;
        }

        public IList<Genre> Genre { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Genre != null)
            {
                Genre = await _context.Genre.ToListAsync();
            }
        }
    }
}
