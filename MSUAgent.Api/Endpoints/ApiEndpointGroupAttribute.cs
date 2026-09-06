namespace MSUAgent.Api.Endpoints;

[AttributeUsage(AttributeTargets.Class)]
public sealed class ApiEndpointGroupAttribute : Attribute
{
    public string Route { get; }

    public ApiEndpointGroupAttribute(string route)
    {
        Route = route;
    }
}