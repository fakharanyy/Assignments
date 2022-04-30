using System.Threading.Tasks;
using ITS_Technical_Test.Presentation.Models;

namespace ITS_Technical_Test.Core.Data.AggregateServices.Interfaces
{
    public interface ICustomerWriteAggregateService
    {
        Task<CustomerModel> CreateCustomer(CustomerModel model);
        Task<CustomerModel> UpdateCustomer(CustomerModel model);
        Task<CustomerModel> DeleteCustomer(CustomerModel model);
        Task<CustomerModel> DeleteCustomer(long id);
    }
}
