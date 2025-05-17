echo CRGeo APi mounting
docker compose -f docker-compose.yml -f docker-compose.override.yml up -d --build
sleep 20 # sleep 20 seconds to give time to docker to finish the setup
read -p "Press enter tro continue"