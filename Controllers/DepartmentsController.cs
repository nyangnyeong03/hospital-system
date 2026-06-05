using Microsoft.AspNetCore.Mvc;
using CahwciHospital.Models;
using System.Collections.Generic;
using System.Linq;

namespace CahwciHospital.Controllers
{
    public class DepartmentsController : Controller
    {
        private static List<Department> _departments = new List<Department>
        {
            new Department { Id = 1, DepartmentName = "Heart and Cardiovascular Care", Description = "Specialized in cardiology and heart diseases", HeadDoctor = "Dr. Maria Reyes" },
            new Department { Id = 2, DepartmentName = "Child Healthcare", Description = "Pediatrics and child wellness", HeadDoctor = "Dr. Juan Cruz" },
            new Department { Id = 3, DepartmentName = "General Health Services", Description = "General medicine and primary care", HeadDoctor = "Dr. Antonio Santos" }
        };

        public IActionResult Index()
        {
            return View(_departments);
        }

        public IActionResult Details(int id)
        {
            var department = _departments.FirstOrDefault(d => d.Id == id);
            if (department == null) return NotFound();
            return View(department);
        }

        public IActionResult Edit(int id)
        {
            var department = _departments.FirstOrDefault(d => d.Id == id);
            if (department == null) return NotFound();
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var existing = _departments.FirstOrDefault(d => d.Id == id);
                if (existing != null)
                {
                    existing.DepartmentName = department.DepartmentName;
                    existing.Description = department.Description;
                    existing.HeadDoctor = department.HeadDoctor;
                }
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                department.Id = _departments.Any() ? _departments.Max(d => d.Id) + 1 : 1;
                _departments.Add(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }
    }
}