docker run -t -i -p 8081:5000  -w /app/dockerlearn/Herolab --add-host="mysql.local:192.168.178.48" -v /Users/mike/Projects:/app webapi/herolab /bin/bash
