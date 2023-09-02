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
using System.IO;
using System.Threading.Tasks;
using System.Text;

namespace dotnet_vite_react.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class Student : Controller
    {
        private IServiceProvider _services;

        public Student(IServiceProvider services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("{name}")]
        [ActionName("info")]
        public IActionResult getInfo([FromRoute] string? name)
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
        [HttpPost]
        [ActionName("create")]
        public async Task<IActionResult> postInfo([FromBody] string body)
        {
            Request.Body.Position = 0;
            var reader = await new StreamReader(Request.Body,Encoding.UTF8).ReadToEndAsync();
            return Content(reader);
        }
    }
}

[Route("[controller]/[action]")]
public class Course : ControllerBase
{
    [HttpPost]
    public IActionResult get([FromRoute] string name)
    {
        return Content("name: " + name);
    }
}

