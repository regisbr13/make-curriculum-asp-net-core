using MakeCurriculum.Models;
using MakeCurriculum.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Controllers
{
    public class CurriculumsController : Controller
    {
        private readonly CurriculumService _curriculumService;
        private readonly CoursesTypeService _coursesService;

        public CurriculumsController(CurriculumService curriculumService, CoursesTypeService coursesService)
        {
            _curriculumService = curriculumService;
            _coursesService = coursesService;
        }

        // GET:
        public async Task<IActionResult> Index()
        {
            return View(await _curriculumService.FindAllAsync());
        }

        // GET:
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _curriculumService.FindByIdAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            ViewBag.items = new SelectList(await _coursesService.FindAllAsync(), "Id", "Type");
            return View(obj);
        }

        // CREATE GET:
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Curriculum obj)
        {
            obj.UserId = int.Parse(HttpContext.Session.GetInt32("UserId").ToString());
            if (ModelState.IsValid)
            {
                await _curriculumService.InsertAsync(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // EDIT GET:
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculum = await _curriculumService.FindByIdAsync(id);
            if (curriculum == null)
            {
                return NotFound();
            }
            return View(curriculum);
        }

        // Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Curriculum obj)
        {
            obj.UserId = int.Parse(HttpContext.Session.GetInt32("UserId").ToString());
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _curriculumService.UpdateAsync(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // DELETE GET:
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _curriculumService.FindByIdAsync(id);
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
            await _curriculumService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // Gerar PDF:
        public async Task<IActionResult> ViewPdf(int id)
        {
            var obj = await _curriculumService.FindByIdAsync(id);
            return new ViewAsPdf("Pdf", obj) { FileName = obj.Name + ".pdf" };
        }

        public async Task<IActionResult> Pdf(int id)
        {
            var obj = await _curriculumService.FindByIdAsync(id);
            return View(obj);
        }
    }
}
