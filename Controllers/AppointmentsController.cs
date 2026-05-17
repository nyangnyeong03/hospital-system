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
                DoctorName = "Dr. Maria Reyes",
                Department = "Cardiology",
                Date = DateTime.Now.AddDays(2),
                Status = "Scheduled",
                Reason = "Routine Check-up"
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
    }
}