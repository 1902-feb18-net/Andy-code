# domain specific language using dll

# before building this image, I should run
# dotnet publish -c Release -o out

# the parts of this image identifier
#     "registry"       "name/repo"       "tag"
#         v              V                 V
FROM mcr.microsoft.com/dotnet/core/runtime:2.2

# this copies out/ folder next to Dockerfile (outside Docker) 
# to /app folder inside Docker image
COPY out/ /app

# this sets bash as the command to run when container starts
# CMD ["/bin/bash"]
# this sets this to run when container starts
CMD ["dotnet", "/app/DevopsCode.dll"]
# weird error message means wrong path

# docker run -it (some string generated after docker build .)

# after docker build 
# grab the string and run `docker run (string)` and runs our code

# docker build . -t username/console-app:1.0
# tags works like branches (-t is a tag)

# docker push andyly25/console-app:1.0
# now to run: docker run andyly25/console-app:1.0
# goes really fast
