using Constructor.Repository;
using Microsoft.EntityFrameworkCore;

namespace Constructor
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAppServices(this IServiceCollection services,string connection)
        {
            
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connection));
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<MasterRepository>();
            services.AddScoped<ClientRepository>();
            services.AddScoped<PageRepository>();
            services.AddScoped<DealRepository>();
            services.AddScoped<ProjectRepository>();
        }
    }
}
