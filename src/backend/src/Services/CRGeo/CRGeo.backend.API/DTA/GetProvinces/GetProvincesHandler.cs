namespace CRGeo.backend.API.DTA.GetProvinces;

public record GetProvincesQuery : IQuery<GetProvincesResult>;

public record GetProvincesResult(IEnumerable<Province> Provinces);

internal class GetProvincesHandler(IGeoRepository repository) : IQueryHandler<GetProvincesQuery, GetProvincesResult>
{
    public async Task<GetProvincesResult> Handle(GetProvincesQuery query, CancellationToken cancellationToken)
    {
        var provinces = await repository.GetProvinces();
        return new GetProvincesResult(provinces);
    }
}