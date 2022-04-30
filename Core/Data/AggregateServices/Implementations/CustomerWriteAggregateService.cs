using System.Threading.Tasks;
using AutoMapper;
using ITS_Technical_Test.Core.Contracts;
using ITS_Technical_Test.Core.Data.AggregateServices.Interfaces;
using ITS_Technical_Test.Core.Data.Context;
using ITS_Technical_Test.Core.Data.Entity.Implementations;
using ITS_Technical_Test.Core.Data.Services.Interfaces;
using ITS_Technical_Test.Presentation.Models;

namespace ITS_Technical_Test.Core.Data.AggregateServices.Implementations
{
    public class CustomerWriteAggregateService :  ICustomerWriteAggregateService
    {
        private readonly ICustomerWriteService CustomerWriteServices;
        private readonly ICustomerReadService CustomerReadServices;
        private readonly CustomerDbContext DbContext;
        private CustomerContract CustomerContract;
        private readonly IMapper Mapper;


        public CustomerWriteAggregateService(ICustomerWriteService customerWriteServices, CustomerDbContext purchasingDbContext, IMapper mapper, ICustomerReadService customerReadServices)
        {
            CustomerWriteServices = customerWriteServices;
            DbContext = purchasingDbContext;
            Mapper = mapper;
            CustomerReadServices = customerReadServices;
        }
        public async Task<CustomerModel> CreateCustomer(CustomerModel model)
        {
            CustomerContract = new CustomerContract(model);
            await CustomerWriteServices.CreateCustomer(Mapper.Map<Customer>(CustomerContract));
            await DbContext.SaveChangesAsync();
            return Mapper.Map<CustomerModel>(CustomerContract);


        }

        public async Task<CustomerModel> UpdateCustomer(CustomerModel model)
        {

            CustomerContract = new CustomerContract(model);
            await CustomerWriteServices.UpdateCustomer(Mapper.Map<Customer>(CustomerContract));
            await DbContext.SaveChangesAsync();
            return Mapper.Map<CustomerModel>(CustomerContract);
        }

        public async Task<CustomerModel> DeleteCustomer(CustomerModel model)
        {

            CustomerContract = new CustomerContract(model);
            await CustomerWriteServices.DeleteCustomer(Mapper.Map<Customer>(CustomerContract));
            await DbContext.SaveChangesAsync();
            return Mapper.Map<CustomerModel>(CustomerContract);
        }

        public async Task<CustomerModel> DeleteCustomer(long id)
        {
            var customer = await CustomerReadServices.GetCustomer(id);
            await CustomerWriteServices.DeleteCustomer(id);
            await DbContext.SaveChangesAsync();
            return Mapper.Map<CustomerModel>(customer);
        }
    }
}
