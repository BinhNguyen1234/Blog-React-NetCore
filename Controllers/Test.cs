using Microsoft.AspNetCore.Mvc;
namespace dotnet_vite_vuejs.Controllers
{
    public class Test: ControllerBase
    {
        public IActionResult aa()
        {
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

