using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notespace.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Notespace.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Notespace.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationIdentityContext _context;

        public HomeController(ApplicationIdentityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var notebooks = await _context.Notebooks
                    .Include(n => n.User)
                    .Where(m => m.IsPublic)
                    .ToListAsync();

                var notes = await _context.Notes
                    .Include(n => n.User)
                    .Where(m => m.IsPublic && m.NotebookID == null)
                    .ToListAsync();

                PublicItems pi = new PublicItems { PublicNotebooks = notebooks, PublicNotes = notes };
                return View(pi);
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
