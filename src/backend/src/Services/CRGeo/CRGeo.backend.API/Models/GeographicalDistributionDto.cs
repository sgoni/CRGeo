namespace CRGeo.backend.API.Models;

public class GeographicalDistributionDto
{
    public int ProvinceId { get; set; }
    public string ProvinceName { get; set; }
    public int CantonId { get; set; }
    public string CantonName { get; set; }
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }
}