using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFT_Test.Data;
using TFT_Test.Models;

namespace TFT_Test.Pages.DirectorsCRUD
{
    public class CreateModel : PageModel
    {
        private readonly TFT_Test.Data.DirectorCRUDContext _context;

        public CreateModel(TFT_Test.Data.DirectorCRUDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Director Director { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Directors == null || Director == null)
            {
                return Page();
            }

            _context.Directors.Add(Director);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
