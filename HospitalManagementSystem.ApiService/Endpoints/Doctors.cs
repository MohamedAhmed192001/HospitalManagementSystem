using HospitalManagementSystem.ApiService.Infrastructure;
using HospitalManagementSystem.Application.Doctors.Commands.CreateDoctor;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.ApiService.Endpoints
{
    public class Doctors : IEndpointGroup
    {
        public static void Map(RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapPost( CreateDoctor);
        }


        public static async Task<Created<int>> CreateDoctor(ISender sender, CreateDoctorCommand command)
        {
            var id = await sender.Send(command);

            return TypedResults.Created($"/{nameof(Doctors)}/{id}", id);
        }
    }
}
