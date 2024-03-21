using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_ER_Core_MVC_Test.Data;
using ASP_ER_Core_MVC_Test.Models;

namespace ASP_ER_Core_MVC_Test.Controllers
{
    public class BobController : Controller
    {
        private readonly BobContext _context;

        public BobController(BobContext context)
        {
            _context = context;
        }

        // GET: Bob
        public async Task<IActionResult> Index()
        {
            var bobContext = _context.Bobs.Include(b => b.Brain);
            return View(await bobContext.ToListAsync());
        }

        // GET: Bob/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bobs == null)
            {
                return NotFound();
            }

            var bobModel = await _context.Bobs
                .Include(b => b.Brain)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bobModel == null)
            {
                return NotFound();
            }

            return View(bobModel);
        }

        // GET: Bob/Create
        public IActionResult Create()
        {
            ViewData["BrainID"] = new SelectList(_context.Brains, "ID", "ID");
            return View();
        }

        // POST: Bob/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,BrainID")] BobModel bobModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(bobModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["BrainID"] = new SelectList(_context.Brains, "ID", "ID", bobModel.BrainID);
                return View(bobModel);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                                         "Try again, and if the problem persists, " +
                                         "see your system administrator.");
                
                ViewData["BrainID"] = new SelectList(_context.Brains, "ID", "ID", bobModel.BrainID);
                return View(bobModel);
            }
        }

        // GET: Bob/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bobs == null)
            {
                return NotFound();
            }

            var bobModel = await _context.Bobs.FindAsync(id);
            if (bobModel == null)
            {
                return NotFound();
            }
            ViewData["BrainID"] = new SelectList(_context.Brains, "ID", "ID", bobModel.BrainID);
            return View(bobModel);
        }

        // POST: Bob/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var bobToEdit = await _context.Bobs.FirstOrDefaultAsync(b => b.ID == id);
            var canUpdate = await TryUpdateModelAsync<BobModel>(
                bobToEdit,
                "",
                b => b.Name,
                b => b.BrainID);

            if (canUpdate)
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                                             "Try again, and if the problem persists, " +
                                             "see your system administrator.");
                }
            }
            
            ViewData["BrainID"] = new SelectList(_context.Brains, "ID", "ID", bobToEdit.BrainID);
            return View(bobToEdit);
        }

        // GET: Bob/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bobs == null)
            {
                return NotFound();
            }

            var bobModel = await _context.Bobs
                .Include(b => b.Brain)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bobModel == null)
            {
                return NotFound();
            }

            return View(bobModel);
        }

        // POST: Bob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bobs == null)
            {
                return Problem("Entity set 'BobContext.Bobs'  is null.");
            }
            var bobModel = await _context.Bobs.FindAsync(id);
            if (bobModel != null)
            {
                _context.Bobs.Remove(bobModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BobModelExists(int id)
        {
          return (_context.Bobs?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
