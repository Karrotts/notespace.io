using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Notespace.Web.Data;
using Notespace.Web.Models;
using ConvertMarkdown;

namespace Notespace.Web.Controllers
{
    public class NotesController : Controller
    {
        private readonly ApplicationIdentityContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public NotesController(ApplicationIdentityContext context, 
               UserManager<ApplicationUser> userMgr,
               SignInManager<ApplicationUser> signInMgr)
        {
            _userManager = userMgr;
            _signInManager = signInMgr;
            _context = context;
        }

        #region HTTP GET

        // GET: Notes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationIdentityContext = _context.Notes.Include(n => n.Notebook).Include(n => n.User);
            return View(await applicationIdentityContext
                                .Where(n => n.UserID == _userManager.GetUserId(User) && n.Notebook == null)
                                .OrderByDescending(n => n.LastModified)
                                .ToListAsync());
        }

        // GET: Notes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes
                .Include(n => n.Notebook)
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NoteID == id);

            var creator = await _context.Users.FirstOrDefaultAsync(n => n.Id == note.UserID);

            if (note == null)
            {
                return NotFound();
            }

            if (!note.IsPublic && note.UserID != _userManager.GetUserId(User))
            {
                return View("Restricted");
            }

            ViewData["UserID"] = _userManager.GetUserId(User);
            ViewData["Name"] = creator.UserName;
            return View(note);
        }

        // GET: Notes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(long? id)
        {
            if (User.Identity.IsAuthenticated)
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

                if (note.UserID != _userManager.GetUserId(User))
                {
                    return View("Restricted");
                }

                ViewData["NotebookID"] = new SelectList(_context.Notebooks, "NotebookID", "NotebookID", note.NotebookID);
                ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", note.UserID);
                return View(note);
            }
            return Redirect("./account/login");
        }

        // GET: Notes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes
                .Include(n => n.Notebook)
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NoteID == id);

            if (note == null)
            {
                return NotFound();
            }

            if (note.UserID != _userManager.GetUserId(User))
            {
                return View("Restricted");
            }

            return View(note);
        }

        #endregion HTTP GET

        #region HTTP POST

        [HttpPost]
        public async Task<IActionResult> CreateAsync()
        {
            var name = Request.Form["name"];
            bool ispublic = Request.Form["public"] == "on";

            Note note = new Note();
            note.Title = name;
            note.IsPublic = ispublic;
            note.LastModified = DateTime.Now;
            note.UserID = _userManager.GetUserId(User);
            note.NotebookID = null;
            note.Text = "";
            note.HTML = "";
            note.Order = 0;

            _context.Add(note);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { Id = note.NoteID });
        }

        // POST: Notes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("NoteID,Title,IsPublic,Text")] Note note)
        {
            if (id != note.NoteID)
            {
                return NotFound();
            }

            note.LastModified = DateTime.Now;
            note.UserID = _userManager.GetUserId(User);
            note.NotebookID = null;
            note.HTML = Markdown.Convert(note.Text.Split(
                                    new[] { "\r\n", "\r", "\n" },
                                    StringSplitOptions.None
                                    ).ToList<string>());
            note.Order = 0;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.NoteID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = note.NoteID });
            }
            ViewData["NotebookID"] = new SelectList(_context.Notebooks, "NotebookID", "NotebookID", note.NotebookID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", note.UserID);
            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note.UserID != _userManager.GetUserId(User))
            {
                return View("Restricted");
            }
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region HELPER METHODS

        private bool NoteExists(long id)
        {
            return _context.Notes.Any(e => e.NoteID == id);
        }

        #endregion
    }
}
