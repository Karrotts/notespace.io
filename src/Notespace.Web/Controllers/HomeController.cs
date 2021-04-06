using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notespace.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Notespace.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return View();
            }
            return Redirect("./account/login");
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
