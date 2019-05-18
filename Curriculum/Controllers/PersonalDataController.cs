using MakeCurriculum.Models;
using MakeCurriculum.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Controllers
{
    public class PersonalDataController : Controller
    {
        private readonly PersonalDataService _personalDataService;

        public PersonalDataController(PersonalDataService personalDataService)
        {
            _personalDataService = personalDataService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(Prefix = "PersonalData")] PersonalData obj)
        {
            if (ModelState.IsValid)
            {
                await _personalDataService.InsertAsync(obj);
                return RedirectToRoute(new { controller = "Curriculums", action = "Details", id = obj.CurriculumId });
            }
            return View("Error");
        }

        // DELETE GET:
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _personalDataService.FindByIdAsync(id);
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
            await _personalDataService.RemoveAsync(id);
            return RedirectToRoute(new { controller = "Curriculums", action = "Details", id = TempData["id"] });
        }

        // EDIT GET:
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _personalDataService.FindByIdAsync(id);
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
        public async Task<IActionResult> Edit(int id, PersonalData obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _personalDataService.UpdateAsync(obj);
                return RedirectToRoute(new { controller = "Curriculums", action = "Details", id = TempData["id"] });
            }
            return View(obj);
        }
    }
}
