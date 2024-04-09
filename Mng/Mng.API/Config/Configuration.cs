using AutoMapper;
using Mng.Core;
using Mng.Core.Repositories;
using Mng.Core.Services;
using Mng.Data.Repositories;
using Mng.Services;

namespace Mng.API.Config
{
    public static class Configuration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IRolesForEmployeeRepository, RolesForEmployeeRepository>();
            services.AddScoped<IRolesForEmployeeService, RolesForEmployeeService>();
            services.AddScoped<ITypesOfRolesRepository, TypesOfRolesRepository>();
            services.AddScoped<ITypeOfRolesService, TypesOfRolesService>();
            // mapper אפשרות להמיר בין אוביקט אחד לשני    
            var mappingConfig = new MapperConfiguration(mc =>
                 {
                     mc.AddProfile(new Mapping());
                 });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // services.AddAutoMapper(typeof(Mapping));

        }

    }
}
