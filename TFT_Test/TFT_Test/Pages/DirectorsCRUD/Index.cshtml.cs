using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TFT_Test.Data;
using TFT_Test.Models;

namespace TFT_Test.Pages.DirectorsCRUD
{
    public class IndexModel : PageModel
    {
        private readonly TFT_Test.Data.DirectorCRUDContext _context;

        public IndexModel(TFT_Test.Data.DirectorCRUDContext context)
        {
            _context = context;
        }

        public IList<Director> Director { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Directors != null)
            {
                Director = await _context.Directors.ToListAsync();
            }
        }
    }
}
