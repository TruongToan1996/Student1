using Microsoft.EntityFrameworkCore;
using Student1.Models.Student;
using Student1.Models.Teacher;

namespace Student1.Data
{
    public class DbContextStudent : DbContext
    {
        public DbContextStudent(DbContextOptions options) : base(options) { }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
    }
}
