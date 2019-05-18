using MakeCurriculum.Models;
using MakeCurriculum.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MakeCurriculum.Controllers
{
    public class ExtraActivitiesController : Controller
    {
        private readonly ExtraActivityService _extraActivityService;

        public ExtraActivitiesController(ExtraActivityService extraActivityService)
        {
            _extraActivityService = extraActivityService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(Prefix = "ExtraActivity")] ExtraActivity obj)
        {
            if (ModelState.IsValid)
            {
                await _extraActivityService.InsertAsync(obj);
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

            var obj = await _extraActivityService.FindByIdAsync(id);
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
            await _extraActivityService.RemoveAsync(id);
            return RedirectToRoute(new { controller = "Curriculums", action = "Details", id = TempData["id"] });
        }

        // EDIT GET:
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _extraActivityService.FindByIdAsync(id);
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
        public async Task<IActionResult> Edit(int id, ExtraActivity obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _extraActivityService.UpdateAsync(obj);
                return RedirectToRoute(new { controller = "Curriculums", action = "Details", id = TempData["id"] });
            }
            return View(obj);
        }
    }
}
