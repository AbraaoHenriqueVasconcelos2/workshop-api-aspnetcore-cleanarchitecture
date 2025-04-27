using System;
using System.Text;

using EventFeedbackAPI.Application.mapper;
using EventFeedbackAPI.Application.interfaces;
using EventFeedbackAPI.Application.services;

using EventFeedbackAPI.Domain.interfaces;
using EventFeedbackAPI.Domain.authentication;

using EventFeedbackAPI.Infra.Data.context;
using EventFeedbackAPI.Infra.Data.repositories;
using EventFeedbackAPI.Infra.Data.identity;



using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
 

namespace EventFeedbackAPI.Infra.Ioc
{
    public static class DependencyInjection
    {
        
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)  
                     
                );
            }));

            services.AddAuthentication(opt =>  {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = configuration["jwt:issuer"],
                   ValidAudience = configuration["jwt:audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:secretKey"])),
                   ClockSkew = TimeSpan.Zero
               };
           }); 




            services.AddAutoMapper(typeof(Mapper));

            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IParticipantService, ParticipantService>();

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventService, EventService>();

            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            return services;

        }
    }
}
