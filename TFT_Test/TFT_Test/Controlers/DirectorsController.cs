using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFT_Test.Data;
using TFT_Test.DataAccess;
using TFT_Test.Models;

namespace TFT_Test.Controlers
{
    public class DirectorsController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public DirectorsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        // GET: Directors
        public async Task<IActionResult> Index()
        {
              return _dataAccessProvider.GetAllDirectors != null ? 
                          View( _dataAccessProvider.GetAllDirectors()) :
                          Problem("There are no recorded Directors in the database");
        }

        // GET: Directors/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if ( _dataAccessProvider.GetAllDirectors == null)
            {
                return NotFound();
            }

            var director = _dataAccessProvider.GetDirectorRecord(id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectorId,DirectorName,DirectorSurname,DirectorEmail,DirectorPassword")] Director director)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddDirectorRecord(director);
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        // GET: Directors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if ( _dataAccessProvider.GetAllDirectors == null)
            {
                return NotFound();
            }

            var director = _dataAccessProvider.GetDirectorRecord(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        // POST: Directors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectorId,DirectorName,DirectorSurname,DirectorEmail,DirectorPassword")] Director director)
        {
            if (id != director.DirectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataAccessProvider.UpdateDirectorRecord(director);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_dataAccessProvider.GetDirectorRecord(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        // GET: Directors/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if ( _dataAccessProvider.GetAllDirectors == null)
            {
                return NotFound();
            }

            var director = _dataAccessProvider.GetDirectorRecord(id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_dataAccessProvider.GetAllDirectors == null)
            {
                return Problem("There are no recorded Directors in the database");
            }
            var director = _dataAccessProvider.GetDirectorRecord(id);
            if (director != null)
            {
                _dataAccessProvider.DeleteDirectorRecord(id);
            }
            
            return RedirectToAction(nameof(Index));
        }


    }
}
