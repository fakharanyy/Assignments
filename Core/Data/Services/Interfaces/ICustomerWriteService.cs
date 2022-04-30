using System.Threading.Tasks;
using ITS_Technical_Test.Core.Data.Entity.Implementations;

namespace ITS_Technical_Test.Core.Data.Services.Interfaces
{
    public interface ICustomerWriteService
    {

        Task CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);

        Task DeleteCustomer(Customer customer);
        Task DeleteCustomer(long id);

    }
}
