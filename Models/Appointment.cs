using System.ComponentModel.DataAnnotations;

namespace CahwciHospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string? PatientName { get; set; }

        public string? DoctorName { get; set; }

        public string? Department { get; set; }

        // These are the properties that your views and controller are looking for
        public DateTime Date { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public string? Status { get; set; }

        public string? Reason { get; set; }
    }
}