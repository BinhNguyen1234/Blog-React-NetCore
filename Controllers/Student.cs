﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Model = dotnet_vite_react.Model;
using Microsoft.AspNetCore.Routing;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text.Json;
using dotnet_vite_react.Model;
using dotnet_vite_react.AppContext;
using dotnet_vite_react.UnitOfWorkApp;

namespace dotnet_vite_react.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class Student : Controller
    {
        private IServiceProvider _services;
        private UnitOfWork _unitOfWork;

        public Student(IServiceProvider services, UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _services = services;
        }

        [HttpGet]
        [Route("{name}")]
        [ActionName("info")]
        public IActionResult getInfo([FromRoute] string? name)
        {
            using (var context = _services.GetService<PoolContext>())
            {
                if (context != null)
                {
                    Model.Student newStudent = new ()
                    {
                        FirstName = "Binh",
                        LastName = "Nguyen"
                    };
                    context.Add(newStudent);
                    context.SaveChanges();
                    return Content("name: " + name);
                }
                else return UnprocessableEntity();
            }

        }
        [HttpPost]
        [ActionName("create")]
        public async Task<IActionResult> postInfo([FromBody] object body)
        {
            Request.Body.Position = 0;
            var reader = await new StreamReader(Request.Body, Encoding.UTF8).ReadToEndAsync();
            dynamic content = JsonConvert.DeserializeObject(reader);
            return Content(content.First.name);
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
                    Model.Course course = new()
                    {
                        Title = body.TitleCourse,
                        Credits = body.Credits
                    };
                    Model.Student student = new()
                    {
                        LastName = body.LastName,
                        FirstName = body.FirstName,
                        EnrollmentDate = DateTime.Now,
                    };
                    Model.Enrollment enrollment = new()
                    {
                        Grade = body.Grade,
                        Course = course,
                        Student = student
                    };
                    _unitOfWork.Add(student);
                    _unitOfWork.Add(enrollment);
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