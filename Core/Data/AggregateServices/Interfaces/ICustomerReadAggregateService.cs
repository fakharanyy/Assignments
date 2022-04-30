using System.Collections.Generic;
using System.Threading.Tasks;
using ITS_Technical_Test.Presentation.Models;

namespace ITS_Technical_Test.Core.Data.AggregateServices.Interfaces
{
    public interface ICustomerReadAggregateService
    {
        Task<IEnumerable<CustomerModel>> GetCustomers();
        Task<CustomerModel> GetCustomer(long id);
    }
}
