using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Autofac;
using Autofac.Extras.DynamicProxy;
using LibraCoffee.Entities;
using LibraCoffee.Core.Extensions;
using LibraCoffee.Core.AOP;
using LibraCoffee.Services;

namespace LibraCoffee.Core
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
            services.AddDbContextSetup(Configuration);
            services.AddAutoMapperSetup();
            services.AddCorsSetup();
            services.AddSwaggerSetup();

            services.AddControllers();
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // 注册拦截器
            builder.RegisterType<LibraCoffeeLogAOP>();

            builder.RegisterType<CoffeeRepository>().As<ICoffeeRepository>()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LibraCoffeeLogAOP));

            // 注册要通过反射创建的组建
            // var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            // builder.RegisterAssemblyTypes = Assembly.LoadFrom

            // Register your own things directly with Autofac, like:
            // builder.RegisterModule(new MyApplicationModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 启用中间件服务生成 Swagger 作为 JSON 终结点
            app.UseSwagger();
            // 启用中间件服务对 swagger-ui，指定 Swagger JSON 终结点
            app.UseSwaggerUI(action =>
            {
                action.SwaggerEndpoint("/swagger/v1/swagger.json", "Coffee API v1");
                // 路径配置，设置为空，表直接在根域名（localhost:5000）访问该文件.
                action.RoutePrefix = "";
            });

            //context.EnsureSeedDataForContext();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
