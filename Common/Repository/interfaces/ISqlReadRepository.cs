using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITS_Technical_Test.Common.Repository.interfaces
{
    public interface ISqlReadRepository<TDomainEntity, TContext>
        where TDomainEntity : class
        where TContext : Microsoft.EntityFrameworkCore.DbContext
    {
        Task<IEnumerable<TDomainEntity>> GetAllAsync();
        Task<TDomainEntity> GetByIdAsync(long id);
        
    }
}
