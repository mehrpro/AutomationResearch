using System.Collections.Generic;
using System.Threading.Tasks;
using AutomationResearch.Models;
using AutomationResearch.ViewModels.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutomationResearch.Services
{
    public interface IUserManagerService
    {
        /// <summary>
        /// افزودن کاربر جدید
        /// </summary>
        /// <param name="model">مدل</param>
        /// <returns></returns>
        Task<IdentityResult> AddUserTask(RegisterViewModel model);
        /// <summary>
        /// لیست کاربران سامانه
        /// </summary>
        /// <returns></returns>
        Task<List<RegisterViewModel>> GetAllUserTask();
    }

    public class UserManagerService : IUserManagerService
    {
        //private AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public UserManagerService(AppDbContext context, UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            //_context = context;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public async Task<IdentityResult> AddUserTask(RegisterViewModel model)
        {
            var user = new AppUser()
            {
                UserName = model.UserName,
                FName = model.FName,
                LName = model.LName,
                Email = model.Email,
                EmailConfirmed = true,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }

        public async Task<List<RegisterViewModel>> GetAllUserTask()
        {
            var mo = _unitOfWork.userManagerUW.Get();

            //var list = await _userManager.Users.ToListAsync();
            var resultList = new List<RegisterViewModel>();
            foreach (var item in mo)
            {
                resultList.Add(new RegisterViewModel
                {
                    UserId = item.Id,
                    FName = item.FName,
                    LName = item.LName,
                    UserName = item.UserName,
                    //MelliCode = item.MelliCode,
                    //Password = item.Password,
                    //ConfirmPassword = item.Password,
                    Email = item.Email,
                    //PhoneNumber = item.PhoneNumber
                });
            }

            return resultList;
        }
    }
}