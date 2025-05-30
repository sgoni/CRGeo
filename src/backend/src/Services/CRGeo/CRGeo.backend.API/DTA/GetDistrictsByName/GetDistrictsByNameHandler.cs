namespace CRGeo.backend.API.DTA.GetDistrictsByName;

public record GetDistrictsByNameQuery(string Name) : IQuery<GetDistrictsByNameResult>;

public record GetDistrictsByNameResult(IEnumerable<GeographicalDistributionDto> Districts);

public class GetDistrictsByNameHandler(IGeoRepository repository)
    : IQueryHandler<GetDistrictsByNameQuery, GetDistrictsByNameResult>
{
    public async Task<GetDistrictsByNameResult> Handle(GetDistrictsByNameQuery quwry,
        CancellationToken cancellationToken)
    {
        var districts = await repository.GetDistrictsByName(quwry.Name);
        return new GetDistrictsByNameResult(districts);
    }
}