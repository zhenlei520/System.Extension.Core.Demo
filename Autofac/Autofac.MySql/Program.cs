using System;
using System.Linq;
using Autofac.MySql.Domain;
using EInfrastructure.Core.Config.Entities.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace Autofac.MySql
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var provider = GetServiceProvider();


            IRepository<Users, string> userRepository = provider.GetService<IRepository<Users, string>>(); //添加一条数据到数据库,其中IRepository已经内置实现类
            userRepository.Add(new Users()
            {
                Name = "zhenlei520",
                Age = 18
            });
            userRepository.UnitOfWork.Commit();

            IQuery<Users, string> userQuery = provider.GetService<IQuery<Users, String>>(); //查询数据，其中IQuery为查询库，已经内置实现类
            var userList = userQuery.GetQueryable().ToList();

            Console.ReadKey();
        }

        public static IServiceProvider GetServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<DemoDbContext>();
            return EInfrastructure.Core.AutoFac.MySql.AutofacAutoRegister.Use(
                services,
                (builder) => { });
        }
    }
}