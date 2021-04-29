﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Notespace.Web.Data;
using Notespace.Web.Models;

namespace Notespace.Web.Controllers
{
    public class NotebooksController : Controller
    {
        private readonly ApplicationIdentityContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public NotebooksController(ApplicationIdentityContext context,
               UserManager<ApplicationUser> userMgr,
               SignInManager<ApplicationUser> signInMgr)
        {
            _userManager = userMgr;
            _signInManager = signInMgr;
            _context = context;
        }

        #region HTTP GET

        public async Task<IActionResult> Index()
        {
            var applicationIdentityContext = _context.Notebooks.Include(n => n.User);
            return View(await applicationIdentityContext
                                .Where(n => n.UserID == _userManager.GetUserId(User))
                                .OrderByDescending(n => n.LastModified)
                                .ToListAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notebook = await _context.Notebooks
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NotebookID == id);
            if (notebook == null)
            {
                return NotFound();
            }

            return View(notebook);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notebook = await _context.Notebooks.FindAsync(id);
            if (notebook == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", notebook.UserID);
            return View(notebook);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notebook = await _context.Notebooks
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NotebookID == id);
            if (notebook == null)
            {
                return NotFound();
            }

            return View(notebook);
        }

        #endregion

        #region HTTP POST

        [HttpPost]
        public async Task<IActionResult> CreateAsync()
        {
            var name = Request.Form["name"];
            bool ispublic = Request.Form["public"] == "on";
            var color = Request.Form["color"];

            Notebook notebook = new Notebook();
            notebook.Title = name;
            notebook.UserID = _userManager.GetUserId(User);
            notebook.IsPublic = ispublic;
            notebook.Color = byte.Parse(color);
            notebook.LastModified = DateTime.Now;
            _context.Add(notebook);

            Note note = new Note();
            note.UserID = notebook.UserID;
            note.Notebook = notebook;
            note.LastModified = DateTime.Now;
            note.IsPublic = ispublic;
            note.Order = 0;
            note.Text = "";
            note.HTML = "";
            note.Title = "Page 1";
            _context.Add(note);
            await _context.SaveChangesAsync();

            return Redirect("/notebooks");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("NotebookID,UserID,Title,IsPublic,Color,LastModified")] Notebook notebook)
        {
            if (id != notebook.NotebookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notebook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotebookExists(notebook.NotebookID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", notebook.UserID);
            return View(notebook);
        }


        // POST: Notebooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var notebook = await _context.Notebooks.FindAsync(id);
            _context.Notebooks.Remove(notebook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region HELPER METHODS

        private bool NotebookExists(long id)
        {
            return _context.Notebooks.Any(e => e.NotebookID == id);
        }

        #endregion
    }
}