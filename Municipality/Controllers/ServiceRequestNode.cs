using Microsoft.AspNetCore.Mvc;
using Municipality.Models;

namespace Municipality.Controllers
{
    public class ServiceRequestNodeController : Controller
    {
        private readonly ServiceRequestBST _bst;

        public ServiceRequestNodeController(ServiceRequestBST bst)
        {
            _bst = bst;
        }

        // GET: ServiceRequestNode
        public IActionResult Index()
        {
            // Show all requests (in-order traversal)
            var list = _bst.InOrder();
            return View(list);
        }

        // GET: ServiceRequestNode/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceRequestNode/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,RequestDate,Status")] ServiceRequest req)
        {
            if (ModelState.IsValid)
            {
                _bst.Insert(req);
                return RedirectToAction(nameof(Index));
            }
            return View(req);
        }
    }
}
