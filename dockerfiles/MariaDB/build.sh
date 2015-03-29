#!/bin/sh
docker rm $(docker ps -a | grep umbracodbdata | awk '{print $1}')
docker create -v /var/lib/mysql --name umbracodbdata dockerfile/mariadb
docker build -t="mariadb/herolab" .
docker run -it -d -p 3306:3306 --volumes-from umbracodbdata mariadb/herolab /bin/bash -c "rm -rf /var/lib/mysql/*"
