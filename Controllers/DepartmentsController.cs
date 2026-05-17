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
            new Department { Id = 1, Name = "Cardiology", Description = "Heart and Cardiovascular Care", HeadDoctor = "Dr. Maria Reyes" },
            new Department { Id = 2, Name = "Pediatrics", Description = "Child Healthcare", HeadDoctor = "Dr. Juan Cruz" },
            new Department { Id = 3, Name = "General Medicine", Description = "General Health Services", HeadDoctor = "Dr. Antonio Santos" }
        };

        public IActionResult Index()
        {
            return View(_departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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