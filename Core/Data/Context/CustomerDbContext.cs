using System.Reflection;
using ITS_Technical_Test.Core.Data.Configurations;
using ITS_Technical_Test.Core.Data.Entity.Implementations;
using Microsoft.EntityFrameworkCore;

namespace ITS_Technical_Test.Core.Data.Context
{
    public class CustomerDbContext :DbContext, ICustomerDbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
             modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
        }


    }
}
