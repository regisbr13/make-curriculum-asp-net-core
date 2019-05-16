﻿using MakeCurriculum.Data;
using MakeCurriculum.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var list = await _loginService.LoginInformationByUserId(userId);
            return View(list);
        }

        // Download das informações de login em arquivo CSV
        public async Task<IActionResult> DataDownload()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
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
