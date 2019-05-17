using MakeCurriculum.Models;
using MakeCurriculum.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Controllers
{
    public class AcademicsController : Controller
    {
        private readonly AcademicService _academicService;
        private readonly CoursesTypeService _coursesService;

        public AcademicsController(AcademicService academicService, CoursesTypeService coursesService)
        {
            _academicService = academicService;
            _coursesService = coursesService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(Prefix = "Academic")] Academic obj)
        {
            if (ModelState.IsValid)
            {
                await _academicService.InsertAsync(obj);
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

            var obj = await _academicService.FindByIdAsync(id);
            ViewBag.obj = obj.CourseName;
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
            await _academicService.RemoveAsync(id);
            return RedirectToRoute(new { controller = "Curriculums", action = "Details", id = TempData["id"] });
        }

        // EDIT GET:
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _academicService.FindByIdAsync(id);
            TempData["id"] = obj.CurriculumId;
            ViewBag.items = new SelectList(await _coursesService.FindAllAsync(), "Id", "Type");
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Academic obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _academicService.UpdateAsync(obj);
                return RedirectToRoute(new { controller = "Curriculums", action = "Details", id = TempData["id"] });
            }
            return View(obj);
        }
    }
}
