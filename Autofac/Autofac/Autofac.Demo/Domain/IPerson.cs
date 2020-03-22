using EInfrastructure.Core.Configuration.Ioc;

namespace Autofac.Demo.Domain
{
    /// <summary>
    /// 人物
    /// </summary>
    public interface IPerson : ISingleInstance
    {
        /// <summary>
        /// 奔跑 
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="distance">距离</param>
        void Run(string name, int distance);
    }
}