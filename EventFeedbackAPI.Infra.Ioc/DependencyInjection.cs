using System;
using EventFeedbackAPI.Infra.Data.context;
using EventFeedbackAPI.Infra.Data.repositories;
using EventFeedbackAPI.Domain.interfaces;
using EventFeedbackAPI.Application.mapper;
using EventFeedbackAPI.Application.interfaces;
using EventFeedbackAPI.Application.services;



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
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            }));

            services.AddAutoMapper(typeof(Mapper));

            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IParticipantService, ParticipantService>();

            return services;

        }
    }
}
