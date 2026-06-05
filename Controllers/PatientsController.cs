using Microsoft.AspNetCore.Mvc;
using CahwciHospital.Models;
using System.Collections.Generic;
using System.Linq;

namespace CahwciHospital.Controllers
{
    public class PatientsController : Controller
    {
        private static List<Patient> _patients = new List<Patient>
        {
            new Patient { Id = 1, FullName = "Juan Dela Cruz", Sex = "Male", Age = 45, Address = "Antipolo City" },
            new Patient { Id = 2, FullName = "Maria Santos", Sex = "Female", Age = 32, Address = "Cainta, Rizal" },
            new Patient { Id = 3, FullName = "Jose Rizal", Sex = "Male", Age = 28, Address = "Calamba, Laguna" }
        };

        public IActionResult Index()
        {
            return View(_patients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.Id = _patients.Any() ? _patients.Max(p => p.Id) + 1 : 1;
                _patients.Add(patient);
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // EDIT - GET
        public IActionResult Edit(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // EDIT - POST
        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                var existing = _patients.FirstOrDefault(p => p.Id == patient.Id);
                if (existing != null)
                {
                    existing.FullName = patient.FullName;
                    existing.Sex = patient.Sex;
                    existing.Age = patient.Age;
                    existing.Address = patient.Address;
                }
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }
    }
}