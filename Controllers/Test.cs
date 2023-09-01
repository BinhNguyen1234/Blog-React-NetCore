using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;
using System;
using dotnet_vite_react;
using System.Linq;
using Model = dotnet_vite_react.Model;
using Microsoft.AspNetCore.Http;
using System.Drawing.Text;
using Microsoft.AspNetCore.Routing;

namespace dotnet_vite_react.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class Student : ControllerBase
    {
        private IServiceProvider _services;

        public Student(IServiceProvider services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("{name}")]
        [ActionName("info")]
        public IActionResult post([FromRoute] string? name)
        {
            using (var context = _services.GetService<Context>())
            {
                if (context != null)
                {
                    Model.Student newStudent = new Model.Student()
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
    }
}

[Route("[controller]/[action]")]
public class Name : ControllerBase
{
    [HttpGet("{name}")]
    public IActionResult get([FromRoute] string name)
    {
        return Content("name: " + name);
    }
}

