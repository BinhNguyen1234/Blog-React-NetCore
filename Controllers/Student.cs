using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using dotnet_vite_react;
using System.Linq;
using Model = dotnet_vite_react.Model;
using Microsoft.AspNetCore.Routing;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text.Json;

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
        [HttpPost]
        [ActionName("register")]
        public IActionResult registerCourse([FromBody] Bodyy body)
        {


            return Content("name: " + body.name);
        }

    }
     public class Bodyy
    {
        public required string name { get; set; }
    }
}

