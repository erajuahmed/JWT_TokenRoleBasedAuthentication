using JWT_TokenRoleBasedAuthentication.Data;
using JWT_TokenRoleBasedAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_TokenRoleBasedAuthentication.Controllers
{
    public class LoginController : BaseController
    {
        ApplicationDbContext db;
        public LoginController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public IActionResult LoginNow(AdminLogin model)
        {
            var admin = db.AdminLogin.Where(x => x.UserName.Trim() == model.UserName.Trim() && x.Password == model.Password).FirstOrDefault();
            try
            {
                if (admin != null)
                {
                    admin.Role = db.Role.Where(x => x.Id == admin.RoleId).FirstOrDefault();
                    _ = CreateAuthenticationTicket(admin);
                    // Show Success Message -"Welcome!"    
                    return RedirectToAction(nameof(ProfileController.CreateEditProfile), "Profile");
                }
                else
                {
                    //  Show Error Message- "Invalid Credentials."    
                    return View("Index", model);
                }
            }
            catch (Exception ex)
            {
                //Show Error Message- ex.Message    
                return View("Index", model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
