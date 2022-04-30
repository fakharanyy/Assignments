using System.Collections.Generic;
using System.Threading.Tasks;
using ITS_Technical_Test.Core.Data.Entity.Implementations;

namespace ITS_Technical_Test.Core.Data.Services.Interfaces
{
    public interface ICustomerReadService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(long id);
    }
}
