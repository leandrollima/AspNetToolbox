using AspNetToolbox.Api.Filters;
using Toolbox.Mapper;
using Toolbox.Service;

namespace AspNetToolbox.Api
{
    public class Startup : Interfaces.IStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services, IConfigurationBuilder configurationBuilder, IWebHostEnvironment environment)
        {
            services.AddAutoMapperDto();
            services.AddScoped<WeatherForecastService>();
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers(options =>
            {
                options.Filters.Add<ValueObjectTFilter>();
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(); 

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
