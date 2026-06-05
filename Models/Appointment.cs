namespace CahwciHospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string PatientName { get; set; } = string.Empty;

        public string PreferredDoctor { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public DateTime PreferredDate { get; set; }

        public string Status { get; set; } = "Scheduled";

     
        public string? DoctorName { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? Reason { get; set; }
    }
}