namespace CRGeo.backend.API.Data;

public interface IGeoRepository
{
    Task<IEnumerable<Province>> GetProvinces();
    Task<IEnumerable<GeographicalDistributionDto>> GetCantonsByProvince(int provinceId);
    Task<IEnumerable<GeographicalDistributionDto>> GetDistrictsByCity(int cityId);
    Task<IEnumerable<GeographicalDistributionDto>> GetCitiesByName(string city);
    Task<IEnumerable<GeographicalDistributionDto>> GetDistrictsByName(string city);
}