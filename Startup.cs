using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ITS_Technical_Test.Common.Repository.Implementations;
using ITS_Technical_Test.Common.Repository.interfaces;
using ITS_Technical_Test.Core.Data.AggregateServices.Implementations;
using ITS_Technical_Test.Core.Data.AggregateServices.Interfaces;
using ITS_Technical_Test.Core.Data.Context;
using ITS_Technical_Test.Core.Data.Services.Implementations;
using ITS_Technical_Test.Core.Data.Services.Interfaces;
using ITS_Technical_Test.Presentation.APis.Controllers;
using ITS_Technical_Test.Presentation.ModelValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Converters;

namespace ITS_Technical_Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Core.Data.Context.CustomerDbContext>(options =>
            {

                options.UseSqlServer(@"Data Source=FAKHARANY;Initial Catalog=CustomerDbContext;
                                                        Integrated Security = True; Pooling=False",
                    assembly => assembly.MigrationsAssembly(typeof(CustomerDbContext).Assembly.FullName));

            });

            services.AddScoped(typeof(ISqlReadRepository<,>), typeof(SqlReadRepository<,>));
            services.AddScoped(typeof(ISqlWriteRepository<,>), typeof(SqlWriteRepository<,>));
            services.AddScoped<ICustomerDbContext, CustomerDbContext>();

            //scan assemble to configure services
            services.Scan(scan => scan
                .FromAssemblies(
                   typeof(ICustomerWriteService).Assembly,
                    typeof(CustomerWriteService).Assembly,
                    typeof(ICustomerWriteAggregateService).Assembly,
                    typeof(CustomerWriteAggregateService).Assembly)
                .AddClasses()
                .AsMatchingInterface()
                .WithTransientLifetime());

            //scan assemble to configure controllers
            var assembly = typeof(CustomerWriteController).Assembly;
            services.AddControllersWithViews().AddApplicationPart(assembly);

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();


            // allowing Orgins for javaScript
            services.AddCors(e =>
            {
                e.AddPolicy("AllowOrigin", x => x.AllowAnyOrigin());
            }
            );
            services.AddMvc(options =>
                {
                    options.SuppressAsyncSuffixInActionNames = true;

                    options.EnableEndpointRouting = true;
                })
                .AddFluentValidation(e => e.RegisterValidatorsFromAssemblyContaining<CustomerModelValidator>())
                .AddNewtonsoftJson(opts => opts.SerializerSettings.Converters.Add(new StringEnumConverter()));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(e => e.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();

        }
    }
}
