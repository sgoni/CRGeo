namespace CRGeo.backend.API.DTA.GetCitiesByName;

public record GetCitiesByNameQuery(string CityName) : IQuery<GetCitiesByNameResult>;

public record GetCitiesByNameResult(IEnumerable<GeographicalDistributionDto> Cities);

public class GetCitiesByNameHandler(IGeoRepository repository)
    : IQueryHandler<GetCitiesByNameQuery, GetCitiesByNameResult>
{
    public async Task<GetCitiesByNameResult> Handle(GetCitiesByNameQuery query, CancellationToken cancellationToken)
    {
        var cities = await repository.GetCitiesByName(query.CityName);
        return new GetCitiesByNameResult(cities);
    }
}