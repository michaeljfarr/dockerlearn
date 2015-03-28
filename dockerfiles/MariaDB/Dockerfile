#the purpose of this is just to setup the base application and download all the packages, 
#this saves us from needing to re-run nuget for every package every time a changes is made
#instead, the application is built out of the next Docker in the chain - webapi/herolab
FROM dockerfile/mariadb

# expose TCP port 3306 from container
EXPOSE 3306
# Configure the image as an executable
# When the image starts it will execute the “k web” command
# effectively starting our web application
# (listening on port 3306 by default)
ENTRYPOINT ["mysql", "-p", "3306:3306", "dockerfile/mariadb"]