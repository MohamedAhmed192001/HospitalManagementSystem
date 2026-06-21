using FluentValidation;
using HospitalManagementSystem.Application.Behaviours;
using HospitalManagementSystem.Application.Doctors.Commands.CreateDoctor;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
             builder.Services.AddValidatorsFromAssembly(assembly);

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(assembly);

                cfg.AddBehavior(
                    typeof(IPipelineBehavior<,>),

                    typeof(ValidationBehaviour<,>
                ));
            });
        }

    }
}
