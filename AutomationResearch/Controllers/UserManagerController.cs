using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationResearch.Models;
using AutomationResearch.Services;
using AutomationResearch.ViewModels.Admin;
using Microsoft.AspNetCore.Identity;

namespace AutomationResearch.Controllers
{
    public class UserManagerController : Controller
    {
        private readonly IUserManagerService _userManagerService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public UserManagerController(IUserManagerService userManagerService, UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManagerService = userManagerService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _userManagerService.GetAllUserTask();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var result = await _userManagerService.AddUserTask(model);
            if (result.Succeeded) return RedirectToAction("Index");
            foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);
            return View(model);
        }


        public async Task<IActionResult> EditUser(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var model = new RegisterViewModel
            {
                UserId = user.Id,
                FName = user.FName,
                LName = user.LName,
                UserName = user.UserName,
                MelliCode = user.MelliCode,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            return View(model);
        }








        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return Json(true);
            return Json("ایمیل وارد شده از قبل موجود است");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsUserNameInUse(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return Json(true);
            return Json("نام کاربری وارد شده از قبل موجود است");
        }

    }
}
