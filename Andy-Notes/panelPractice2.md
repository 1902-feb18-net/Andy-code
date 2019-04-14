# More preactice!
- im sleepy
- commit sudoku for needing a repanel...

### What is Docker?
A tool to make it easier to create, deploy, and run apps by using containers. Containers allows you to package up an app with all the parts it needs such as libraries and other dependencies and ship in one package. 

Docker containers: containers are runtime environments. You usually run one main process in one Docker container. You can think of this like one Docker container provides one service in your project.

docker image is an instance of a container. A file composed of many layers used to execute code in a Docker container. essentially built from the instructions for a complete and executable version of an application, which relies on the host OS kernel.

Docker containers are started by running a Docker image. A Docker image is not a runtime, it’s rather a collection of files, libraries and configuration files that build up an environment.

### Docker Workflow?
An application is composed of your own services plus additional libraries (dependencies). The following are the basic steps you usually take when building a Docker application (testing on a dev's computer)
- coding your app
	- create initial app or service baseline
- write Dockerfile/s
	- need a Dockerfile for each custom image you want to build and for each container to be deployed.
	- contains the commands that tell Docker how to set up and run your app or service in container
- create images defined at Dockerfile/s
	- can generally do this with `docker build` from the Docker CLI
	- if app made from multiple containers can use `docker-compose up --build` to build all related images by using metadata from docker-compose.yml file
- Define services by writing docker-compose.yml
	- lets you define a set of related services to be deployed as a composed application with deployment commands
	- configures dependency relations and run time configurations
- Run containers/compose app
	- if only single container can run by deploying to Docker host
		- can do with docker run
	- if many services, then deploy as composed application using docker-compose up
		- uses the docker-compose.yml file to deploy multi container application
- test your app or microservices
	- check in browser with the url and port you defined or using curl with url
- push or continue developing


### Containers vs VM?
Rather than creating a whole virtual OS, docker allows the usage of the same linux kernel as the system it's running on. Gives performance boost and reduces the size of the app. 

### What is a dockerfile?
A Dockerfile is a text file that defines a Docker image. Docker’s main purpose is to give us run-time environments that we can re-create/reproduce on any machine (that runs Docker). It is used to define your custom environment to be used in a Docker container.

After you create a dockerfile you execute with a `docker build` and now you can use this image to start containers with `docker run`

Docker builds images automatically by reading the instructions from a Dockerfile -- a text file that contains all commands, in order, needed to build a given image. 

A Docker image consists of read-only layers each of which represents a Dockerfile instruction. The layers are stacked and each one is a delta of the changes from the previous layer.

```
FROM ubuntu:18.04
COPY . /app
RUN make /app
CMD python /app/app.py
```

Each instruction creates one layer:
- FROM creates a layer from the ubuntu:18.04 Docker image.
- COPY adds files from your Docker client’s current directory.
- RUN builds your application with make.
- CMD specifies what command to run within the container.

### Docker CLI?
Similar to bash, Docker has it's own commands that can run within its command line. 
Some of the common ones that we use are:
- docker build (builds Docker images from a Dockerfile and a “context”)
- docker run (Run a docker container based on an image)
- docker create
- docker kill (does not attempt to shut down the process gracefully first)
- docker stop (Stops one or more containers)
- docker container ls
- docker start
- docker images
- docker pull (To download a particular image, or set of images)
- docker ps (list running containers)
- docker logs (display the logs of a container)
- docker rm (removes containers)

### Docker Commands?
most common ones are FROM, COPY, RUN, ENV, EXPOSE, CMD

ENTRYPOINT: Allows you to configure a container that will run as an executable.

EXPOSE: Informs Docker that the container listens on the specified network ports at runtime.

FROM: Sets the base image to use for subsequent layers

WORKDIR: Sets the working directory for any RUN, CMD, ENTRYPOINT, COPY, and ADD instructions that follow it in the Dockerfile.

CMD: The main purpose of a CMD is to provide defaults for an executing container. 

### What is a Docker compose, orchestration, and stack?

Docker compose is where you use a YAML file to configure your app's services. Then with a command you create and start all the services from your configuration.

steps: define app env with a dockerfile so it can be reproduced anywhere. Then you define the services that makes up your app that can run together in isolated environment. Run dock-compose up and compose starts to run your app.

Docker orchestration is a way of managing groups of containers that makes up the app into logical units for easy management. Kubernetes and Docker Swarm are examples. 

Docker stack is a group of interrelated services that share dependencies and can be orchestrated and scaled together. Single stack can define and coordinate functionality of entire app.

### WHAT is a docker container?
A container is a standard unit of software that packages up code and all its dependencies so the application runs quickly and reliably from one computing environment to another. A Docker container image is a lightweight, standalone, executable package of software that includes everything needed to run an application: code, runtime, system tools, system libraries and settings.