using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Routing;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using dotnet_vite_react.Model;
using dotnet_vite_react.UnitOfWorkApp;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using dotnet_vite_react.AppContext;

namespace dotnet_vite_react.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class Student : Controller
    {
        private IServiceProvider _services;
        private UnitOfWork _unitOfWork;
        private event test ttttt;
        private delegate void test(string name);
        private Context ctx;
        private void ttqwe(string name) {
            Console.WriteLine(name);
        }
        public Student(IServiceProvider services, UnitOfWork unitOfWork, Context ctx)
        {
            ttttt = ttqwe;
            _unitOfWork = unitOfWork;
            _services = services;
            this.ctx = ctx;
            Console.WriteLine("Student Controller ");
        }

        [HttpGet]
        [Route("{name}")]
        [ActionName("info")]
        public IActionResult getInfo([FromRoute] string? name)
        {

            //var student = _unitOfWork.GetRepo<StudentEntity>()?.dbSet.Select(x => x.LastName);

            IEnumerable<Guid> student = (IEnumerable<Guid>)ctx.Persons.Select(x => x.StudentID);
            Console.WriteLine("ffffff");
            Console.WriteLine("gggggggg");
            if (student != null)
            {
                foreach(  Guid studentEntity in student) { 
                    Console.WriteLine(studentEntity.ToString());
                }
            }
            if (student != null)
            {
                foreach (Guid studentEntity in student)
                {
                    Console.WriteLine(studentEntity.ToString());
                }
            }

            return Content("OK");

        }
        [HttpPost]
        [ActionName("create")]
        public async Task<IActionResult> postInfo([FromBody] object body)
        {
            IQueryable<StudentEntity>? student2 = _unitOfWork.GetRepo<StudentEntity>()?.dbSet.Where(x => x.LastName == "string").Include(s => s.Enrollments);
            if (student2 != null)
            {
                foreach (var item in student2)
                {
                    
                }
            }
            Request.Body.Position = 0;
            string reader = await new StreamReader(Request.Body, Encoding.UTF8).ReadToEndAsync();

         
            return Content("OK");
        }
    }
    [Route("[controller]/[action]")]
    public class Course : ControllerBase
    {
        private IServiceProvider _service;
        private UnitOfWork _unitOfWork;
        public Course(
            IServiceProvider service,
            UnitOfWork unitOfWork
            ) {  
            _unitOfWork = unitOfWork;
            _service = service;
            Console.WriteLine("Student Controller ");
        }
        [HttpPost]
        [ActionName("register")]
        public IActionResult registerCourse([FromBody] RegisterForm body)
        {
            try
            {
                //using (var context = _service.GetService<PoolContext>())
                //{
                //    Model.Course course = new()
                //    {
                //        Title = body.TitleCourse,
                //        Credits = body.Credits
                //    };
                //    Model.Student student = new()
                //    {
                //        LastName = body.LastName,
                //        FirstName = body.FirstName,
                //        EnrollmentDate = DateTime.Now,
                //    };
                //    Model.Enrollment enrollment = new()
                //    {
                //        Grade = body.Grade,
                //        Course = course,
                //        Student = student
                //    };
                    
                //    if (context != null)
                //    {
                //        context.Add(course);
                //        context.Add(enrollment);
                //        context.Add(student);
                //        context.SaveChanges();
                //        return Content("Sucess");
                //    } else
                //    {
                //        return NotFound("faild");
                //    }
                 

                //}
                using (_unitOfWork)
                {
                    CourseEntity course = new()
                    {
                        Title = body.TitleCourse,
                        Credits = body.Credits
                    };
                    StudentEntity student = new()
                    {
                        LastName = body.LastName,
                        FirstName = body.FirstName,
                        EnrollmentDate = DateTime.Now,
                    };
                    EnrollmentEntity enrollment = new()
                    {
                        Grade = body.Grade,
                        Course = course,
                        Student = student
                    };
                    _unitOfWork.Add(student);
                    _unitOfWork.GetRepo<EnrollmentEntity>()?.Add(enrollment);
                    
                    _unitOfWork.Add(course);
                    _unitOfWork.SaveChages();
                }
                return Content("Sucess");
            } catch (Exception ex)
            {
                return NotFound(ex.ToString());
            }

            
        }

    }
}

public class RegisterForm
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string TitleCourse { get; set; }
    public required string Credits { get; set; }
    public required string Grade { get; set; }
}
