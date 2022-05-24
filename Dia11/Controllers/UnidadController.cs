using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dia11.Data;
using Dia11.Models;
using Dia11.UnitOfWork;
using Dia11.Repositories.Implementaciones;
using Dia11.Repositories;

namespace Dia11.Controllers
{
    public class UnidadController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public UnidadController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        // GET: Unidad

        public async Task<IActionResult> Index()
        {
            var unidades = await _unitOfWork.RepoUnidad.GetAll();
            return View(unidades);

        }

        // GET: Unidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _unitOfWork.RepoUnidad == null)
            {
                return NotFound();
            }

            var unidad = await _unitOfWork.RepoUnidad.GetById(id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // GET: Unidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Año,Kilometraje,Precio")] Unidad unidad)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.RepoUnidad.Insert(unidad);
                await _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(unidad);
        }

        // GET: Unidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _unitOfWork.RepoUnidad == null)
            {
                return NotFound();
            }

            var unidad = await _unitOfWork.RepoUnidad.GetById(id);
            if (unidad == null)
            {
                return NotFound();
            }
            return View(unidad);
        }

        // POST: Unidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Año,Kilometraje,Precio")] Unidad unidad)
        {
            if (id != unidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.RepoUnidad.Update(unidad);
                    await _unitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadExists(unidad.Id))
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
            return View(unidad);
        }

        // GET: Unidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _unitOfWork.RepoUnidad == null)
            {
                return NotFound();
            }

            var unidad = await _unitOfWork.RepoUnidad.GetById(id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // POST: Unidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.RepoUnidad == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Unidades'  is null.");
            }
            var unidad = await _unitOfWork.RepoUnidad.GetById(id);
            if (unidad != null)
            {
                await _unitOfWork.RepoUnidad.Delete(id);
            }

            await _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadExists(int id)
        {
            return true; //(_context.Unidades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
