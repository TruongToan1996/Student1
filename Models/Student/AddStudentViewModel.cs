

using System.ComponentModel.DataAnnotations;

namespace Student1.Models.Student
{
    public class AddStudentViewModel : AddPerson // tinh ke thua
    {
        public string Lop { get; set; } = string.Empty;
        [Range(0, 10)]
        [Required]
        public double Diem { get; set; }

        public override string getName() // Override tinh da hinh
        {
            return FirstName + " " + LastName;
        }
        
    }
}
