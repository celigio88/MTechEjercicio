using System.ComponentModel.DataAnnotations;
namespace Backend.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string RFC { get; set; } = string.Empty;
        [Required]
        public DateTime BornDate { get; set; }
        public EmployeeStatus Status { get; set; }
    }

    public enum EmployeeStatus 
    { 
        NotSet, 
        Active, 
        Inactive,
    }
}