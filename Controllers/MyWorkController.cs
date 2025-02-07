using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using KhumalocraftEmporium_ST10069127_CLDV6211POE.Data;
using KhumalocraftEmporium_ST10069127_CLDV6211POE.Models;

namespace KhumalocraftEmporium_ST10069127_CLDV6211POE.Controllers
{
    public class MyWorkController : Controller
    {
        private readonly AppDbContext _context;

        public MyWorkController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch products from database
            var products = await _context.Products.ToListAsync();
            return View(products);
        }
    }
}
