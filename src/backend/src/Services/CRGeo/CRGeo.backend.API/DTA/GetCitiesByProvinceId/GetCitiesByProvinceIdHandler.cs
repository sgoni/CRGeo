namespace CRGeo.backend.API.DTA.GetCantonsByProvinceId;

public record GetCitiesByProvinceIdQuery(int ProvinceId) : IQuery<GetCitiessByProvinceIdResult>;

public record GetCitiessByProvinceIdResult(IEnumerable<GeographicalDistributionDto> Cities);

public class GetCitiesByProvinceIdHandler(IGeoRepository repository)
    : IQueryHandler<GetCitiesByProvinceIdQuery, GetCitiessByProvinceIdResult>
{
    public async Task<GetCitiessByProvinceIdResult> Handle(GetCitiesByProvinceIdQuery query,
        CancellationToken cancellationToken)
    {
        var cities = await repository.GetCantonsByProvince(query.ProvinceId);
        return new GetCitiessByProvinceIdResult(cities);
    }
}