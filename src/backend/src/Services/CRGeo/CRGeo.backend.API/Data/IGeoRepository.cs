namespace CRGeo.backend.API.Data;

public interface IGeoRepository
{
    Task<IEnumerable<Province>> GetProvinces();
    Task<IEnumerable<GeographicalDistributionDto>> GetCantonsByProvince(int provinceId);
    Task<IEnumerable<GeographicalDistributionDto>> GetDuctrictsByCity(int cityId);
}