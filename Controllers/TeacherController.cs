using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Student1.Data;
using Student1.Models.Teacher;

namespace Student1.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DbContextStudent dbContextStudent;
        public TeacherController(DbContextStudent dbContextStudent)
        {
            this.dbContextStudent = dbContextStudent;
        }

        public async Task<IActionResult> Index()
        {
            List<TeacherModel> teacherModels = await dbContextStudent.Teachers.ToListAsync();
            return View(teacherModels);
        }
        [HttpGet]
        public async Task<IActionResult> Index(string SearchString)
        {
            List<TeacherModel> teachers = new();
            if (string.IsNullOrEmpty(SearchString))
            {
                teachers = await dbContextStudent.Teachers.ToListAsync();
            }
            else
            {
                teachers = await dbContextStudent.Teachers.Where(item => item.Name.Contains(SearchString)).ToListAsync(); 
            }
            return View(teachers);
        }

      
        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTeacher (AddTeacher addTeacher)
        {
            var teacher = new TeacherModel()
            {
                Id = Guid.NewGuid(),
                Name = addTeacher.Name,
                DateOfBirth = addTeacher.DateOfBirth,
                Subject = addTeacher.Subject,
                Age = addTeacher.Age,
            };
            await dbContextStudent.Teachers.AddAsync(teacher);
            await dbContextStudent.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> ViewTeacher(Guid id)
        {
            var teacher = await dbContextStudent.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if(teacher != null)
            {
                UpdateTeacherModel viewTeacherModel = new UpdateTeacherModel()
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    DateOfBirth=teacher.DateOfBirth,
                    Subject = teacher.Subject,
                    Age = teacher.Age,
                };
                return await Task.Run(() => View("ViewTeacher", viewTeacherModel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> ViewTeacher(UpdateTeacherModel update)
        {
            var teacher = await dbContextStudent.Teachers.FindAsync(update.Id);
            if(teacher != null)
            {
                teacher.Name = update.Name;
                teacher.DateOfBirth = update.DateOfBirth;
                teacher.Subject = update.Subject;
                teacher.Age = update.Age;

                await dbContextStudent.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete (UpdateTeacherModel model)
        {
            var teacher = await dbContextStudent.Teachers.FindAsync(model.Id);
            if (teacher != null)
            {
                dbContextStudent.Teachers.Remove(teacher);
                await dbContextStudent.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
