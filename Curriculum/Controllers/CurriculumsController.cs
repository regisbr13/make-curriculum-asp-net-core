using MakeCurriculum.Models;
using MakeCurriculum.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Controllers
{
    public class CurriculumsController : Controller
    {
        private readonly CurriculumService _curriculumService;
        private readonly ObjectiveService _objectiveService;
        private readonly CoursesTypeService _coursesService;
        private readonly AcademicService _academicService;
        private readonly ProfessionalExpService _expService;
        private readonly LanguageService _languageService;

        public CurriculumsController(CurriculumService curriculumService, ObjectiveService objectiveService, CoursesTypeService coursesService, AcademicService academicService, ProfessionalExpService expService, LanguageService languageService)
        {
            _curriculumService = curriculumService;
            _objectiveService = objectiveService;
            _coursesService = coursesService;
            _academicService = academicService;
            _expService = expService;
            _languageService = languageService;
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
            obj.Objectives = await _objectiveService.FindByCurriculumId(id);
            obj.Academics = await _academicService.FindByCurriculumId(id);
            obj.ProfessionalExps = await _expService.FindByCurriculumId(id);
            obj.Languages = await _languageService.FindByCurriculumId(id);
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
    }
}
