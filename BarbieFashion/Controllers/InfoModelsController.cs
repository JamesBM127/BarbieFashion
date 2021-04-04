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
using BarbieFashion.Services.Exceptions;
using BarbieFashion.Models.ViewModels;
using System.Diagnostics;

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
            InfoModel infoModel = await _modelsService.FindByIdAsync(id.Value);
            Parents parents = await _modelsService.FindParentsByIdAsync(infoModel.Id);
            if (infoModel == null)
            {
                return NotFound();
            }
            InfoModelViewModel viewModel = new InfoModelViewModel { InfoModel = infoModel, Parents = parents };
            return View(viewModel);
        }

        // GET: InfoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,City,FullTimeJob,InternationalWork,PhoneNumber,Email,Personality")] InfoModel infoModel)
        {
            if (ModelState.IsValid)
            {
                if (infoModel.Age >= 15 && infoModel.Age < 18)
                {
                    //await _modelsService.InsertAsync(infoModel);
                    return RedirectToAction(nameof(CreateMinorModel), infoModel);
                }
                try
                {
                    await _modelsService.InsertAsync(infoModel);
                    return RedirectToAction(nameof(Index));
                }
                catch (IntegrityException e)
                {
                    //This error means that the model is under 15 or over 23 years old.
                    return RedirectToAction(nameof(Error), new { message = e.Message });
                }
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,City,FullTimeJob,InternationalWork,PhoneNumber,Email,Personality")] InfoModel infoModel)
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

        public IActionResult CreateMinorModel(InfoModel infoModel)
        {
            InfoModelViewModel viewModel = new InfoModelViewModel { InfoModel = infoModel };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMinorModel(InfoModelViewModel viewModel, int? id)
        {
            //TA DANDO ERRO PORQUE NÃO DA PRA CRIAR OS PAIS DE UMA MODELO QUE AINDA NÃO EXISTE NO BANCO DE DADOS.
            InfoModel model = viewModel.InfoModel;
            model.Parents = viewModel.Parents;
            await _modelsService.InsertAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
