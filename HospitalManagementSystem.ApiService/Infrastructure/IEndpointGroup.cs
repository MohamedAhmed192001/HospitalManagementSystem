namespace HospitalManagementSystem.ApiService.Infrastructure
{
    
    public interface IEndpointGroup
    {
        
        static virtual string? RoutePrefix => null;
        static abstract void Map(RouteGroupBuilder groupBuilder);
    }
}
