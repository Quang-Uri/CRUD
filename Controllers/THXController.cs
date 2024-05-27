using Microsoft.AspNetCore.Mvc;
using Web_CRUD.Entities;

namespace Web_CRUD.Controllers
{
    public class THXController : Controller
    {
        // GET: /THX/Index
        public IActionResult Index()
        {
            return View();
        }

        // POST: /THX/Search
        [HttpPost]
        public IActionResult Search(int IdTinh, int IdHuyen, int IdXa, string Ten)
        {
            // Perform the search logic here
            // For demonstration, let's assume we just return the search criteria

            ViewBag.IdTinh = IdTinh;
            ViewBag.IdHuyen = IdHuyen;
            ViewBag.IdXa = IdXa;
            ViewBag.Ten = Ten;

            return View("SearchResults");
        }
    }
}
