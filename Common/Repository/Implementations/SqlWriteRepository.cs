using System.Linq;
using System.Threading.Tasks;
using ITS_Technical_Test.Common.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITS_Technical_Test.Common.Repository.Implementations
{

    public class SqlWriteRepository<TDomainEntity, TContext> : ISqlWriteRepository<TDomainEntity, TContext>
        where TDomainEntity : Entity
        where TContext : DbContext
    {
        private TContext Context { get; set; }
        public SqlWriteRepository(TContext context)
        {
            Context = context;
        }


        public async Task AddAsync(TDomainEntity entity)
        {
            await Context.Set<TDomainEntity>().AddAsync(entity);
        }

        public async Task UpdateAsync(TDomainEntity entity)
        {
            Context.Set<TDomainEntity>().Update(entity);
        }

        public async Task DeleteAsync(TDomainEntity entity)
        {
            Context.Set<TDomainEntity>().Remove(entity);
        }

        public async Task DeleteAsync(long id)
        {
            var entity = Context.Set<TDomainEntity>().FirstOrDefault(e => e.Id == id);

            await DeleteAsync(entity);
        }
    }
}
