using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFT_Test.Data;
using TFT_Test.Models;

namespace TFT_Test.Pages.ActorsCRUD
{
    public class CreateModel : PageModel
    {
        private readonly TFT_Test.Data.ActorCRUDContext _context;

        public CreateModel(TFT_Test.Data.ActorCRUDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Actor Actor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Actor == null || Actor == null)
            {
                return Page();
            }

            _context.Actor.Add(Actor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
