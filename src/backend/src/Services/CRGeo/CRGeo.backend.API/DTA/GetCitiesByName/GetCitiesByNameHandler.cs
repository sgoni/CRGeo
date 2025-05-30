namespace CRGeo.backend.API.DTA.GetCitiesByName;

public record GetCitiesByNameQuery(string Name) : IQuery<GetCitiesByNameResult>;

public record GetCitiesByNameResult(IEnumerable<GeographicalDistributionDto> Cities);

public class GetCitiesByNameHandler(IGeoRepository repository)
    : IQueryHandler<GetCitiesByNameQuery, GetCitiesByNameResult>
{
    public async Task<GetCitiesByNameResult> Handle(GetCitiesByNameQuery query, CancellationToken cancellationToken)
    {
        var cities = await repository.GetCitiesByName(query.Name);
        return new GetCitiesByNameResult(cities);
    }
}