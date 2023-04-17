using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TFT_Test.Data;
using TFT_Test.Models;

namespace TFT_Test.Pages.ActorsCRUD
{
    public class IndexModel : PageModel
    {
        private readonly TFT_Test.Data.ActorCRUDContext _context;

        public IndexModel(TFT_Test.Data.ActorCRUDContext context)
        {
            _context = context;
        }

        public IList<Actor> Actor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Actor != null)
            {
                Actor = await _context.Actor.ToListAsync();
            }
        }
    }
}
