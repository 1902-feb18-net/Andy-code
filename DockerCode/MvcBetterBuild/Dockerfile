# multi stage build - FROM command can name a stage
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /app

COPY . ./

# publish to /app/out
RUN dotnet publish -c Release -o out

# docker allows us to use some layers just temporarily
# and then copy certain files out of them onto a new base image
# this means the resulting image will be smaller

# asp net core runtime image (smaller than sdk)
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime

WORKDIR /app

# copy from a prev stage instead of from outside Docker
COPY --from=build /app/out ./

# there is technical diff between CMD and ENTRYPOINT
# default entry is similar to /bin/sh -c "(CMD)"

ENTRYPOINT ["dotnet", "MvcBetterBuild.dll"]

# best of both worlds from multi stage build:
# repeatable build env, plus small image size

# run: docker build -t mvc-better-build:0.1 .
# docker run mvc-better-build:0.1

# docker run -d -p 5000:80 mvc-better-build:0.1
# docker run --m -d -p 5000:80 mvc-better-build:0.1

# docker container ls
# docker rm -f someContainer