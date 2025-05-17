-- Inserción de provincias (7 registros)
INSERT INTO provinces (province_id, province_name) VALUES
  (1, 'San José'),
  (2, 'Alajuela'),
  (3, 'Cartago'),
  (4, 'Heredia'),
  (5, 'Guanacaste'),
  (6, 'Puntarenas'),
  (7, 'Limón');

-- Inserción de cantones usando COPY desde el archivo CSV
-- Se asume que el archivo se encuentra en el contenedor en la ruta
-- /docker-entrypoint-initdb.d/data/cantons.csv
COPY cantons(canton_id, canton_name, province_id)
FROM '/docker-entrypoint-initdb.d/data/cantons.csv'
WITH (FORMAT csv, HEADER true);

-- Inserción de distritos usando COPY desde el archivo CSV
-- Se asume que el archivo se encuentra en el contenedor en la ruta
-- /docker-entrypoint-initdb.d/data/districts.csv
COPY districts(district_id, district_name, canton_id)
FROM '/docker-entrypoint-initdb.d/data/districts.csv'
WITH (FORMAT csv, HEADER true);