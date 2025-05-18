namespace CRGeo.backend.API.Data;

public static class MapsterConfig
{
    public static void RegisterProvinceMapping()
    {
        TypeAdapterConfig<IDictionary<string, object>, Province>.NewConfig()
            .Map(dest => dest.ProvinceId, src => src["province_id"])
            .Map(dest => dest.ProvinceName, src => src["province_name"]);
    }
    
    public static void RegisteGeographicalDistributionMapping()
    {
        TypeAdapterConfig<IDictionary<string, object>, GeographicalDistributionDto>.NewConfig()
            .Map(dest => dest.ProvinceId, src => src["province_id"])
            .Map(dest => dest.ProvinceName, src => src["province_name"])
            .Map(dest => dest.CantonId, src => src["canton_id"])
            .Map(dest => dest.CantonName, src => src["canton_name"])
            .Map(dest => dest.DistrictId, src => src["district_id"])
            .Map(dest => dest.DistrictName, src => src["district_name"]);
    }
}