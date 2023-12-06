using Microsoft.AspNetCore.Mvc;
using MsWebFinalNW.Data;
using MsWebFinalNW.Models;
using System.Linq;

namespace MsWebFinalNW.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbContextApp _context;

        public HomeController(DbContextApp context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DBVisual()
        {
            var model = new DBVisualViewModel
            {
                Books = _context.Books.ToList()
            };

            return View(model);
        }
    }
}
