using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ITS_Technical_Test.Core.Data.AggregateServices.Interfaces;
using ITS_Technical_Test.Core.Data.Services.Interfaces;
using ITS_Technical_Test.Presentation.Models;

namespace ITS_Technical_Test.Core.Data.AggregateServices.Implementations
{
    public class CustomerReadAggregateService:ICustomerReadAggregateService
    {
        private readonly ICustomerReadService CustomerReadService;
        private readonly IMapper Mapper;

        public CustomerReadAggregateService( IMapper mapper, ICustomerReadService customerReadService)
        {
            CustomerReadService = customerReadService;
            Mapper = mapper;
        }
        public async Task<IEnumerable<CustomerModel>> GetCustomers()
        {
            var customerList = await CustomerReadService.GetCustomers();
            return Mapper.Map<IEnumerable<CustomerModel>>(customerList);
        }

        public async Task<CustomerModel> GetCustomer(long id)
        {
            var customer = await CustomerReadService.GetCustomer(id);
            return Mapper.Map<CustomerModel>(customer);
        }
    }
}
