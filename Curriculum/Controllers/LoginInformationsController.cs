using MakeCurriculum.Data;
using MakeCurriculum.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace MakeCurriculum.Controllers
{
    public class LoginInformationsController : Controller
    {
        private readonly LoginInformationService _loginService;

        public LoginInformationsController(LoginInformationService loginService)
        {
            _loginService = loginService;
        }

        // Listagem das informações de login por Id do usuário
        [Authorize]
        [HttpGet("/Informacoes-de-Login")]
        public async Task<IActionResult> Index(int? page)
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                const int pageItems = 10;
                int pageNumber = (page ?? 1);
                var userId = int.Parse(HttpContext.Session.GetString("UserId"));
                var list = await _loginService.LoginInformationByUserId(userId);
                return View(await list.ToPagedListAsync(pageNumber, pageItems));
            }
            return View("Error");
        }

        // Download das informações de login em arquivo CSV
        [Authorize]
        public async Task<IActionResult> DataDownload()
        {
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            var list = await _loginService.LoginInformationByUserId(userId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Endereço IP; Data; Horário");

            foreach(var item in list)
            {
                sb.AppendLine(item.Ip + ";" + item.LoginDate.ToShortDateString() + ";" + item.LoginDate.ToShortTimeString());
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "info.csv");
        }
    }
}
