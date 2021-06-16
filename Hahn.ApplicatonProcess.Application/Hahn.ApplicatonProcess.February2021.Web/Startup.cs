using Hahn.ApplicatonProcess.February2021.Data;
using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Data.DataContext;
using Hahn.ApplicatonProcess.February2021.Data.Repository;
using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Hahn.ApplicatonProcess.February2021.Web
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
            //services.AddScoped<DbContext, DatabaseContext>();
            //services.AddTransient<IAssetRepository, AssetRepository>();
            //services.AddTransient<IUnityOfWork, UnityOfWork>();
            services.AddTransient<UnityOfWorkTest>();
            services.AddScoped<DbContext, DatabaseContext>();
            services.AddTransient<AssetRepository>();
            services.AddTransient<UnityOfWork>();
            
            services.AddDbContext<DatabaseContext>(options =>
                options.UseInMemoryDatabase(databaseName: "HahnSoftwareentwicklungTestDB"));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hahn.ApplicatonProcess.February2021.Web", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn.ApplicatonProcess.February2021.Web v1"));
            }

            //var context = serviceProvider.GetService<DatabaseContext>();
            //seedingAsset(context);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //private void seedingAsset(DatabaseContext context)
        //{
        //    var test1 = new Asset
        //    {
        //        Id = 1,
        //        AssetName = "Test",
        //        Department = Department.HQ,
        //        CountryOfDepartment = "Brazil",
        //        EmailAdressOfDepartment = "Brazil@hotmail.com",
        //        PurchaseDate = DateTime.UtcNow,
        //        Broken = true
        //    };
        //    context.Assets.Add(test1);

        //    var testePost1 = new Asset
        //    {
        //        Id = 2,
        //        AssetName = "Test",
        //        Department = Department.HQ,
        //        CountryOfDepartment = "Brazil",
        //        EmailAdressOfDepartment = "Brazil@hotmail.com",
        //        PurchaseDate = DateTime.UtcNow,
        //        Broken = true
        //    };
        //    context.Assets.Add(testePost1);

        //    context.SaveChanges();
        //}
    }
}

