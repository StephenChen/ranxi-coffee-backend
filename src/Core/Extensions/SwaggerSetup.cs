using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace LibraCoffee.Core.Extensions
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // 注册 Swagger 生成器，定义一个或多个 Swagger 文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Coffee API", Version = "v1" });

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT 授权",
                    Name = "Authorization", // jwt 默认的参数名称
                    In = ParameterLocation.Header, // jwt 默认存放 Authorization 信息的位置
                    Type = SecuritySchemeType.ApiKey
                });
            });
        }
    }
}
