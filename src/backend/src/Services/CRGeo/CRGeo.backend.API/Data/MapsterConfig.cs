namespace CRGeo.backend.API.Data;

public static class MapsterConfig
{
    public static void RegisterProvinceMapping()
    {
        TypeAdapterConfig<IDictionary<string, object>, Province>.NewConfig()
            .Map(dest => dest.ProvinceId, src => src["province_id"])
            .Map(dest => dest.ProvinceName, src => src["province_name"]);
    }
}