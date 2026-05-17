namespace CahwciHospital.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? DepartmentName { get; set; }   // For other views
        public string? HeadDoctor { get; set; }
        public string? Description { get; set; }
    }
}