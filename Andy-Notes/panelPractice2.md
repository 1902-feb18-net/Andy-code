# More preactice!
- im sleepy
- commit sudoku for needing a repanel...

## Week 2: SQL(SQL server), Entity Framework
ugh... one week took forever, let's get this one over with soon

### Queries
- queries (SELECT, WHERE, GROUPBY, JOINS, etc...)
	- grab the names that has a higher salary than first name John
		- SELECT FIRST_NAME
		- FROM Employees as e
		- WHERE e.SALARY > (SELECT e2.SALARY FROM Employee e2 Where FIRST_NAME = 'John')
	- grab the average salaries of each department within a company
		- SELECT AVG(e.salary)
		- FROM Employee AS e
		- WHERE e.departmentId = (SELECT DISTINCT id FROM Department) -- where depid = 3 if we want from one department
		-	```sql
			SELECT AVG(e.salary)
			FROM Employee AS e
			--JOIN Department as d ON e.departmentId = d.depId
			--GROUP BY d.depId
			GROUP BY e.departmentId
			```
	- grab the count of employees within each department
		- SELECT COUNT(e)
		- FROM EMPLOYEES as e
		- WHERE e.departmentId = (SELECT id FROM Department)
		- GROUPBY Department
		-	```sql
			SELECT e.departmentId, Count(e.empId)
			FROM Employee AS e
			GROUP BY e.departmentId
			ORDER BY e.departmentId
			```

### What is normalization?
Normalization is a way of organizing data withing a relational db design to minimize redundancy. This usually involves dividing a table into two or more tables and defining their relationships with one another. problems with redundancy is that it can cause insert, delete and update anomalies.

There are 3 main normal forms that should be taken into consideration.
1. 1nf: no duplicate rows and columns with atomic values
2. 2nf: should contain 1nf and no partial dependency
3. 3nf: should contain 2nf and no transitive dependency

### What is the difference between a primary key and foreign key?
Primary key consists of one or more col whose data contained within is used to uniquely identify each row in the table. To be a primary key, the columns must be unique and no values within columns can be blank or NULL. When defining a table you specify the primary key and a table has just one primary key with its definition mandatory.

Foreign keys is a set of one or more columens in a table that refers to the primary keys in another table. We can enter in FK constraints to enforce referential integrity so that it stops you from entering in values that aren't found in the related table's primary key. 

### Union vs Join
Union combines two SELECT staements into a single result set which inclues all the rows that belong to the Select statments in the union. Number and order of col the same and data types must be the same or compatible. 

So join technically combines columns from two tables while union combines rows from two queries. Join appends the results horizontally, while union appends results vertically

### What is Scalar in TSQL?
it essentially acts similar to a function where we define a CREATE FUNCTION with an optional schema and the name of the function. Then you list out the parameter it takes in. We then specify the return value in return statement. And finally within the Begin and END body we run statements to return a value. 

```sql
CREATE FUNCTION [schema_name.]function_name (parameter_list)
RETURN data_type AS
BEGIN
    statements
    RETURN value
END
```

### Clustered vs nonclustered?
Clustered is where the rows are stored physically on the disk in the same order as the index. This means there can only be one clustered index. Nonclustered is where we have a 2nd list that has pointers to the physical rows, and you can have many non clustered indexes.

Clustered index is used for easy retrieval of data from the database by altering the way that the records are stored. Database sorts out rows by the column which is set to be clustered index.

A nonclustered index does not alter the way it was stored but creates a complete separate object within the table. It point back to the original table rows after searching.

A clustered index defines the order in which data is physically stored in a table. Table data can be sorted in only way, therefore, there can be only one clustered index per table.

A non-clustered index doesn’t sort the physical data inside the table. In fact, a non-clustered index is stored at one place and table data is stored in another place. This is similar to a textbook where the book content is located in one place and the index is located in another. This allows for more than one non-clustered index per table.

### What is the difference between DML and DDL?
DML stands for Data Manipulation Language where we manipulate data in an SQL database. These include these commands: INSERT, DELETE, UPDATE, SELECT, TRUNCATE

DDL stands for Data Definition Language where we generally define schemas and create databases with these commands: CREATE, ALTER, DROP

### What are the data types in T-SQL?
tinyint, smallint, int, bigint, float, real, numeric

money, datetime2, char, varchar, nchar, nvarchar, date, time, datetime, datetimeoffset

### What is Scalar in TSQL?
it essentially acts similar to a function where we define a CREATE FUNCTION with an optional schema and the name of the function. Then you list out the parameter it takes in. We then specify the return value in return statement. And finally within the Begin and END body we run statements to return a value. 

```sql
CREATE FUNCTION [schema_name.]function_name (parameter_list)
RETURN data_type AS
BEGIN
    statements
    RETURN value
END
```

### What is ACID? What is Isolation?
- Atomicity: operations completed 100% or not at all
- Consistency: operations should follow constraints
- Isolation: even if many transactions run at same time, it should be as if it was running by itself
- Durable: data should be stored in somewhere persistent

To go deeper into isolation, there are 4 levels of isolation 
1. read_uncommitted
2. read_committed: fixes dirty read (see other transactions unfinished work)
3. repeatable_read: fixeds nonrepeatable read (reading rows more than once, another transaction change in between)
4. serializable: fixed phantom read(transactions can insert rows that meets conditions)
	- data getting changed in current transactions by other transactions

