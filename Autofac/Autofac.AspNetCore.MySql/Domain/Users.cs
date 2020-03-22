using System;
using EInfrastructure.Core.Config.Entities.Configuration;

namespace Autofac.AspNetCore.MySql.Domain
{
    /// <summary>
    ///  AggregateRoot为聚合根，Entity为聚合
    /// 其中继承AggregateRoot的实体可以增删改查，而继承Entity的只能查询
    /// 其中继承Adds不仅拥有AggregateRoot的所有特性还额外增加AddTime以及AddAccountId属性
    /// 其中继承AddAndUpdate不仅拥有Adds的所有特性还额外增加EditTime以及EditAccountId属性
    /// 其中继承Fulls不仅拥有AddAndUpdate的所有特性还额外增加DelTime以及DelAccountId以及IsDel属性
    /// </summary>
    public class Users : AggregateRoot<string>
    {
        public Users()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}