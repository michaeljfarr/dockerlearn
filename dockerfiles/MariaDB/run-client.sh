#!/bin/sh

TAG="dockerfile/mariadb"

#CONTAINER_ID=$(docker ps | grep $TAG | awk '{print $1}')

IP=$(ipconfig getifaddr en0)

docker run -t -i dockerfile/mariadb mysql -u umbraco -p -h $IP