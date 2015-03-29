#!/bin/bash

if [ ! -f /var/lib/mysql/ibdata1 ]; then

    mysql_install_db

    /usr/bin/mysqld_safe &
    mysqladmin --silent --wait=30 ping || exit 1

    mysql < /opt/setupumbraco.sql 

    killall mysqld
    sleep 10s
fi

/usr/bin/mysqld_safe 