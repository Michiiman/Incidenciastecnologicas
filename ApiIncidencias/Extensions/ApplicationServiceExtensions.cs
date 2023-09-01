using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.IdentityModel.Tokens;
//using Seguridad.Tokens;

namespace ApiIncidencias.Extensions;

    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)=> services.AddCors(options =>{
            options.AddPolicy("CorsPolicy", builder=>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration,RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options=>{
                options.EnableEndpointRateLimiting=true;
                options.StackBlockedRequests=false;
                options.HttpStatusCode=429;
                options.RealIpHeader="X-Real_IP";
                options.GeneralRules=new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint="*",
                        Period="10s",
                        Limit=2
                    }
                };
            });
        }
    }