### What is ADO.NET? Connected and Disconnected architecture?
Active Data Objects

Connected architecture is where we are constantly connected to a database to retrieve data. We gennerally start with opening a connection. Then we execute some command.ExecuteReader() that returns a DataReader for SELECT queries. We then process the results and finally close the connection when finished. 

Disconnected is where we open a connection to the database to grab what we need and store it into some variable to be used. We want to minimize the amount of time the connection spends open since it costs resources to keep open(although faster). We open a connection, then we fill a dataSet by using the DataAdapter. Then we close thc onnection and process results which contains our dataset that containes some DataTable with its rows and columns. 

### DbSet vs DataSet
- The DbSet class represents an entity set that can be used for create, read, update, and delete operations.
	- The context class (derived from DbContext) must include the DbSet type properties for the entities which map to database tables and views.
- DataSet is a collection of datatables. We can store the database table, view data in the DataSet and can also store the xml value in dataset and get it if required. 
	- To achieve this you need to use DataAdapter which work as a mediator between Database and DataSet.

### What is Entity Framework?
Entity framework is an ORM which stands for Object Relational Mapping that enables .NET devs to work with a db using .NET objects. Our .NET project usually consists of a UI, BLL, and DAL and Entity Framework would go within the DAL. What it does is to save data stored in properties of business entities and retrieves data from the db and converts to business entity objects automatically. 

Another definition is: a tool that simplifies mapping between objects in your software to the tables and columns of a relational db. Takes care of creating db connections and executing commands as well as taking query results and auto materializing those results in your app objects. It also keeps track of changes to those objects and when instructed persist those changes back to the db for you. 

Features it contains:
- cross-platform can run on many OS like windows, linux, mac
- Modelling: creates an EDM (entity data model) with get and set properties of different data types
- Querying: allows usage of LINQ (language integrated query) to retrieve data from underlying db. 
- Allows you to execute INSERT, UPDATE, DELETE commands to db based on changes occured to your entities when you call SaveChanges() or SaveChangesAsync()
- Allows set of migration commands that can be executed. 

### Setting up database first?
1.  Have startup project and data access library project.
2.  Reference data access from startup project
3.  Add NuGet packages to startup project
4.  Open package manager console in VS
5.  Run command
	- `Scaffold-DBContext "<your-connection-string>" Microsoft.EntityFrameworkCore.SqlServer -Project <name-of-data-project> -Force`
6.  Delete OnConfiguring override in the DbContext
7.  Any time we change the DB go to step 4

### What is the difference between IEnumerable and IQueryable?
`IQueryable<T>` takes expression objects instead of delegates IQueryable inherits from IEnumerable, so can do anything IEnumerable can do
IQueryable<T> allows for out of memory things like a remote datasource, such as a db or web service

IEnumerable<T> is great for working with sequences that are iterated in-memory. Useful when your collection is loaded using LINQ or Entity framework and you want to apply filter on the collection. (e.g. using .Where())

The main thing is where the filter is applied. IQueryable has the filter on db side and IEnumerable has on client side. If working in-memory IEnumerable is better. If connected to a db then IQueryable is better as it reduced network traffic and uses power of SQL language. 

---

## Microservice AKA Docker...

### What is Docker?
A tool to make it easier to create, deploy, and run apps by using containers. Containers allows you to package up an app with all the parts it needs such as libraries and other dependencies and ship in one package. 

Docker containers: containers are runtime environments. You usually run one main process in one Docker container. You can think of this like one Docker container provides one service in your project.

docker image is an instance of a container. A file composed of many layers used to execute code in a Docker container. essentially built from the instructions for a complete and executable version of an application, which relies on the host OS kernel.

Docker containers are started by running a Docker image. A Docker image is not a runtime, it’s rather a collection of files, libraries and configuration files that build up an environment.

Docker wraps up bits and pieces of software with all the needed filesystems containing everything that needs to run the code, provide the runtime, system tools / libraries. This will ensure that the software is always run and executed the same, regardless of the environment.

Containers run on the same machine sharing the same Operating system Kernel, this makes it faster – as starting the applications is the only time that is required to start your Docker container (remember that the OS Kernel is already UP and running and uses the least of the RAM possible).

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

Docker is light weight and more efficient in terms of resource uses because it uses the host underlying kernel rather than creating its own hypervisor.

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

1. Docker containers include the application and all of its dependencies, but share the kernel with other containers, running as isolated processes in user space on the host operating system. Docker containers are not tied to any specific infrastructure: they run on any computer, on any infrastructure, and in any cloud.
2. Now explain how to create a Docker container, Docker containers can be created by either creating a Docker image and then running it or you can use Docker images that are present on the Dockerhub.
3. Docker containers are basically runtime instances of Docker images.

### Difference between Docker Image and container?

Docker container is the runtime instance of docker image.

Docker Image doesnot have a state and its state never changes as it is just set of files whereas docker container has its execution state.

### What is a Docker Image?
Docker image can be understood as a template from which Docker containers can be created as many as we want out of that single Docker image. Having said that, to put it in layman terms, Docker containers are created out of Docker images. Docker images are created with the build command, and this produces a container that starts when it is run. Docker images are stored in the Docker registry such as the public Docker registry (registry.hub.docker.com) as these are designed to be constituted with layers of other images, enabling just the minimal amount of data over the network.

