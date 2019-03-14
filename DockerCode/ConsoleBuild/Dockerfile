# a comment
FROM mcr.microsoft.com/dotnet/core/sdk:2.2

# cd into directory
WORKDIR /app/src

# copy whole dir containing DockerFile...
# ... into current dir inside the image (/app/src, right now)
COPY ./ .

RUN dotnet build -c Release

CMD ["dotnet", "run"]

# run 
# docker build . -t username/console-build:1.0
# docker run username/console-build:1.0