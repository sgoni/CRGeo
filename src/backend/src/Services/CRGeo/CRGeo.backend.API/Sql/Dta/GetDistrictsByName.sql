select *
from geo_distribution_view
where trim(lower(district_name)) = trim(lower(@Name));