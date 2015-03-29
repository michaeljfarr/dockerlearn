FROM dockerfile/mariadb

ADD ./init_mariadb_container.sh /opt/init_mariadb_container.sh
ADD ./setupumbraco.sql /opt/setupumbraco.sql

# expose TCP port 3306 from container
EXPOSE 3306

WORKDIR /data

# Define default command.
# CMD ["/bin/bash", "/opt/init_mariadb_container.sh"]