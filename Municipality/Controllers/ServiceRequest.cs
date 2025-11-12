using Microsoft.AspNetCore.Mvc;
using Municipality.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Municipality.Controllers
{
    public class ServiceRequestController : Controller
    {
        private readonly MunicipalServicesDbContext _context;

        public ServiceRequestController(MunicipalServicesDbContext context)
        {
            _context = context;
        }

        // GET: ServiceRequest
        public async Task<IActionResult> Index()
        {
            var serviceRequests = await _context.ServiceRequests.ToListAsync();
            return View(serviceRequests);
        }

        // GET: ServiceRequest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var serviceRequest = await _context.ServiceRequests.FirstOrDefaultAsync(m => m.Id == id);
            if (serviceRequest == null)
                return NotFound();

            return View(serviceRequest);
        }

        // GET: ServiceRequest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,RequestDate,Status")] ServiceRequest serviceRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceRequest);
        }

        // GET: ServiceRequest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
                return NotFound();

            return View(serviceRequest);
        }

        // POST: ServiceRequest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,RequestDate,Status")] ServiceRequest serviceRequest)
        {
            if (id != serviceRequest.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceRequest);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.ServiceRequests.Any(e => e.Id == serviceRequest.Id))
                        return NotFound();
                    else
                        throw;
                }
            }
            return View(serviceRequest);
        }
    }
}
