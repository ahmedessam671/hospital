using Hospital.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Areas.DoctorArea.Controllers
{

        [Area("Doctors")]
        public class AppointmentsController : Controller
        {
            private readonly AppDbContext _context;
            public AppointmentsController(AppDbContext context) => _context = context;

            public async Task<IActionResult> MyAppointments(int doctorId)
            {
                var appts = await _context.Appointments
                    .Include(a => a.Patient)
                    .Include(a => a.Clinic)
                    .Where(a => a.DoctorId == doctorId)
                    .ToListAsync();
                return View(appts);
            }

            // Confirm / Cancel actions can be added
        }
}


