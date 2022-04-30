using System;
using System.Linq;
using ITS_Technical_Test.Core.Data.Context;

namespace ITS_Technical_Test.Common.Services
{
    public class AggregateService: IDisposable
    {
        
        public ICustomerDbContext DbContext;  

         public AggregateService(params ICustomerDbContext[] contexts)
        {
            if (contexts is null)
            {
                throw new ArgumentNullException(nameof(contexts));
            }

            contexts.ToList().ForEach(c => {
                
        
                var a = c.GetType();
                var l = typeof(CustomerDbContext);

                if(c.GetType() == typeof(CustomerDbContext))
                    DbContext = c;
 

                else
                    throw new ArgumentOutOfRangeException("Invalid or Unidentified context was passed to the aggregate service");

                

            });
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        //Handle the case of different underlying contexts(sql and Nosql)
        public void ExecuteTransaction()
        {
                
        }
       
        
    }
}
