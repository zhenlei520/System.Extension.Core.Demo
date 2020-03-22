using Autofac.AspNetCore.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Autofac.AspNetCore.Controllers
{
    public class CheckController : Controller
    {
        private readonly IPerson _person;
        
        public CheckController(IPerson person)
        {
            _person = person;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ContentResult Healthy()
        {
            return Content("ok");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ContentResult Healthy2()
        {
            return Content(_person.Run("张三",10));
        }
    }
}