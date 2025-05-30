select *
from geo_distribution_view
where trim(lower(canton_name)) = trim(lower(@Name));