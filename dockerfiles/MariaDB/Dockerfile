FROM mariadb

ADD ./run_container.sh /opt/run_container.sh
ADD ./setupumbraco.sql /opt/setupumbraco.sql

# expose TCP port 3306 from container
EXPOSE 3306

WORKDIR /data

# Define default command.
# CMD ["/bin/bash", "/opt/run_container.sh"]