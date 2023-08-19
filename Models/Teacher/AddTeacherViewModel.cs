namespace Student1.Models.Teacher
{
    public class AddTeacherViewModel : AddPerson
    {
        public string Subject { get; set; }
        private string Title { get; set; } = "Master ";
        public override string getName()
        {
            return Title + FirstName +" "+ LastName ;
        }
    }
}
