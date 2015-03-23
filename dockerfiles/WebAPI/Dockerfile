#the purpose of this is just to setup the base application and download all the packages, 
#this saves us from needing to re-run nuget for every package every time a changes is made
#instead, the application is built out of the next Docker in the chain.
FROM aspnet/herolab
# copy the solution folder (which is mapped using virtualbox folder share) to /app/ on the image
ADD Herolab /app/

# todo: figure out how to get git clone directly from github to work.
# Create known_hosts
#RUN touch /root/.ssh/known_hosts
# Add github.com key
#RUN ssh-keyscan github.com >> /root/.ssh/known_hosts

# set the working directory for subsequent commands
WORKDIR /app
# fetch the NuGet dependencies for our application
RUN kpm restore
