FROM webapi/herolab
# copy the solution folder (which is mapped using virtualbox folder share) to /app/ on the image
ADD Herolab /app/

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