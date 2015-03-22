#the purpose of this is just to setup the base application and download all the packages, 
#this saves us from needing to re-run nuget for every package every time a changes is made
#instead, the application is built out of the next Docker in the chain - webapi/herolab
FROM webapi/herolab
# copy the solution folder (which is mapped using virtualbox folder share) to /app/ on the image
ADD Herolab /app/

# todo: figure out how to get git clone directly from github to work.
# Create known_hosts
#RUN touch /root/.ssh/known_hosts
# Add github.com key
#RUN ssh-keyscan github.com >> /root/.ssh/known_hosts

RUN mkdir -p /app/Herolab.WebAPI/wwwroot

# set the working directory for subsequent commands
WORKDIR /app
# fetch the NuGet dependencies for our application
RUN kpm restore
# set the working directory for subsequent commands
WORKDIR /app/Herolab.WebAPI
# expose TCP port 5000 from container
EXPOSE 5000
# Configure the image as an executable
# When the image starts it will execute the “k web” command
# effectively starting our web application
# (listening on port 5000 by default)
ENTRYPOINT ["k", "web"]