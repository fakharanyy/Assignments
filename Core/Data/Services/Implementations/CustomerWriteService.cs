using System.Threading.Tasks;
using AutoMapper;
using ITS_Technical_Test.Common.Repository.interfaces;
using ITS_Technical_Test.Core.Data.Context;
using ITS_Technical_Test.Core.Data.Entity.Implementations;
using ITS_Technical_Test.Core.Data.Services.Interfaces;

namespace ITS_Technical_Test.Core.Data.Services.Implementations
{
    public class CustomerWriteService : ICustomerWriteService
    {
         private readonly ISqlWriteRepository<Customer, CustomerDbContext> SqlWriteRepository;

        public CustomerWriteService(ISqlWriteRepository<Customer, CustomerDbContext> sqlWriteRepository, IMapper mapper)
        {
            SqlWriteRepository = sqlWriteRepository;
         }

        public async Task CreateCustomer(Customer customer)
        {
             await SqlWriteRepository.AddAsync(customer);

        }

        public async Task UpdateCustomer(Customer customer)
        {
            await SqlWriteRepository.UpdateAsync(customer);
        }

        public async Task DeleteCustomer(Customer customer)
        {
            await SqlWriteRepository.DeleteAsync(customer);
        }

        public async Task DeleteCustomer(long id)
        {
            await SqlWriteRepository.DeleteAsync(id);
        }
    }
}
