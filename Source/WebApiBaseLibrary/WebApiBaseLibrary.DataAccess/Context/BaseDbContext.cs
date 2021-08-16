using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WebApiBaseLibrary.DataAccess.Context
{
    public class BaseDbContext : DbContext
    {
        private readonly Assembly _entityConfigurationAssembly;

        public BaseDbContext(
            DbContextOptions<DbContext> options,
            IEntityConfigurationAssembly entityConfigurationAssembly = null) : base(options)
        {
            _entityConfigurationAssembly = entityConfigurationAssembly?.GetEntityConfigurationAssembly();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = Assembly.GetAssembly(GetType());
            modelBuilder.ApplyConfigurationsFromAssembly(assembly!);

            if (_entityConfigurationAssembly != null)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(_entityConfigurationAssembly!);
            }
        }
    }
}