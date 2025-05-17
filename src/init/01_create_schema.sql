-- Crear tabla de provincias
CREATE TABLE provinces (
    province_id SERIAL PRIMARY KEY,
    province_name VARCHAR(100) NOT NULL
);

-- Crear tabla de cantones
CREATE TABLE cantons (
    canton_id SERIAL PRIMARY KEY,
    canton_name VARCHAR(100) NOT NULL,
    province_id INTEGER NOT NULL REFERENCES provinces(province_id)
);

-- Crear tabla de distritos
CREATE TABLE districts (
    district_id SERIAL PRIMARY KEY,
    district_name VARCHAR(100) NOT NULL,
    canton_id INTEGER NOT NULL REFERENCES cantons(canton_id)
);
