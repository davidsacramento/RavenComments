using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Raven.DependencyInjection;
using Backend.Challenge.CQRS.Commands;
using Backend.Challenge.CQRS;
using Raven.Client.Documents.Indexes;
using Raven.Client.Documents;
using Backend.Challenge.Data.Indexes;

namespace Backend.Challenge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddRavenDbDocStore();
            services.AddRavenDbAsyncSession();
            
            services.AddTransient<IResolver, NetCoreDiResolver>();

            services.Scan(scan => scan
                .FromAssemblyOf<ICommandDispatcher>()
                .AddClasses()
                .AsSelf()
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDocumentStore documentStore)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            IndexCreation.CreateIndexes(typeof(Entities_ById).Assembly, documentStore);
            IndexCreation.CreateIndexes(typeof(Authors_ByEmail).Assembly, documentStore);

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
