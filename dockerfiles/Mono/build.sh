cd /home/docker/host/dockerfiles/Mono
docker build -t="aspnet/herolab" .
docker run -t -v /Users/mike/host/Herolab:/app -p 8080:5000 aspnet/herolab kpm restore
docker commit -m "Restored kpm" $(docker ps -l | sed -n 2p | awk '{print $1}') webapi/herolab
#docker run -t -i -p 8080:5000 -v /Users/mike/host/Herolab:/app webapi/herolab /bin/bash
docker run -d -t -i -p 8080:5000 -w /app/Herolab.WebAPI -v /Users/mike/host/Herolab:/app webapi/herolab k web
