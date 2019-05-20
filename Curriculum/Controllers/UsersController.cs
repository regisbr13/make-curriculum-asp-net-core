using MakeCurriculum.Models;
using MakeCurriculum.Models.ViewModels;
using MakeCurriculum.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MakeCurriculum.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        private readonly LoginInformationService _loginService;

        public UsersController(UserService userService, LoginInformationService loginService)
        {
            _userService = userService;
            _loginService = loginService;
        }

        // CREATE GET:
        public IActionResult Register()
        {
            return View();
        }

        // CREATE POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User obj)
        {
            if (ModelState.IsValid)
            {
                await _userService.InsertAsync(obj);
                LoginInformation info = new LoginInformation()
                {
                    UserId = obj.Id,
                    Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    LoginDate = DateTime.Now
                };
                await _loginService.InsertAsync(info);

                HttpContext.Session.SetInt32("UserId", obj.Id);
                var claims = new List<Claim> { new Claim(ClaimTypes.Email, obj.Email)};

                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Curriculums");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if(await _userService.HasAny(viewModel))
            {
                int id = _userService.UserId(viewModel);

                LoginInformation info = new LoginInformation()
                {
                    UserId = id,
                    Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    LoginDate = DateTime.Now
                };
                await _loginService.InsertAsync(info);

                HttpContext.Session.SetInt32("UserId", id);
                var claims = new List<Claim> { new Claim(ClaimTypes.Email, viewModel.Email) };

                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Curriculums");
            }
            else
            {
                return View(viewModel);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        public async Task<JsonResult> UserExist(User user)
        {
            if (await _userService.HasAnyEmail(user))
                return Json("email já cadastrado");
            return Json(true);
        }

        public async Task<JsonResult> EmailError(LoginViewModel viewModel)
        {
            if (await _userService.HasAnyEmail(viewModel))
                return Json(true);
            return Json("email ou senha inválidos");
        }

        public async Task<JsonResult> PasswordError(LoginViewModel viewModel)
        {
            if (await _userService.HasAnyPassword(viewModel))
                return Json(true);
            return Json("email ou senha inválidos");
        }
    }
}
