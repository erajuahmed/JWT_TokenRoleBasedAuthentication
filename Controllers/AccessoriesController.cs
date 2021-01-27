using JWT_TokenRoleBasedAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_TokenRoleBasedAuthentication.Controllers
{
    [Authorize(Role.Guest)]
    public class AccessoriesController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
