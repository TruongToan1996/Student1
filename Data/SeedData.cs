using Microsoft.EntityFrameworkCore;
using Student1.Models.Student;
using Student1.Models.Teacher;

namespace Student1.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DbContextStudent(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DbContextStudent>>()))
            {
                //// Look for any movies.
                //if (context.Students.Any())
                //{
                //    return;   // DB has been seeded
                //}
                //context.Students.AddRange(
                //    new StudentModel
                //    {
                //        Name = "Harry",
                //        DateOfBirth = DateTime.Parse("1989-2-12"),
                //        Lop = "Romantic Comedy",
                //        Diem =7,
                //        Id = Guid.NewGuid(),
                //    },
                //    new StudentModel
                //    {
                //        Name = "Harry2",
                //        DateOfBirth = DateTime.Parse("1989-2-12"),
                //        Lop = "Romantic Comedy",
                //        Diem =8,
                //        Id = Guid.NewGuid(),
                //    },
                //    new StudentModel
                //    {
                //        Name = "Harry8",
                //        DateOfBirth = DateTime.Parse("1989-2-12"),
                //        Lop = "Romantic Comedy",
                //        Diem =8,
                //        Id = Guid.NewGuid(),
                //    },
                //    new StudentModel
                //    {
                //        Name = "Harry9",
                //        DateOfBirth = DateTime.Parse("1989-2-12"),
                //        Lop = "Romantic Comedy",
                //        Diem =9,
                //        Id = Guid.NewGuid(),
                //    }
                   
                //);
                //context.SaveChanges();
                if ( context.Teachers.Any() )
                {
                    return;
                }
                context.Teachers.AddRange(
                    new TeacherModel
                    {
                        Id = Guid.NewGuid(),
                        Name = " Toan",
                        DateOfBirth = DateTime.Parse("1996-12-24"),
                        Subject = "Van",
                        Age = 22,
                    },
                    new TeacherModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Son",
                        DateOfBirth = DateTime.Parse("2001-01-01"),
                        Subject = "Anh",
                        Age=18,
                    },
                    new TeacherModel
                     {
                         Id = Guid.NewGuid(),
                         Name = "Nguyen",
                         DateOfBirth = DateTime.Parse("1991-12-12"),
                         Subject = "Dia",
                         Age = 19,
                     }

                    );
                context.SaveChanges();
            }
           using (var context = new DbContextStudent(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DbContextStudent>>()))
            {
                // Look for any movies.
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }
                context.Students.AddRange(
                    new StudentModel
                    {
                        Name = "Harry",
                        DateOfBirth = DateTime.Parse("1989-2-12"),
                        Lop = "Romantic Comedy",
                        Diem = 7,
                        Id = Guid.NewGuid(),
                    },
                    new StudentModel
                    {
                        Name = "Harry2",
                        DateOfBirth = DateTime.Parse("1989-2-12"),
                        Lop = "Romantic Comedy",
                        Diem = 8,
                        Id = Guid.NewGuid(),
                    },
                    new StudentModel
                    {
                        Name = "Harry8",
                        DateOfBirth = DateTime.Parse("1989-2-12"),
                        Lop = "Romantic Comedy",
                        Diem = 8,
                        Id = Guid.NewGuid(),
                    },
                    new StudentModel
                    {
                        Name = "Harry9",
                        DateOfBirth = DateTime.Parse("1989-2-12"),
                        Lop = "Romantic Comedy",
                        Diem = 9,
                        Id = Guid.NewGuid(),
                    }

                );
                context.SaveChanges();

            }
        }
    }
}
