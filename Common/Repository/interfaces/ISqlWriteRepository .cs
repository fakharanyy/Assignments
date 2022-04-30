using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ITS_Technical_Test.Common.Repository.interfaces
{
    public interface ISqlWriteRepository<TDomainEntity, TContext>
        where TDomainEntity : class
        where TContext : DbContext
    {

        Task AddAsync(TDomainEntity entity);
        Task UpdateAsync(TDomainEntity entity);
        Task DeleteAsync(TDomainEntity entity);
        Task DeleteAsync(long id);
    }
}
