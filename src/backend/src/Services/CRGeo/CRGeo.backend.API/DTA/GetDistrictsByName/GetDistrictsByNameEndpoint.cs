namespace CRGeo.backend.API.DTA.GetDistrictsByName;

// public record GetDistrictsByNameRequest(int Name);

public record GetDistrictsByNameResponse(IEnumerable<GeographicalDistributionDto> Districts);

public class GetDistrictsByNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("Dta/districts/name/{name}", async (string name, ISender sender) =>
            {
                var result = await sender.Send(new GetDistrictsByNameQuery(name));

                var response = result.Adapt<GetDistrictsByNameResponse>();

                return Results.Ok(response);
            })
            .WithName("GetDistrictsByName")
            .Produces<GetDistrictsByNameResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Districta by Name")
            .WithDescription("Get Districta by Name");
    }
}