using MakeCurriculum.Models;
using MakeCurriculum.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Controllers
{
    public class ObjectivesController : Controller
    {
        private readonly ObjectiveService _objectiveService;

        public ObjectivesController(ObjectiveService objectiveService)
        {
            _objectiveService = objectiveService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(Prefix = "Objective")] Objective obj)
        {
            if (ModelState.IsValid)
            {
                await _objectiveService.InsertAsync(obj);
                return RedirectToRoute(new { controller = "Curriculums", action = "Details", id = obj.CurriculumId });
            }
            return RedirectToRoute(new { controller = "Curriculums", action = "Details", id = obj.CurriculumId });
        }

        // DELETE GET:
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _objectiveService.FindByIdAsync(id);
            TempData["id"] = obj.CurriculumId;
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // DELETE POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _objectiveService.RemoveAsync(id);
            return RedirectToRoute(new { controller = "Curriculums", action = "Details", id = TempData["id"] });
        }

        // EDIT GET:
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _objectiveService.FindByIdAsync(id);
            TempData["id"] = obj.CurriculumId;
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Objective obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _objectiveService.UpdateAsync(obj);
                return RedirectToRoute(new { controller = "Curriculums", action = "Details", id = TempData["id"] });
            }
            return View(obj);
        }
    }
}
