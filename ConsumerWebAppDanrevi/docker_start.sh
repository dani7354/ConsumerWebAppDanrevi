#!/bin/sh
docker pull dani7354/danrevi-webapi -qq
docker pull dani7354/danrevi-apiconsumer -qq
echo "Opdaterer Docker-billeder" 

docker run -d -p 80:8000 dani7354/danrevi-webapi
echo "API startet!"
docker run -d -p 80:80 dani7354/danrevi-apiconsumer
echo "Consumer startet!"


