cd /Users/mike/Projects/dockerlearn/dockerfiles/Mono
docker build -t="aspnet/herolab" .
docker run -t -v /Users/mike/Projects:/app -w /app/dockerlearn/Herolab -p 8080:5000 aspnet/herolab kpm restore
docker commit -m "Restored kpm" $(docker ps -l | sed -n 2p | awk '{print $1}') webapi/herolab
docker run -t -v /Users/mike/Projects:/app -w /app/dockerlearn/dockerfiles/Mono -p 8080:5000 webapi/herolab /bin/bash init_mono_container.sh
docker commit -m "Restored kpm" $(docker ps -l | sed -n 2p | awk '{print $1}') webapi/herolab
	