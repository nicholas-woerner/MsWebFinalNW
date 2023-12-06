using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MsWebFinalNW.Data;
using MsWebFinalNW.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MsWebFinalNW.Controllers
{
    public class BooksController : Controller
    {
        private readonly DbContextApp _context;

        public BooksController(DbContextApp context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var books = from b in _context.Books
                        select b;

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title.Contains(searchString));
            }

            return View(await books.ToListAsync());
        }
    }
}