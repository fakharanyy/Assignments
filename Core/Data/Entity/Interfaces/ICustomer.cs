
using ITS_Technical_Test.Core.Misc;

namespace ITS_Technical_Test.Core.Data.Entity.Interfaces
{
    public interface ICustomer
    {
        long Id { get; }
        string Name { get; }
        string Email { get; }
        CustomerClass Class { get; }
        string Comment { get; }
        string PhoneNumber { get; }

    }
}
