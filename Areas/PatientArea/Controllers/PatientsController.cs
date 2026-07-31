using Hospital.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Areas.PatientArea.Controllers
{
    [Area("Patients")]
    public class RegisterController : Controller
    {
        private readonly AppDbContext _context;
        public RegisterController(AppDbContext context) => _context = context;

        public IActionResult Index() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Patient patient)
        {
            if (!ModelState.IsValid) return View(patient);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction("Welcome", "Home", new { area = "" });
        }
    }

}
