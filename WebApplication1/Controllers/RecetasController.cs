using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class RecetasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecetasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View();
        public IActionResult Login() => View();
        public IActionResult Register() => View();
        public IActionResult Menu() => View();

        public IActionResult PlatosFuertes() 
        {
            var model = _context.Recetas.Where(r => r.Categoria == "Platosfuertes").ToList();
            return View(model);
        }
        
        public IActionResult Snacks() 
        {
            var model = _context.Recetas.Where(r => r.Categoria == "Snacks").ToList();
            return View(model);
        }
        
        public IActionResult Bebidas() 
        {
            var model = _context.Recetas.Where(r => r.Categoria == "Bebidas").ToList();
            return View(model);
        }
        
        public IActionResult Postres() 
        {
            var model = _context.Recetas.Where(r => r.Categoria == "Postres").ToList();
            return View(model);
        }
        
        public IActionResult Pasabocas() 
        {
            var model = _context.Recetas.Where(r => r.Categoria == "Pasabocas").ToList();
            return View(model);
        }
    }
}