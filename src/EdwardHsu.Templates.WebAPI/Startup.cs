namespace EdwardHsu.Templates.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment   = environment;
        }

        public IConfiguration Configuration { get; private set; }
        public IHostEnvironment Environment { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region Common
            services.AddOptions();
            services.AddLogging(config =>
            {
                config.AddConsole();
            });
            services.AddHttpContextAccessor();

            services.AddControllers()
                    .AddControllersAsServices();
            #endregion

            #region OPEN API
            services.AddEndpointsApiExplorer();
            services.AddOpenApiDocument(
                config =>
                {
                    config.Title = nameof(EdwardHsu.Templates.WebAPI);
                });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }
            
            app.UseRouting();

            app.UseEndpoints(
                config =>
                {
                    config.MapControllers();
                });
        }
    }
}
