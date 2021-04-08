using System;
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
    public class NotesController : Controller
    {
        private readonly ApplicationIdentityContext _context;
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;

        public NotesController(ApplicationIdentityContext context, 
               UserManager<ApplicationUser> userMgr,
               SignInManager<ApplicationUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            _context = context;
        }

        // GET: Notes
        public async Task<IActionResult> Index()
        {
            var applicationIdentityContext = _context.Notes.Include(n => n.Notebook).Include(n => n.User);
            return View(await applicationIdentityContext.Where(n => n.UserID == userManager.GetUserId(User)).ToListAsync());
        }

        // GET: Notes/Details/5
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
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoteID,Title,IsPublic,Text,HTML,Order")] Note note)
        {
            note.LastModified = DateTime.Now;
            note.UserID = userManager.GetUserId(User);
            note.NotebookID = null;

            if (ModelState.IsValid)
            {
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NotebookID"] = new SelectList(_context.Notebooks, "NotebookID", "NotebookID", note.NotebookID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", note.UserID);
            return View(note);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(long? id)
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
            ViewData["NotebookID"] = new SelectList(_context.Notebooks, "NotebookID", "NotebookID", note.NotebookID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", note.UserID);
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("NoteID,NotebookID,UserID,Title,IsPublic,Text,HTML,Order,LastModified")] Note note)
        {
            if (id != note.NoteID)
            {
                return NotFound();
            }

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
                return RedirectToAction(nameof(Index));
            }
            ViewData["NotebookID"] = new SelectList(_context.Notebooks, "NotebookID", "NotebookID", note.NotebookID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", note.UserID);
            return View(note);
        }

        // GET: Notes/Delete/5
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

            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var note = await _context.Notes.FindAsync(id);
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(long id)
        {
            return _context.Notes.Any(e => e.NoteID == id);
        }
    }
}
