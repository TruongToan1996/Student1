using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student1.Data;
using Student1.Models.Student;
using Student1.Models.Teacher;

namespace Student1.Controllers
{
    public class StudentController : Controller

    {
        private readonly DbContextStudent dbContextStudent;
        public StudentController(DbContextStudent dbContextStudent)
        {
            this.dbContextStudent = dbContextStudent;
        }

        public async Task<IActionResult> Index() //list students
        {
            List<StudentModel> students = await dbContextStudent.Students.ToListAsync();

            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Index(string SearchString,bool IsUnique) //list students
        {
            List<StudentModel> students = new List<StudentModel>();
            if (!string.IsNullOrEmpty(SearchString)) // SearchString == null || SearchString ==""
            {
                if (IsUnique)
                {
                    students = await dbContextStudent.Students.Where(item => item.Name.Equals(SearchString)).ToListAsync();

                }
                else
                {
                    students = await dbContextStudent.Students.Where(item => item.Name.Contains(SearchString)).ToListAsync();

                }
            }
            else
            {
                students = await dbContextStudent.Students.ToListAsync();
               
            }
            

            return View(students);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel addStudentRequest)
        {
            var  student = new StudentModel()
            {
                Id = Guid.NewGuid(),
                Name = addStudentRequest.getName(),
                Lop = addStudentRequest.Lop,
                Diem = addStudentRequest.Diem,
                DateOfBirth = addStudentRequest.DateOfBirth,
            };
            if (ModelState.IsValid)
            {
                

                await dbContextStudent.Students.AddAsync(student);
                await dbContextStudent.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(addStudentRequest);
            }
           
        }



        [HttpGet]
        public async Task<IActionResult> View(Guid id,string name) //view Detail
        {
            var student = await dbContextStudent.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student != null)
            {
                UpdateStudentViewModel viewModel = new UpdateStudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Lop = student.Lop,
                    Diem = student.Diem,
                    DateOfBirth = student.DateOfBirth,
                };
                return await Task.Run(() => View("View", viewModel));

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateStudentViewModel update) // update
        {
            var student = await dbContextStudent.Students.FindAsync(update.Id);
            if(student != null)
            {
                student.Name = update.Name;
                student.Lop = update.Lop;
                student.Diem = update.Diem;
                student.DateOfBirth = update.DateOfBirth;

                await dbContextStudent.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
       
        [HttpPost]
        public async Task<IActionResult> Delete (UpdateStudentViewModel update)
        {
            var student = await dbContextStudent.Students.FindAsync(update.Id);
            if (student != null)
            {
                dbContextStudent.Remove(student);
                await dbContextStudent.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
