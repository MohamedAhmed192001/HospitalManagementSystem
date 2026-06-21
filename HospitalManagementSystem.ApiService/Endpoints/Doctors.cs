using HospitalManagementSystem.ApiService.Infrastructure;
using HospitalManagementSystem.Application.Doctors.Commands.CreateDoctor;
using HospitalManagementSystem.Application.Doctors.Commands.UpdateDoctor;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;


namespace HospitalManagementSystem.ApiService.Endpoints
{
    public class Doctors : EndpointGroupBase
    {
        public override void Map(WebApplication groupBuilder)
        {
            groupBuilder.MapGroup(this)
                .MapPost(CreateDoctor)
                .MapPut(UpdateDoctor, "{id}")
                   ;
        }

        public static async Task<Created<int>> CreateDoctor(ISender sender, CreateDoctorCommand command)
        {
            var id = await sender.Send(command);

            return TypedResults.Created($"/{nameof(Doctors)}/{id}", id);
        }

        public async Task<Results<NoContent, BadRequest>> UpdateDoctor(ISender sender, int id, UpdateDoctorCommand command)
        {
            if (id != command.Id) return TypedResults.BadRequest();

            await sender.Send(command);

            return TypedResults.NoContent();
        }

       
    }
}
