// *********************************************************************************
//	<copyright file="Program.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Program class from where the execution starts</summary>
// *********************************************************************************

namespace IBBS.AI.API
{
    using IBBS.AI.Business.Contracts;
    using IBBS.AI.Business.Services;

    /// <summary>
    /// Program class from where the execution starts
    /// </summary>
    public class Program
    {
        /// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.development.json", optional: true)
                .AddEnvironmentVariables();
            
            ConfigureServices(builder.Services);

            var app = builder.Build();
            ConfigureApplication(app);
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication();
            services.AddControllers();
            services.AddOpenApi();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddHttpClient<IHttpClientHelper, HttpClientHelper>(client => {
                client.Timeout = TimeSpan.FromMinutes(3);
            });
            services.AddScoped<IBulletinAIServices, BulletinAIServices>();
        }

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void ConfigureApplication(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors();
            app.MapControllers();
            app.Run();
        }

    }
}

