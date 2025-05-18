namespace CRGeo.backend.API.DTA.GetCantonsByProvinceId;

// public record GetCitiesByProvinceIdRequest(int ProvinceId);

public record GetCitiesByProvinceIdResponse(IEnumerable<GeographicalDistributionDto> Cities);

public class GetCitiesByProvinceIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("Dta/cities/{id}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new GetCitiesByProvinceIdQuery(id));

                var response = result.Adapt<GetCitiesByProvinceIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetCitiesByProvinceId")
            .Produces<GetCitiesByProvinceIdResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Cities by Province Id")
            .WithDescription("Get Cities by Province Id");
    }
}