#!/bin/sh


docker run  -d -p 3306:3306 --volumes-from umbracodbdata mariadb/herolab /bin/bash /opt/init_mariadb_container.sh

#docker run -i -t -d -p 3306:3306 -v /Users/mike/Projects/dockerlearn/var/data/umbracodb:/var/lib/mysql mariadb/herolab /bin/bash
#docker run -i -t -p 3306:3306 --volumes-from umbracodbdata mariadb/herolab /bin/bash


