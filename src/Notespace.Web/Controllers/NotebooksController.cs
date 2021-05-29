using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConvertMarkdown;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationIdentityContext = _context.Notebooks.Include(n => n.User);
            return View(await applicationIdentityContext
                                .Where(n => n.UserID == _userManager.GetUserId(User))
                                .OrderByDescending(n => n.LastModified)
                                .ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Details(long? id, long? pageId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notebook = await _context.Notebooks
                .Include(n => n.User)
                .Include(n => n.Notes)
                .FirstOrDefaultAsync(m => m.NotebookID == id);

            var creator = await _context.Users.FirstOrDefaultAsync(n => n.Id == notebook.UserID);

            if (!notebook.IsPublic && notebook.UserID != _userManager.GetUserId(User))
            {
                return View("Restricted");
            }

            if (notebook == null)
            {
                return NotFound();
            }

            ViewData["Name"] = notebook.Title;
            ViewData["Pages"] = notebook.Notes.Count;
            ViewData["Color"] = notebook.Color;
            ViewData["Creator"] = creator.UserName;
            ViewData["UserID"] = _userManager.GetUserId(User);

            return View(notebook.Notes.FirstOrDefault(n => n.Order == pageId));
        }

        [Authorize]
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

        [Authorize]
        public async Task<IActionResult> EditPage(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        [Authorize]
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
        [ValidateAntiForgeryToken]
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
        public async Task<IActionResult> CreatePageAsync()
        {
            var name = Request.Form["name"];
            var notebookID = Request.Form["NotebookID"];
            var Order = Request.Form["Order"];

            Note note = new Note();
            note.Title = name;
            note.NotebookID = long.Parse(notebookID);
            note.Text = "";
            note.HTML = "";
            note.IsPublic = false;
            note.LastModified = DateTime.Now;
            note.UserID = _userManager.GetUserId(User);
            note.Order = int.Parse(Order) + 1;

            var notes = await _context.Notes.Where(n => n.NotebookID == note.NotebookID).ToListAsync();

            int addNumber = note.Order;
            foreach (Note n in notes)
            {
                if (n.Order >= addNumber)
                {
                    n.Order++;
                    _context.Notes.Update(n);
                }
            }

            _context.Add(note);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = note.NotebookID, pageId = note.Order });
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPage(long id, [Bind("NoteID,NotebookID,Order,IsPublic,Title,Text")] Note note)
        {

            if (id != note.NoteID)
            {
                return NotFound();
            }

            note.UserID = _userManager.GetUserId(User);
            note.LastModified = DateTime.Now;
            note.Text = note.Text == null ? "" : note.Text;
            note.HTML = Markdown.Convert(note.Text.Split(
                                    new[] { "\r\n", "\r", "\n" },
                                    StringSplitOptions.None
                                    ).ToList<string>());

            var notebook = _context.Notebooks.FirstOrDefault(n => n.NotebookID == note.NotebookID);
            notebook.LastModified = note.LastModified;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    _context.Update(notebook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Notes.Any(e => e.NoteID == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = note.NotebookID, pageId = note.Order });
            }
            return View(note);
        }

        public async Task<IActionResult> DeletePage(long id)
        {
            var note = await _context.Notes.FindAsync(id);
            var notebook = await _context.Notebooks.FindAsync(note.NotebookID);
            var notes = await _context.Notes.Where(n => n.NotebookID == notebook.NotebookID).ToListAsync();
            if (notebook.Notes.Count > 1)
            {
                int removeNumber = note.Order;
                foreach(Note n in notes)
                {
                    if (n.Order > removeNumber)
                    {
                        n.Order--;
                        _context.Notes.Update(n);
                    }
                }
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = note.NotebookID, pageId = note.Order - 1 < 0 ? 0 : note.Order - 1});
            }

            _context.Notes.Remove(note);
            _context.Notebooks.Remove(notebook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
