namespace CRGeo.backend.API.DTA.GetDistrictsByCantonId;

//public record GetDistrictsByCantonIdRequest(string CityId);

public record GetDistrictsByCantonIdResponse(IEnumerable<GeographicalDistributionDto> Districts);

public class GetDistrictsByCantonIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("Dta/districts/{id}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetDistrictsByCantonIdQuery(id));

                var response = result.Adapt<GetDistrictsByCantonIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetDistrictsByCantonId")
            .Produces<GetDistrictsByCantonIdResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get districts by City Id")
            .WithDescription("Get districts by City Id");
    }
}