# Commands to run on terminal

## Main Repo
- https://github.com/revaturexyz

## Deployed URL
- https://revaturexyz-housing-dev.southcentralus.cloudapp.azure.com/
- https://revaturexyz-housing-dev.southcentralus.cloudapp.azure.com/api/users
- https://revaturexyz-housing-dev.southcentralus.cloudapp.azure.com/api/rooms
- https://revaturexyz-housing-dev.southcentralus.cloudapp.azure.com/api/batches
- https://revaturexyz-housing-dev.southcentralus.cloudapp.azure.com/api/selection/batches
- https://revaturexyz-housing-dev.southcentralus.cloudapp.azure.com/api/forecast/locations

## URLS after you set up docker containers
http://192.168.99.100:9050/api/users

http://192.168.99.100:9030/api/rooms

http://192.168.99.100:9040/api/batches

http://192.168.99.100:9020/api/forecast/snapshots

### now for the https
https://192.168.99.100:9051/api/users

https://192.168.99.100:9031/api/rooms

https://192.168.99.100:9041/api/batches

https://192.168.99.100:9021/api/forecast/snapshots

## To switch from deployed to testing locally
The configuration "Settings:ServiceHubConnection" decides where the service hub
is located. The default in Development is to connect to the deployed APIs
on Azure. To temporarily override this, add a line to the .windev file under
the other environment variables:

```
      - Settings__ServiceHubConnection=DockerMachineHttp
```

## Testing interface-web-forecast
you need to run these commands everytime you make changes to the angular code

`npm run build-lib`

`ng s -o`

after some changes, don't need to run the first command anymore, just serve it and should work like normal


## Docker
some commands you can use

### to remove containers
- docker stack rm servicehub-user-stack
- docker stack rm servicehub-room-stack
- docker stack rm servicehub-batch-stack
- docker stack rm housing-forecast-stack
- docker stack rm housing-selection-stack

### If you see docker swarm message
- run: `docker swarm init --advertise-addr 192.168.99.100` as an example

### to build and deploy containers
- docker build -t servicehub-room .
- docker stack deploy -c dockerup.windev.yml servicehub-room-stack
- docker build -t servicehub-user .
- docker stack deploy -c dockerup.windev.yml servicehub-user-stack
- docker build -t servicehub-batch .
- docker stack deploy -c dockerup.windev.yml servicehub-batch-stack
- docker build -t housing-forecast .
- docker stack deploy -c dockerup.windev.yml housing-forecast-stack
- docker build -t housing-selection .
- docker stack deploy -c dockerup.windev.yml housing-selection-stack

### **trying to run VS locally**

the config has the service looking for the DB at 192.168.99.100 instead of in a docker
service. (According to appsettings.Development.json, which is otherwise
overridden in the dockerup.windev.yml file.)

`docker run --rm -d -p 5432:5432 postgres`

The configuration "Settings:ServiceHubConnection" decides where the service hub
is located. The default in Development is to connect to the deployed APIs
on Azure. To temporarily override this, change appsettings.Development.json,
or add to user secrets:

```
{
  "Settings": {
    "ServiceHubConnection": "DockerMachineHttp"
  }
}
```

- **NOTE TO SELF:** remember to remove the changes I made to test locally
	- within housing-forecast (this was if testing for docker)
		- dockerup.windev.yml
		    - Settings__ServiceHubConnection=DockerMachineHttp
		- appsettings.Development.json
			-  "ServiceHubConnection": "DockerMachineHttp"
			- original is "AzureHttps"
	- within interface-web-forecast
		- in environment.ts we uncommented the url to test locally
		- original was `https://revaturexyz-housing-dev.southcentralus.cloudapp.azure.com/api/forecast`

## within terminal to pull all (assumption on broker branch)
- cd housing-forecast
- git pull
- cd ..
- cd housing-selection
- git pull
- cd ..
- cd interface-web
- git pull
- cd ..
- cd interface-web-forecast
- git pull
- cd ..
- cd interface-web-selection
- git pull
- cd ..
- cd servicehub-batch
- git pull
- cd ..
- cd servicehub-user
- git pull
- cd ..
- cd servicehub-room
- git pull
- cd ..
