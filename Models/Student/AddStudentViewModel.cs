using Student1.Models.Teacher;

namespace Student1.Models.Student
{
    public class AddStudentViewModel : AddPerson // tinh ke thua
    {
        public string Lop { get; set; } = string.Empty;
        public double Diem { get; set; }

        public override string getName() // Override tinh da hinh
        {
            return FirstName + " " + LastName;
        }
        public void Inratitle()
        {
            Console.WriteLine("Title: "+ decade);// tinh dong goi
        }
    }
}
