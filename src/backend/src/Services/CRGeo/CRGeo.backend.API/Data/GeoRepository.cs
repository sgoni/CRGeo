namespace CRGeo.backend.API.Data;

public class GeoRepository : IGeoRepository
{
    private readonly DapperContext _context;

    public GeoRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Province>> GetProvinces()
    {
        //var sql = SqlLoader.Load("Sql/Dta/Provinces.sql");
        var nameSpace = string.Concat(SqlLoader.ProjectName(), ".", "Sql.Dta.GetProvinces.sql");
        var sql = SqlLoader.LoadSql(nameSpace);
        using var connection = _context.CreateConnection();
        var result = await connection.QueryAsync<dynamic>(sql);
        return result
            .Select(x => ((IDictionary<string, object>)x).Adapt<Province>());
    }

    public Task<IEnumerable<GeographicalDistributionDto>> GetCantonsByProvince(int provinceId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GeographicalDistributionDto>> GetDuctrictsByCity(int cityId)
    {
        throw new NotImplementedException();
    }
}