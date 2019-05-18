using MakeCurriculum.Models;
using MakeCurriculum.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Controllers
{
    public class ResumesController : Controller
    {
        private readonly ResumeService _resumeService;

        public ResumesController(ResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(Prefix = "Resume")] Resume obj)
        {
            if (ModelState.IsValid)
            {
                await _resumeService.InsertAsync(obj);
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

            var obj = await _resumeService.FindByIdAsync(id);
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
            await _resumeService.RemoveAsync(id);
            return RedirectToRoute(new { controller = "Curriculums", action = "Details", id = TempData["id"] });
        }

        // EDIT GET:
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _resumeService.FindByIdAsync(id);
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
        public async Task<IActionResult> Edit(int id, Resume obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _resumeService.UpdateAsync(obj);
                return RedirectToRoute(new { controller = "Curriculums", action = "Details", id = TempData["id"] });
            }
            return View(obj);
        }
    }
}
