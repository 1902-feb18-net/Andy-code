# multi stage build - FROM command can name a stage
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /app

# COPY . ./

# # publish to /app/out
# RUN dotnet publish -c Release -o out

# takes advantage of docker layer caching
# these two layers will be cached so long as the csproj file(s) does not change
COPY ./*.csproj ./
RUN dotnet restore

# if i just change a .cs file, then i can use that cache and the next line will
# be the first one to actually run
COPY . ./

RUN dotnet publish --no-restore -c Release -o out

# docker allows us to use some layers just temporarily
# and then copy certain files out of them onto a new base image
# this means the resulting image will be smaller

# asp net core runtime image (smaller than sdk)
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime

WORKDIR /app

# copy from a prev stage instead of from outside Docker
COPY --from=build /app/out ./

# set env var inside image
# asp.net core looks at this when seeing what port to put itself on
# ENV ASPNETCORE_URLS=http://*:5050;https://*:5051
# EXPOSE by itself does nothing -- but hints to the guy running the container from this image
# that he should bind to 5050 or something
# EXPOSE 5050

# there is technical diff between CMD and ENTRYPOINT
# default entry is similar to /bin/sh -c "(CMD)"

ENTRYPOINT ["dotnet", "MvcBetterBuild2.dll"]

# best of both worlds from multi stage build:
# repeatable build env, plus small image size

# run: docker build -t mvc-better-build:0.1 .
# docker run mvc-better-build:0.1

# docker run -d -p 5000:80 mvc-better-build:0.1
# docker run --rm -d -p 5000:80 mvc-better-build:0.1

# go to: http://192.168.99.100:5000/ to view the code

# docker container ls
# docker rm -f someContainer



# dotnet add package.Newtonsoft.Json