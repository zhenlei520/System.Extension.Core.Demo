using System;
using Autofac.Demo.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Autofac.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var provider = GetServiceProvider();
            provider.GetService<IPerson>().Run(Console.ReadLine(),100);
            Console.ReadKey();
        }
        
        public static IServiceProvider GetServiceProvider(){
            IServiceCollection services = new ServiceCollection();
            return  EInfrastructure.Core.AutoFac.AutofacAutoRegister.Use(
                services,
                (builder) => { });
        }
    }
}