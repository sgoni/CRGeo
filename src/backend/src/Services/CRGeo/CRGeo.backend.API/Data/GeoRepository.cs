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
        var nameSpace = string.Concat(SqlLoader.ProjectName(), ".", "Sql.Dta.GetProvinces.sql");
        var sql = SqlLoader.LoadSql(nameSpace);
        using var connection = _context.CreateConnection();
        var result = await connection.QueryAsync<dynamic>(sql);
        return result
            .Select(x => ((IDictionary<string, object>)x).Adapt<Province>());
    }

    public async Task<IEnumerable<GeographicalDistributionDto>> GetCantonsByProvince(int provinceId)
    {
        var nameSpace = string.Concat(SqlLoader.ProjectName(), ".", "Sql.Dta.GetCitiesByProvinceId.sql");
        var sql = SqlLoader.LoadSql(nameSpace);
        using var connection = _context.CreateConnection();
        var result = await connection.QueryAsync<dynamic>(sql, new { Id = provinceId });
        return result
            .Select(x => ((IDictionary<string, object>)x).Adapt<GeographicalDistributionDto>());
    }

    public async Task<IEnumerable<GeographicalDistributionDto>> GetDistrictsByCity(int cityId)
    {
        var nameSpace = string.Concat(SqlLoader.ProjectName(), ".", "Sql.Dta.GetDistrictsByCityId.sql");
        var sql = SqlLoader.LoadSql(nameSpace);
        using var connection = _context.CreateConnection();
        var result = await connection.QueryAsync<dynamic>(sql, new { Id = cityId });
        return result
            .Select(x => ((IDictionary<string, object>)x).Adapt<GeographicalDistributionDto>());
    }
}