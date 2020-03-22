using Autofac.MySql.Domain;
using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autofac.MySql.Map
{
    /// <summary>
    /// 
    /// </summary>
    public class UserMap : IEntityMap<Users>
    {
        public void Map(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("users");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id").HasMaxLength(50);

            builder.Property(t => t.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
            builder.Property(t => t.Age).HasColumnName("age").IsRequired();
        }
    }
}