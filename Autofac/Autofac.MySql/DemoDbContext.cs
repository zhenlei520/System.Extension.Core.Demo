using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EInfrastructure.Core.Config.Entities.Ioc;
using EInfrastructure.Core.Configuration.Ioc;
using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;

namespace Autofac.MySql
{
    public class DemoDbContext : DbContext, IUnitOfWork, IPerRequest
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "Server=localhost;port=3306;database=demo;uid=root;pwd=rootroot;Convert Zero Datetime=True;",
                b => b.MaxBatchSize(30));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AutoMap(typeof(DemoDbContext)); //根据Map自动映射
        }

        public bool Commit()
        {
            base.SaveChanges();
            return true;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}