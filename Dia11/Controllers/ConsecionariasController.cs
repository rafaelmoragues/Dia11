using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dia11.Data;
using Dia11.Models;

namespace Dia11.Controllers
{
    public class ConsecionariasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsecionariasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consecionarias
        public async Task<IActionResult> Index()
        {
            var cons = _context.Consecionarias.ToList();
              return View(cons);

        }

        // GET: Consecionarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consecionarias == null)
            {
                return NotFound();
            }

            var consecionaria = await _context.Consecionarias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consecionaria == null)
            {
                return NotFound();
            }

            return View(consecionaria);
        }
        public async Task<IActionResult> Details2(int? id)
        {
            if (id == null || _context.Consecionarias == null)
            {
                return NotFound();
            }

            var consecionaria = await _context.Consecionarias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consecionaria == null)
            {
                return NotFound();
            }

            return View(consecionaria);
        }

        // GET: Consecionarias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consecionarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Imagen,Descripcion,Telefono,Direccion,Email")] Consecionaria consecionaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consecionaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consecionaria);
        }

        // GET: Consecionarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consecionarias == null)
            {
                return NotFound();
            }

            var consecionaria = await _context.Consecionarias.FindAsync(id);
            if (consecionaria == null)
            {
                return NotFound();
            }
            return View(consecionaria);
        }
        public async Task<IActionResult> Edit2(int? id)
        {
            if (id == null || _context.Consecionarias == null)
            {
                return NotFound();
            }

            var consecionaria = await _context.Consecionarias.FindAsync(id);
            if (consecionaria == null)
            {
                return NotFound();
            }
            return View(consecionaria);
        }

        // POST: Consecionarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Imagen,Descripcion,Telefono,Direccion,Email")] Consecionaria consecionaria)
        {
            if (id != consecionaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consecionaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsecionariaExists(consecionaria.Id))
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
            return View(consecionaria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit2(int id, [Bind("Id,Name,Imagen,Descripcion,Telefono,Direccion,Email")] Consecionaria consecionaria)
        {
            if (id != consecionaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consecionaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsecionariaExists(consecionaria.Id))
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
            return View(consecionaria);
        }

        // GET: Consecionarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consecionarias == null)
            {
                return NotFound();
            }

            var consecionaria = await _context.Consecionarias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consecionaria == null)
            {
                return NotFound();
            }

            return View(consecionaria);
        }

        // POST: Consecionarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consecionarias == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Consecionarias'  is null.");
            }
            var consecionaria = await _context.Consecionarias.FindAsync(id);
            if (consecionaria != null)
            {
                _context.Consecionarias.Remove(consecionaria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsecionariaExists(int id)
        {
          return (_context.Consecionarias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
