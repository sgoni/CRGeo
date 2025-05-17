CREATE MATERIALIZED VIEW geo_distribution_view AS
SELECT 
    p.province_id,
    p.province_name,
    c.canton_id,
    c.canton_name,
    d.district_id,
    d.district_name
FROM 
    provinces p
JOIN 
    cantons c ON c.province_id = p.province_id
JOIN 
    districts d ON d.canton_id = c.canton_id;
