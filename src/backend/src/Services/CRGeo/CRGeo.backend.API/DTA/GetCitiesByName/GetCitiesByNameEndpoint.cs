namespace CRGeo.backend.API.DTA.GetCitiesByName;

// public record GetCitiesByNameRequest(int Name);

public record GetCitiesByNameResponse(IEnumerable<GeographicalDistributionDto> Cities);

public class GetCitiesByNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("Dta/cities/name/{name}", async (string name, ISender sender) =>
            {
                var result = await sender.Send(new GetCitiesByNameQuery(name));

                var response = result.Adapt<GetCitiesByNameResponse>();

                return Results.Ok(response);
            })
            .WithName("GetCitiesByName")
            .Produces<GetCitiesByNameResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Cities by Name")
            .WithDescription("Get Cities by Name");
    }
}