namespace Student1.Models
{
    public abstract class AddPerson //abstract => tinh truu tuong
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        private string Title { get; set; } // tinh dong goi
        protected int decade { get; set; }// tinh dong goi
        public abstract string getName();
    }
}
