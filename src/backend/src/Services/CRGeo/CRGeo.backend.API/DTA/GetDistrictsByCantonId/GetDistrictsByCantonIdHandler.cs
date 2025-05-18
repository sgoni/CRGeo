namespace CRGeo.backend.API.DTA.GetDistrictsByCantonId;

public record GetDistrictsByCantonIdQuery(int CityId) : IQuery<GetDistrictsByCantonIdResult>;

public record GetDistrictsByCantonIdResult(IEnumerable<GeographicalDistributionDto> Districts);

public class GetDistrictsByCantonIdHandler(IGeoRepository repository)
    : IQueryHandler<GetDistrictsByCantonIdQuery, GetDistrictsByCantonIdResult>
{
    public async Task<GetDistrictsByCantonIdResult> Handle(GetDistrictsByCantonIdQuery query,
        CancellationToken cancellationToken)
    {
        var districts = await repository.GetDistrictsByCity(query.CityId);
        return new GetDistrictsByCantonIdResult(districts);
    }
}