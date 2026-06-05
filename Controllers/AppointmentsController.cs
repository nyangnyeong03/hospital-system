using Microsoft.AspNetCore.Mvc;
using CahwciHospital.Models;
using System.Collections.Generic;
using System.Linq;

namespace CahwciHospital.Controllers
{
    public class AppointmentsController : Controller
    {
        private static List<Appointment> _appointments = new List<Appointment>
        {
            new Appointment
            {
                Id = 1,
                PatientName = "Juan Dela Cruz",
                PreferredDoctor = "Dr. Maria Reyes",
                Department = "Cardiology",
                PreferredDate = DateTime.Now.AddDays(7),
                Status = "Scheduled"
            }
        };

        public IActionResult Index()
        {
            return View(_appointments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.Id = _appointments.Any() ? _appointments.Max(a => a.Id) + 1 : 1;
                _appointments.Add(appointment);
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        public IActionResult Edit(int id)
        {
            var appointment = _appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Appointment appointment)
        {
            if (id != appointment.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var existing = _appointments.FirstOrDefault(a => a.Id == id);
                if (existing != null)
                {
                    existing.PatientName = appointment.PatientName;
                    existing.PreferredDoctor = appointment.PreferredDoctor;
                    existing.Department = appointment.Department;
                    existing.PreferredDate = appointment.PreferredDate;
                    existing.Status = appointment.Status;
                }
                return RedirectToAction("Index");
            }
            return View(appointment);
        }
    }
}