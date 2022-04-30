using System.ComponentModel.DataAnnotations.Schema;
using ITS_Technical_Test.Core.Data.Entity.Interfaces;
using ITS_Technical_Test.Core.Misc;

namespace ITS_Technical_Test.Core.Data.Entity.Implementations
{
    [Table("Customer")]
    public  class Customer : Common.Repository.Implementations.Entity,ICustomer
    {
 
        public string Name { get; set; }

        public string Email { get; set; }

        public CustomerClass Class { get; set; }

        public string Comment { get; set; }
        public string PhoneNumber { get; set; }
    }
}
