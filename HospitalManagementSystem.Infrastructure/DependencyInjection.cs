using HospitalManagementSystem.Application.Common.Interfaces;
using HospitalManagementSystem.Application.Doctors.Commands.CreateDoctor;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace HospitalManagementSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            ArgumentNullException.ThrowIfNull(connectionString);




            builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(
              options => options.UseSqlServer(connectionString));


            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateDoctorCommand).Assembly);
            });

        }
    }
}
