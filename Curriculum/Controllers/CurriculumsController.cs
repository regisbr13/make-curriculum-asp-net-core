using MakeCurriculum.Models;
using MakeCurriculum.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RotativaHQ.AspNetCore;
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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                int id = int.Parse(HttpContext.Session.GetString("UserId"));
                return View(await _curriculumService.FindAllAsync(id));
            }
            ViewBag.id = HttpContext.Session.GetString("UserId");
            return View("Error");
        }

        // GET:
        [Authorize]
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
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Curriculum obj)
        {
            obj.UserId = int.Parse(HttpContext.Session.GetString("UserId"));
            if (ModelState.IsValid)
            {
                await _curriculumService.InsertAsync(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // EDIT GET:
        [Authorize]
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
            obj.UserId = int.Parse(HttpContext.Session.GetString("UserId"));
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
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> ViewPdf(int? id)
        {
            var obj = await _curriculumService.FindByIdAsync(id);
            return new ViewAsPdf("Pdf", obj) { FileName = "Curriculo.pdf" };
        }

        [Authorize]
        public async Task<IActionResult> Pdf(int id)
        {
            var obj = await _curriculumService.FindByIdAsync(id);
            return View(obj);
        }

        public async Task<JsonResult> CurriculumExists(Curriculum obj)
        {
            int userId = int.Parse(HttpContext.Session.GetString("UserId"));
            if (await _curriculumService.HasName(obj, userId))          
                return Json("currículo já cadastrado");
            return Json(true);
        }
    }
}
