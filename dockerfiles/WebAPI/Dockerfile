#the purpose of this is just to setup the base application and download all the packages, 
#this saves us from needing to re-run nuget for every package every time a changes is made
#instead, the application is built out of the next Docker in the chain.
FROM aspnet/herolab
ADD Herolab /app/
# set the working directory for subsequent commands
WORKDIR /app
# fetch the NuGet dependencies for our application
RUN kpm restore
