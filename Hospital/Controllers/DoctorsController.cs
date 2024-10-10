using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class DoctorsController : Controller
    {
        private List<Doctor> doctors = new List<Doctor>
        {
            new Doctor { Id = 1, Name = "Dr. John Smith", Specialization = "Cardiology", Img = "doctor1.jpg" },
            new Doctor { Id = 4, Name = "Dr. Michael Lee", Specialization = "Orthopedics", Img = "doctor4.jpg" },
            new Doctor { Id = 2, Name = "Dr. Sarah Johnson", Specialization = "Pediatrics", Img = "doctor3.jpg" },
            new Doctor { Id = 5, Name = "Dr. William Clark", Specialization = "Neurology", Img = "doctor2.jpg" },
            new Doctor { Id = 3, Name = "Dr. Emily Davis", Specialization = "Dermatology", Img = "doctor5.jpg" }
        };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BookAppointment() 
        {
            return View(model: doctors);
        }
        public IActionResult CompleteAppointment(string name)
        {
            var doctor = doctors.FirstOrDefault(e=>e.Name == name);
            return View(doctor);
        }

        [HttpPost]
        public IActionResult CompleteAppointment(string name, string patientName, DateTime appointmentDate, TimeSpan appointmentTime)
        {
            ViewBag.SuccessMessage = $"Your appointment with {name} has been successfully completed.";
            return View("CompleteAppointment", doctors.FirstOrDefault(e => e.Name == name));
        }

    }
}
