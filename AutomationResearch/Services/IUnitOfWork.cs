using System;
using AutomationResearch.Models;

namespace AutomationResearch.Services
{
    public interface IUnitOfWork
    {
        GenericClass<AppUser> userManagerUW { get; }
        GenericClass<AppRole> roleManagerUW { get; }

        void save();
        void Dispose();
    }

    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private  AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private GenericClass<AppUser> _userManager;
        private GenericClass<AppRole> _roleManager;

        //کاربران
        public GenericClass<AppUser> userManagerUW
        {
            //فقط خواندنی    
            get
            {
                if (_userManager == null)
                {
                    _userManager = new GenericClass<AppUser>(_context);
                }
                return _userManager;
            }
        }

        //نقش ها
        public GenericClass<AppRole> roleManagerUW
        {
            //فقط خواندنی    
            get
            {
                if (_roleManager == null)
                {
                    _roleManager = new GenericClass<AppRole>(_context);
                }
                return _roleManager;
            }
        }


        public void save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
