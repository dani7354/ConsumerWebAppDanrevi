#!/bin/sh
docker pull dani7354/danrevi-webapi > /dev/null
docker pull dani7354/danrevi-apiconsumer > /dev/null
echo "Opdaterer Docker-billeder" 

docker run -d -p 8000:80 dani7354/danrevi-webapi
echo "API startet!"
docker run -d -p 80:80 dani7354/danrevi-apiconsumer
echo "Consumer startet!"


