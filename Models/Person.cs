using Student1.Models.Student;

namespace Student1.Models
{
    public abstract class Person
    {

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }

      
    }
}
