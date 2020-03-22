using System.Collections.Generic;
using System.Linq;
using Autofac.AspNetCore.MySql.Domain;
using EInfrastructure.Core.Config.Entities.Ioc;
using EInfrastructure.Core.Configuration.Ioc.Plugs;
using Microsoft.AspNetCore.Mvc;

namespace Autofac.AspNetCore.MySql.Controllers
{
    public class CheckController : Controller
    {
        private readonly IRepository<Users, string> _userRepository;
        private readonly IQuery<Users, string> _userQuery;
        private readonly IJsonProvider _jsonProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="userQuery"></param>
        /// <param name="jsonProviders"></param>
        public CheckController(IRepository<Users, string> userRepository, IQuery<Users, string> userQuery,
            ICollection<IJsonProvider> jsonProviders)
        {
            _userRepository = userRepository;
            _userQuery = userQuery;
            _jsonProvider = EInfrastructure.Core.HelpCommon.InjectionSelectionCommon.GetImplement(jsonProviders);
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
            _userRepository.Add(new Users()
            {
                Name = "zhenlei520",
                Age = 18
            });
            _userRepository.UnitOfWork.Commit();
            return Content(_jsonProvider.Serializer(_userQuery.GetQueryable().ToList()));
        }
    }
}