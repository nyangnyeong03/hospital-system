using Microsoft.AspNetCore.Mvc;
using CahwciHospital.Models;
using System.Collections.Generic;
using System.Linq;

namespace CahwciHospital.Controllers
{
    public class DoctorsController : Controller
    {
        private static List<Doctor> _doctors = new List<Doctor>
        {
            new Doctor { Id = 1, FullName = "Dr. Maria Reyes", Specialty = "Cardiology", Gender = "Female", ContactNumber = "09123456789" },
            new Doctor { Id = 2, FullName = "Dr. Juan Cruz", Specialty = "Pediatrics", Gender = "Male", ContactNumber = "09187654321" },
            new Doctor { Id = 3, FullName = "Dr. Antonio Santos", Specialty = "General Medicine", Gender = "Male", ContactNumber = "09234567890" }
        };

        public IActionResult Index()
        {
            return View(_doctors);
        }

        // GET - Show Create Form
        public IActionResult Create()
        {
            return View();
        }

        // POST - Save New Doctor
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctor.Id = _doctors.Any() ? _doctors.Max(d => d.Id) + 1 : 1;
                _doctors.Add(doctor);
                return RedirectToAction("Index");
            }
            return View(doctor);
        }
    }
}