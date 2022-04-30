using System.Collections.Generic;
using System.Threading.Tasks;
using ITS_Technical_Test.Common.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITS_Technical_Test.Common.Repository.Implementations
{
    public class SqlReadRepository<TDomainEntity, TContext> : ISqlReadRepository<TDomainEntity, TContext>
    where TDomainEntity : class
    where TContext : DbContext
    {
        private TContext Context { get; set; }
        public SqlReadRepository(TContext context)
        {
            Context = context;
        }
        public async Task<IEnumerable<TDomainEntity>> GetAllAsync()
        {
            return await Context.Set<TDomainEntity>().ToListAsync();
        }

        public async Task<TDomainEntity> GetByIdAsync(long id)
        {
            return await Context.Set<TDomainEntity>().FindAsync(id);
        }

        public async Task AddAsync(TDomainEntity entity)
        {
            await Context.Set<TDomainEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TDomainEntity> entity)
        {
            await Context.Set<TDomainEntity>().AddRangeAsync(entity);
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
            var entity = await Context.Set<TDomainEntity>().FindAsync(id);

            await DeleteAsync(entity);
        }
    }
}
