using Student1.Models.Student;
using System.ComponentModel.DataAnnotations;

namespace Student1.Models
{
    public abstract class Person
    {
        [Required]
        public Guid Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }

      
    }
}
