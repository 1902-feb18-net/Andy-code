# Commands to run on terminal

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

### to build and deploy containers
- docker build -t servicehub-room .
- docker stack deploy -c dockerup.windev.yml servicehub-room-stack
- docker build -t servicehub-user .
- docker stack deploy -c dockerup.windev.yml servicehub-user-stack
- docker build -t servicehub-batch .
- docker stack deploy -c dockerup.windev.yml servicehub-batch-stack
- docker build -t housing-forecast .
- docker stack deploy -c dockerup.windev.yml housing-forecast-stack

### **trying to run VS locally**
currently haven't figured out

the config has the service looking for the DB at 192.168.99.100 instead of in a docker
service. (According to appsettings.Development.json, which is otherwise
overridden in the dockerup.windev.yml file.)

docker run --rm -d -p 5432:5432 postgres

nick fixed so https worked, check it out


## within terminal to pull all
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
