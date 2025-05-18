namespace CRGeo.backend.API.DTA.GetProvinces;

//public record GetProvincesRequest();
public record GetProvincesResponse(IEnumerable<Province> Provinces);

public class GetProvincesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("Dta/Provinces/", async (ISender sender) =>
                {
                    var result = await sender.Send(new GetProvincesQuery());

                    var response = result.Adapt<GetProvincesResponse>();

                    return Results.Ok(response);
                }
            )
            .WithName("GetProvinces")
            .Produces<GetProvincesResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Provinces")
            .WithDescription("Get Provinces");
        ;
    }
}