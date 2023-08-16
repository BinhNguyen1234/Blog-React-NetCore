using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace dotnet_vite_vuejs.Testservice
{
    public class TestService:ITestService
    {
        public string Sth()
        {
            return "ffdfdfdfdfdf";
        }
        public Dictionary<string, object> tesst = new Dictionary<string, object>()
        {

        };
    }
    public interface ITestService
    {
        public string Sth();
       
        
       
    }
}
