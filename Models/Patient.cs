using System.ComponentModel.DataAnnotations;

namespace CahwciHospital.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Display(Name = "Patient ID")]
        public string? PatientId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [Required]
        public string Sex { get; set; } = string.Empty;

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}