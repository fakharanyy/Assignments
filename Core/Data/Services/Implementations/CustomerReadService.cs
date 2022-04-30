
using System.Collections.Generic;
using System.Threading.Tasks;
using ITS_Technical_Test.Common.Repository.interfaces;
using ITS_Technical_Test.Core.Data.Context;
using ITS_Technical_Test.Core.Data.Entity.Implementations;
using ITS_Technical_Test.Core.Data.Services.Interfaces;

namespace ITS_Technical_Test.Core.Data.Services.Implementations
{
    public class CustomerReadService: ICustomerReadService
    {

         private readonly ISqlReadRepository<Customer, CustomerDbContext> SqlReadRepository;

        public CustomerReadService(ISqlReadRepository<Customer, CustomerDbContext> sqlReadRepository)
        {
            SqlReadRepository = sqlReadRepository;
         }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
             return await SqlReadRepository.GetAllAsync();
        }
        public async Task<Customer> GetCustomer(long id)
        {
             return await SqlReadRepository.GetByIdAsync(id);
         }

    }
}
