#docker run -t -i -p 8080:5000 -v /Users/mike/host/Herolab:/app webapi/herolab /bin/bash
docker run -d -t -i -p 8080:5000  --add-host="mysql.local:192.168.178.48" -w /app/dockerlearn/Herolab/Herolab.WebAPI -v /Users/mike/Projects:/app webapi/herolab k web

