using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;
using System;
using dotnet_vite_react;
using System.Linq;
using dotnet_vite_vuejs.Model;
using Microsoft.AspNetCore.Http;
using System.Drawing.Text;

namespace dotnet_vite_vuejs.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class Test : ControllerBase
    {
        private IServiceProvider _services;

        public Test(IServiceProvider services)
        {
            _services = services;
        }

        [HttpGet("{name}")]
        
        public IActionResult post([FromRoute] string name)
        {
            using (var context = _services.GetService<Context>())
            {
                if (context != null)
                {
                    Persons person = new Persons()
                    {
                        PersonId = Guid.NewGuid(),
                        LastName = "Nguyen",
                        FirstName = name,
                        Address = "VietNam",
                        City = "DN"
                    };
                    context.Add(person);
                    context.SaveChanges();
                }
            }
            return Content("test ");
        }
    }
}

[Route("[controller]/[action]")]
public class Name : ControllerBase
{
    [HttpGet]
    public IActionResult get()
    {
        return Content("binh ");
    }
}

