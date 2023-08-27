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
    public class Test: ControllerBase
    {
        private IServiceProvider _services;
    
        public Test(IServiceProvider services)
        {
            _services = services;
        }

        public IActionResult post()
        {
            string? name = HttpContext.Request.RouteValues["name"]?.ToString();
           
            using (var context = _services.GetService<Context>())
            {
                if(context != null)
                {
                    Persons person = new Persons() { 
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

    public class Name : ControllerBase
{
    public IActionResult get()
    {
        return Content("binh ");
    }
}

