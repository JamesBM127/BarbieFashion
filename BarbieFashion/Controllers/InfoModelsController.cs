using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarbieFashion.Data;
using BarbieFashion.Models;
using BarbieFashion.Services;

namespace BarbieFashion.Controllers
{
    public class InfoModelsController : Controller
    {
        private readonly InfoModelService _modelsService;

        public InfoModelsController(InfoModelService modelsService)
        {
            _modelsService = modelsService;
        }



        // GET: InfoModels
        public async Task<IActionResult> Index()
        {
            var list = await _modelsService.FindAllAsync();
            return View(list);
        }

        // GET: InfoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoModel = await _modelsService.FindByIdAsync(id.Value);
            if (infoModel == null)
            {
                return NotFound();
            }

            return View(infoModel);
        }

        // GET: InfoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,City,FullTimeJob,InternationalWork,PhoneNumber,Email")] InfoModel infoModel)
        {
            if (ModelState.IsValid)
            {
                await _modelsService.InsertAsync(infoModel);
                return RedirectToAction(nameof(Index));
            }
            return View(infoModel);
        }

        // GET: InfoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoModel = await _modelsService.FindByIdAsync(id.Value);
            if (infoModel == null)
            {
                return NotFound();
            }
            return View(infoModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,City,FullTimeJob,InternationalWork,PhoneNumber,Email")] InfoModel infoModel)
        {
            if (id != infoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _modelsService.UpdateAsync(infoModel);

                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(infoModel);
        }

        // GET: InfoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoModel = await _modelsService.FindByIdAsync(id.Value);
            if (infoModel == null)
            {
                return NotFound();
            }

            return View(infoModel);
        }

        // POST: InfoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var infoModel = await _modelsService.FindByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
