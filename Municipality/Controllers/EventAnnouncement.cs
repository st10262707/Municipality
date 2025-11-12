using Microsoft.AspNetCore.Mvc;
using Municipality.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Municipality.Controllers
{
    public class EventAnnouncementController : Controller
    {
        private readonly MunicipalServicesDbContext _context;

        public EventAnnouncementController(MunicipalServicesDbContext context)
        {
            _context = context;
        }

        // GET: EventAnnouncement
        public async Task<IActionResult> Index()
        {
            var events = await _context.EventAnnouncements.ToListAsync();
            return View(events);
        }

        // GET: EventAnnouncement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var eventAnnouncement = await _context.EventAnnouncements
                .FirstOrDefaultAsync(m => m.EventId == id);

            if (eventAnnouncement == null)
                return NotFound();

            return View(eventAnnouncement);
        }

        // GET: EventAnnouncement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventAnnouncement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Date")] EventAnnouncement eventAnnouncement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventAnnouncement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventAnnouncement);
        }

        // GET: EventAnnouncement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var eventAnnouncement = await _context.EventAnnouncements.FindAsync(id);
            if (eventAnnouncement == null)
                return NotFound();

            return View(eventAnnouncement);
        }

        // POST: EventAnnouncement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Date")] EventAnnouncement eventAnnouncement)
        {
            if (id != eventAnnouncement.EventId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(eventAnnouncement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventAnnouncement);
        }

        // GET: EventAnnouncement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var eventAnnouncement = await _context.EventAnnouncements
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventAnnouncement == null)
                return NotFound();

            return View(eventAnnouncement);
        }

        // POST: EventAnnouncement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventAnnouncement = await _context.EventAnnouncements.FindAsync(id);
            if (eventAnnouncement != null)
            {
                _context.EventAnnouncements.Remove(eventAnnouncement);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
