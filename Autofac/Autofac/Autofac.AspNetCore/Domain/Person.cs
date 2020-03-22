namespace Autofac.AspNetCore.Domain
{
    /// <summary>
    /// 人物
    /// </summary>
    public class Person : IPerson
    {
        /// <summary>
        /// 奔跑 
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="distance">距离</param>
        public string Run(string name, int distance)
        {
            return $"姓名：{name}，需奔跑{distance}米";
        }
    }
}