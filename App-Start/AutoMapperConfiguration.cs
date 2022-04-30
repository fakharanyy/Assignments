using AutoMapper;

namespace ITS_Technical_Test.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            var config = new MapperConfiguration((m) =>
            {
                m.AllowNullCollections = true;
               
                m.AddProfile<MappingProfile>();
            });

            IMapper mapper = config.CreateMapper();

            // config.AssertConfigurationIsValid();
        }
    }
}
