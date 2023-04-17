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
    public class DetailsModel : PageModel
    {
        private readonly TFT_Test.Data.ActorCRUDContext _context;

        public DetailsModel(TFT_Test.Data.ActorCRUDContext context)
        {
            _context = context;
        }

      public Actor Actor { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Actor == null)
            {
                return NotFound();
            }

            var actor = await _context.Actor.FirstOrDefaultAsync(m => m.ActorId == id);
            if (actor == null)
            {
                return NotFound();
            }
            else 
            {
                Actor = actor;
            }
            return Page();
        }
    }
}
