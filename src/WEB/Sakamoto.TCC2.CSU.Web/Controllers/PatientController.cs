using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sakamoto.TCC2.CSU.Web.Models;
using Sakamoto.TCC2.CSU.Web.Models.Patients;

namespace Sakamoto.TCC2.CSU.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly SakamotoTCC2CSUWebContext _context;

        public PatientController(SakamotoTCC2CSUWebContext context)
        {
            _context = context;
        }

        // GET: Patient/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterNewPatientViewModel patientViewModel)
        {
            if (ModelState.IsValid)
            {
                patientViewModel.Id = Guid.NewGuid();
                _context.Add(patientViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(patientViewModel);
        }

        // GET: Patient/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var patientViewModel = await _context.PatientViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientViewModel == null) return NotFound();

            return View(patientViewModel);
        }

        // GET: Patient/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var patientViewModel = await _context.PatientViewModel.FindAsync(id);
            if (patientViewModel == null) return NotFound();
            return View(patientViewModel);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UpdatePatientHeartRateViewModel patientViewModel)
        {
            if (id != patientViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientViewModelExists(patientViewModel.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(patientViewModel);
        }

        // GET: Patient
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientViewModel.ToListAsync());
        }

        private bool PatientViewModelExists(Guid id)
        {
            return _context.PatientViewModel.Any(e => e.Id == id);
        }
    }
}