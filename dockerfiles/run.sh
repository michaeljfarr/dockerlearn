
cd /home/docker/
ln -s Projects/dockerlearn/ host

#build our image from mono and add the latest asp.net stuff into it
cd /home/docker/host/dockerfiles/Mono
docker build -t="aspnet/herolab" .
docker run -t -v /Users/mike/host/Herolab:/app -p 8080:5000 aspnet/herolab kpm restore
docker commit -m "Restored kpm" $(docker ps -l | sed -n 2p | awk '{print $1}') webapi/herolab
#docker run -t -i -p 8080:5000 -v /Users/mike/host/Herolab:/app webapi/herolab /bin/bash
docker run -d -t -i -p 8080:5000 -w /app/Herolab.WebAPI -v /Users/mike/host/Herolab:/app webapi/herolab k web

cd /home/docker/host/dockerfiles/MariaDB
docker build -t="mariadb/herolab" .
docker run -t -i -p 3306:3306 mariadb/herolab mysqld_safe
docker run -t -i -p 3306:3306 mariadb/herolab /bin/bash
#mysqld_safe &
#mysql
#docker run -t -i -p 3306:3306 dockerfile/mariadb /bin/bash

#mysql -h 192.168.178.48 -u umbraco  umbracodb -p
echo 'CREATE DATABASE umbracodb;' > setupumbraco.sql 
echo "CREATE USER umbraco IDENTIFIED BY 'fDP1weZqgdlM';" >> setupumbraco.sql
echo 'GRANT ALL ON umbracodb.* TO umbraco;' >> setupumbraco.sql

docker commit -m "created umbracodb" $(docker ps -l | sed -n 2p | awk '{print $1}') mariadb/herolab

docker run -d -t -i -p 3306:3306 mariadb/herolab 'mysqld_safe'
