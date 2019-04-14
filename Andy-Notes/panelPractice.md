# panel Practice

## Week 1: C#, .Net, OOP, Testing
practice

### Explain to me what the OOP principles are?
First off, defining what OOP is. OOP is object oriented programming where we as the programmers are concerned with the objects we want to manipulate rather than the logic to manipulate them. 
Object Oriented Programming consists of 4 important concepts. They are namely: Inheritance, Polymorphism, Abstraction, and Encapsulation. 

Let's start with inheritance, similar to how humans work, objects that inherit from someone up top is what we call a parent, and the object doing the inheriting is the child. The child will carry some similarities to the parents, but they may be specialized in different ways like having different colored eyes, or able to play piano really well. Then this will eventually encroach on the idea of polymorphism.

Polymorphism is a way of changing what the method of an object does through overriding and overloading. In the case of overriding we can use the example of Animal with default method of MakeSound as "hello world!", now we make a child from Animal for example let's say dog, whose MakeSound is vastly different from "hello world!" and we override with "woof!". This is the way of changing the original functionality of the method to suit the object. Overloading in the example of shapes is how we have same method names that takes in different parameters. E.g. In case of a method called Area, Area of a square would take in just one parameter side, area of rectangle will take in length and width. 

Abstraction and Encapsulation are pretty similar where encapsulation is data hiding while abstraction is detail hiding. Encapsulation in a sense hides an object's data through a couple of access modifiers and a way we can access those is through using getters and setters. Those access modifiers are public, private, protected, internal, protected internal, and private protected. Public has no restrictions on what can access. Private it limited within the class definition. Protected is limited within the class and any class that inherits. Internal is limited only to classes within project assembly. Protected internal limited to current assembly and types derived from containing class. Private protected is limited to containing class or types derived from contained class within current assembly.

As mentioned before abstraction is detail hiding. For this example we are given a T.V. and we know how to turn the T.V. on and change channels, but we don't know exactly how the t.v. displays images or how electricity runs through it. All we care is that we are given everything we need to have the object behave how it should. 

### What are the differences between interface and abstract class?
Interfaces is more like a contract of what an object should contain, but all of the methods would contain no body. It can contain methods, properties, events and indexors as its members. Abstract needs at least one abstract method, but can provide a default implementation of methods. 

### What is a class and what is an object? Also struct vs class?
Class in a sense is a blue print for creating objects. Within a class could define properties, fields, events, methods and many more for what an object is. As a refresher, properties are defined within a class with accessor, name of property and finally a get and set accessor. Fields are things like int age = 10, they are generally private and is a variable that can hold a value. Methods are actions that an object can do. Constructors are called when you create an instance of a class. 

Objects are instances of a class that are the cornerstone of OOP. Typical program consists of multiple objects interacting dynamically. 

Structs are value types while classes are reference types. Reference types lives on the heap, while value types lives where we define our field or variable. So that means a variable contains the whole struct with all its fields. And reference is where we have some pointer that points to somehwere in memory where the value is stored. 

### What are the SOLID principles?
SOLID contains 5 principles that define a good software architecture. 

Single Responsibility Principle: A class should do one thing and does it well (e.g. a nail cutter should only cut nails)

Open Closed Principle: Open to extensions, but closed for modifications

Liskov Substitution principle: Child class should not break parent class's type definition and behavior. In a sense ensure inheritance is correct. 

Interface Segregation principle: Interfaces shouldn't do too many things at once and should be split up into smaller chunks. We only care about a small functionality of an interface and don't want to have access to all the other functionalities.

Dependency Inversion principle: Do not write tightly coupled code since it is hard to maintain when the app gets large. 


### What are delegates are how are they used?
Delegates in a sense a reference type variable used to store a reference to methods. It is a way to tell which method to be called when an event is triggered as one example. Delegates are used for call-back methods and events. We can pass delegates as paremeter for a method, which can then invoke within the method. 

### What are generics?
It is essentially where the user defines classes and methods with a placeholder. This is usually the T symbol. This helps reuse data process algorithms without replicating code. We use < and > sign to specify parameter type so when we are using the generic class we make an instance of gneric class we define its type within the < and > signs for example string or float. (e.g. `SomeClass<string> obj1 = new SomeClass<string>();`)

### Explain to me about the .NET Framework Platform Architecture
First we have something like an IDE like VS where we write code so what happens when we compile our code? Our code has to be converted into something that the machine can read and then process what we want. The first step is to convert to our code into an Intermediate Language which then goes into the CLR or Common Language Runtime which is a Virtual Execution System implementation. The IL is then converted into some kind of machine language which is then fed into the JIT compiler which then compiles and process our code instructions. 

k let's look at a more official definition
From a VS project -> compiler --creates-> Managed Assembly (.exe or .dll) MSIL metadata --IL and ref loaded by CLR-> CLR which contains a JIT compiler and uses .Net framework class libraries --converts to native machine code-> OS   

note CLR also provides other services like auto garbage collection, exception handling and resource management. 


### What is a constructor?
It is a special method of class that gets invoked whenever an instance of the class is created. A constructor contains a collection of instructions that are executed at the time of obj creation. Used mostly to assign initial values to the data members of the same class. A constructor without parameters is called a default constructor. It has every instance of the class to be initialized to the same values. Init all numeric fields to zero and all string and obj to null inside a class. 

### How do you perform unit tests in a .Net application?
In a .Net application we can perform xUnit tests that follows this AAA process. 
1. Arrange: where we arrange the necessary data or things we'll need to act upon
2. Act: where we use the things in arrange and plug into the methods we plan to test
3. Assert: we do some form of checks to assert if the results of the act is true or false

We can use a [Fact] or [Theory] attribute where fact takes no method arguments. Theory expects one or more DataAttribute instances to provide values for the method arguments. 

### Serialization
Serialization is the process of converting an obj into a form that can be readily transported. We can serialize an object and transport over internet using HTTP between a client and server. Deserialization converts it back into an object to be read from the stream. 
One method of serializing is XML serialization to generate an XML stream that conforms to a XML Schema document. We can serialize an instance of a DataSet. DataSet repreent an in-memory cache of data. For XML we would use an XmlSerializer

to use Json serializer we would need to import Newtonsoft nuget package and call the SerializeObject method. We pass to it the object we want to serialize and the second argument how to format the json string output. 

---

## Week 2: SQL(SQL server), Entity Framework
ugh... one week took forever, let's get this one over with soon


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

### What is the difference between DML and DDL?
DML stands for Data Manipulation Language where we manipulate data in an SQL database. These include these commands: INSERT, DELETE, UPDATE, SELECT, TRUNCATE

DDL stands for Data Definition Language where we generally define schemas and create databases with these commands: CREATE, ALTER, DROP

### What are the data types in T-SQL?
tinyint, smallint, int, bigint, float, real, numeric

money, datetime2, char, varchar, nchar, nvarchar, date, time, datetime, datetimeoffset


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


## Week 3: ASP.NET MVC, HTML, CSS
### What is new in HTML5 compared to the previous version?
- New structural elements such as: Nav, header, footer, main, article, aside
- new graphics and media elements such as canvas, audio, video
- new inputs like: color, data, datetime, number, range etc
- HTML5 introduces consistency in handling malformed documents, better web app features, improved element semantics


### CSS and its priorities?
- !important
- specificity with id, class, then everything else
	- inline styles has highest priority within this
- finally the most recent css gets higher priority

### CSS and its selectors?
CSS stands for Cascading style sheets and it presents the styling for a HTML page. You reference a CSS file at the top within the Head tag in an HTML document. 

CSS rules consists of a selector and its declaration block(property and values)

Selectors consists of:
- Element tags such as HTML, Body, p, a, div, and many more
- class represented with a .
- id with #
- , is for all of those selectors separated by comma
- space in between is for all selector within the first one
- div > p is where select all element where parent is to the left of the > sign
- div + p is select all p elements placed after the div
- p ~ ul select all ul element preceded by a p element
- [target] select all elements with a target attribute
- many more like :hover, :nth-child(n), ....

### What is MVC?
MVC stands for Models, Views, Controllers. This is a architectural pattern that separates an application into three main components. This helps provides more separation of conerns where user requests are routed to a controller which is responsible for working with the Model to perform user actions and/or retrieve results of queries. The Controller chooses the View to display to the user, and provides it with any Model data it requires. These separations of concerns helps to scale the app in terms of complexity by making it easier to code, debug, and test. 

Model: represents state of the app and any business logic or operations that should be performed by it. Business logic is encapsulated within the model along with implementation logic for persisting the state of the app. Strongly typed views uses ViewModel types to contain data to display on the View which the Controller provides. 

View: responsible for presenting content through the UI. They use Razor syntax to embed .NET code in HTML markup. There should be minimal logic and most logic should only be fore presenting content. 

Controller: the component that handles user interaction, work with the models, and finally selects the view to render. in MVC pattern, the controller is intial entry point ad responsible to selecting which model types to work with and which view to render. 


### What is ASP.NET MVC?
ASP.NET MVC is a framework optimized for use with ASP.NET Core. It enables clean separation of concerns, gives control over markup, supports TDD, and uses latest web standards. Features included is Routing, Model Binding, Model validation, DI, Filters, Tag Helpers.

Model binding: converts client request data (form data, route data, query string params, HTTP headers) into objs that the controller can handle. As a result, your controller logic doesn't have to do the work of figuring out incoming req data. Simply has the data as parameters to its action methods.


### What is HTTP and its lifecycle?
HTTP stands for HyperText Transfer Protocol where first a user sends a request from their browser for what URL they want to go to. If the user's cache does not contain the IP address, it fires a DNS request and we eventually get an IP address. Then after we have our TCP connection we can finally send a request that contains a header and a body. Usually contains a HTTP method, resource being requested, and protocol version. Now the server receives the requests, processes it and finds the resource requested. It then generates a response containing a status line, response header fields, and optional body. This response makes it back to the browser which then starts processing what it received and start rendering the page if successful. 


### What is a strongly and weak typed view?
Strongly typed means you have a ViewModel that the controller passed into the view with all the elements in that view can use those properties. 

partial views is a reusable piece of Html. 

Templates are view elements shared among all views e.g. Nav


### What is routing in MVC?
Routing: url-mapping component that lets you build apps with comprehensible and searchable URLs. Convention-based routing allows you to globally define the URL formats that your app acceps and how each of those formats maps to specific action method on given controller. So when an incoming requests arrives, the routing engine parses the URL and pattern matches to one of the defined URL formats and then calls associated controller's action method. We can also use attribute routing to specify routing info by decorating controllers and actions with attributes that define your app routes. 


### Tag vs HTML helpers?
Tag helpers are attached to HTML elements inside your razor views and can help you write markup easier to read than HTML helpers. Tag helpers target standard HTML elements and provide server side attributes for the elements. Tag helpers includes things like `asp-for`, which extracts the name of the specified model property into rendered HTML. 

HTML helpers are invoked as methods that are mixed with HTML inside your Razor views. VS provides intellisense support when writing HTML helpers, as their parameters are all strings. Example are the LabelFor and TextBoxFor HTML helpers.


### What is DBContext
It is the primary class responsible for interacting with the database. Querying, persisting data, caching, managing relationshis and variety of others. 

### What is a dependency injection and its types?
Dependency injection is a software design pattern which is a technique to achieve inversion of control between classes and their dependencies. Dependency is any object that another object requires. So to achieve DI we make use of an interface to abstract the dependency implementation. Registering the dependency in a service container(IServiceProvider) that are registered in the app's Startup.ConfigureServices method. Or injecting of the services into the constructor of the class where it's used. 

---

## Week 4: DevOps, CI/CD, Azure, Docker
wowzers, it takes so long per each week

### What is SDLC and the two main types?
Stands for Software Development Life Cycle, it is a process used by software industry to design, develop and test software. The two main types are waterfall and iterative methods. waterfall essentially is a one track process that goes through the planning, gathering resources, development, testing, and finally deployment without ever going back to the previous phase. Benefits are better security and more accountability. Flaws is that the process could take a lot longer and it lacks flexibility to make new changes. 

Iterative is the process of working on something small and gradually adding more complex parts built on top of it. Couple of iterative models is the Big Bang, Spiral Model, and Agile Methodology. 


### Describe the Agile process
Agile focuses on adaptive, simultaneous workflows where the project is broken down into smaller iterative periods. Kanban is on process improvements while Scrum is getting more work done faster. Scrum uses the idea of sprints where assigned a set amount of time to implement tasks/features. Along with that is the daily standups that scrum masters starts often where you provide what you have done, what you plan to do, and what is blocking you. There is also the idea of organising tasks with a Scrum Board where there is something like a to do list, in progress, testing, and finished columns. 

Then there's kanban which doesn't use sprints and does something called continuous improvements where the team meets often to discuss changes that needs to be made. They use a kanban board as well with a set limit on how many tasks are made available. 

### What is DevOps?
It is a software development methods which focuses on communication, integration, and collaboration among IT proffessionals to enable rapid deployment of products.

Devops is an automated development process through the usage of pipelines that is useful for catching errors, faster deployments, and more coordination between team members. What Azure Devops provides is board, artifacts, pipelines, and many more. Artifacts are deployable components of the app repos, test plans. 

Pipeline artifacts help you store build outputs and move intermediate files between stages in your pipelines. Artifacts are the files that you want your build to produce. They can be anything that your team needs to test or deploy your app.

Devops is a set of practices for deploying and running production systems. Agile sets the stage for devops where it provides teams a formula to deploy more often and increase quality. 

The principle of flow: decrease the time from commit to code running in production. The principle of feedback where increase the feedback from production back to development. THe principle of contnuous learning and experimentation where you continuously improve and evolve the process. 

### What is CI and the two CD?
Continuous integration, continuous delivery and deployment.

Continuous integration is the idea of commit often and push often. It is the process of automating the build and testing of code every time someone commits a change to the vcs. Some benefits is less time wasted in fighting merge issues and rapid feedbacks. Continuous integration puts a great emphasis on testing automation to check that the application is not broken whenever new commits are integrated into the main branch.

Continuous delivery is the automated procedure to build, test, configure and have project ready for deployment. Many testing/staging environment creates a release pipeline to automate the creation/deployment of new infrastructure. on top of having automated your testing, you also have automated your release process and you can deploy your application at any point of time by clicking on a button

Continuous deployment is where your project goes through the whole pipeline and is put into production. This includes the release, unlike continuous delivery where devs controls the final release. With this practice, every change that passes all stages of your production pipeline is released to your customers. an excellent way to accelerate the feedback loop with your customers and take pressure off the team as there isn't a Release Day anymore. 


### What is a build and release pipeline?

Deployment pipeline is an automated process that first goes through building the software, then through stages of testing and deployment. 

pipeline procedures are triggered whn code is committed to a repo hosted for example github. Then comes notification to build system which compiles the code and run tests. After this would be some integration tests. Now you can create images and push to some registry service like Docker Hub which can then be easily deployed. 

release pipelines help you monitor whether a release has been deployed and tested on each of these stages. It also tracks whether an issue fixed by a developer, or a product backlog item completed by your team, has been deployed to a specific stage. Release pipelines let you specify which users can change the configuration of an stage, or approve the release to be deployed into a particular stage.

CI build -> Dev Servers -> QA servers -> Pre production servers -> production servers

Pre deployment approval -> queue deployment job -> agent selection -> download artifacts -> run deployment tasks -> generate process logs -> post deployment approval

### what is static analysis and what do we use for it?

static analysis is a way of examining the code without executing the program. Gives you a way of understanding code structure and ensure that the code follow industry standards. It's a way of going over code to find problems, security flaws, and bad practices.

In my case I used SonarCloud as our static analysis tool. What is nice is that we find security flaws and bad practices. It gives us idea of duplicated code and code smells. Also we can define quality gate and profiles where quality gate is we must meet some conditions before our project is good to be deployed like 50% code coverage. Quality profile are like rules for the language you use. 


### What are the difference between IaaS, PaaS, SaaS,and CaaS?

Infrastructure as a service: Is something that provides a lot of tools that a developer can use to devlop their own application. An example would be Microsoft Azure which provides a variety of services that can be used together to build an application. Database, pipelines, app services to deploy and many more.

Platform as a service: is something that was can use to host our application and will do all of the troublesome tasks for us so all we need to focus on is coding our app. Examples are Azure cloud services, Azure VM

Software as a service: As long as you have internet, you can install those applications. They are things like GMail, Dropbox, and a variety of other apps that provides features and functionalities that we don't have to write ourselves. 

container as a service: The idea of using containers to host our applications. Docker is a prime candidate for this

### What is Docker?
A tool to make it easier to create, deploy, and run apps by using containers. Containers allows you to package up an app with all the parts it needs such as libraries and other dependencies and ship in one package. 

Docker containers: containers are runtime environments. You usually run one main process in one Docker container. You can think of this like one Docker container provides one service in your project.

docker image is an instance of a container. A file composed of many layers used to execute code in a Docker container. essentially built from the instructions for a complete and executable version of an application, which relies on the host OS kernel.

Docker containers are started by running a Docker image. A Docker image is not a runtime, it’s rather a collection of files, libraries and configuration files that build up an environment.


### Containers vs VM?
Rather than creating a whole virtual OS, docker allows the usage of the same linux kernel as the system it's running on. Gives performance boost and reduces the size of the app. 

### What is a dockerfile?
A Dockerfile is a text file that defines a Docker image. Docker’s main purpose is to give us run-time environments that we can re-create/reproduce on any machine (that runs Docker). It is used to define your custom environment to be used in a Docker container.

After you create a dockerfile you execute with a `docker build` and now you can use this image to start containers with `docker run`

```
# sample of Nick's docker file
# multi-stage build - FROM command can name a stage.

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /app

# take advantage of docker layer caching...
# these two layers will be cached so long as the csproj file(s) does not change.
COPY ./*.csproj ./
RUN dotnet restore

# if i just change a .cs file, then i can use that cache and the next line will
# be the first one to actually run.

COPY . ./

# build & publish to /app/out
RUN dotnet build --no-restore

RUN dotnet test

RUN dotnet publish --no-restore -c Release -o out

# docker allows us to use some layers just temporarily
# and then copy certain files out of them onto a new base image.
# this means the resulting final image will be smaller.

# asp.net core runtime image. (much smaller than sdk!)
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime

WORKDIR /app

# copy from a previous stage, instead of from outside Docker
COPY --from=build /app/out ./

# set environment variable inside image
# asp.net core looks at this when seeing what port to put itself on
# ENV ASPNETCORE_URLS=http://*:5050
# EXPOSE by itself, does nothing -- but hints to the guy running the container from this
# image, that he should bind 5050 to something.
# EXPOSE 5050

# there is technical difference between CMD and ENTRYPOINT

ENTRYPOINT [ "dotnet", "MvcBetterBuild.dll" ]

# best of both worlds from multi-stage build:
# repeatable build environment, plus small image size

# (add comment to change Dockerfile)
```

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

---

## Week 5: Service orieented architecture, REST, JS
Wow am I really sleepy...

### What are the differences between SOAP and REST?
SOAP isn't bound to the HTTP protocol like REST is, and is clearly outlines the service.  However, unlike REST, it is bound to XML, while REST can be JSON or XML, and REST has greater flexibility in implementation as REST is a framework where SOAP is a protocol.

The SOAP specifications are official web standards, maintained and developed by the World Wide Web Consortium (W3C). As opposed to SOAP, REST is not a protocol but an architectural style. The REST architecture lays down a set of guidelines you need to follow if you want to provide a RESTful web service, for example, stateless existence and the use of HTTP status codes.

As SOAP is an official protocol, it comes with strict rules and advanced security features such as built-in ACID compliance and authorization. Higher complexity, it requires more bandwidth and resources which can lead to slower page load times.

REST: Therefore it has a more flexible architecture. It consists of only loose guidelines and lets developers implement the recommendations in their own way. It allows different messaging formats, such as HTML, JSON, XML, and plain text, while SOAP only allows XML

### What is SOAP? (message, WSDL)

it is an XML based messaging protocol for exchanging info among computers. Can extend HTTP for XML messaging.

SOAP message contains the following elements:
- Envelope defines the start and end of the message. (M)
- Header: contains optional attributes of message used in processing the message (optional)
- Body: contains XML data comprising the message being sent (mandatory)
- Fault: optional provide info on errors that might have occured.

soap includes built in set of rules for encoding data tyes: two categories scalar and compound types. Scalar contains one value such as last name, price etc. Compound contains multiple values like purchase order etc..


WSDL is web service description language. XML based definition language used to describe functionality of a SOAP based web service. WSDL definitions describe how to access a web service and what operations it will perform. WSDL is a language for describing how to interface with XML-based services.

WSDL document contains:
- Definition: root element define name of web service, namespaces, and service elements
- data type: data types to be used in messages are in form of XML schemas
- message: abstract definition of data in form of message 
- operation: abstract def of operation for message, such as naming a method, message queue that will accept and process the message
- port type: defining collection of operations for bindings. Mapped to multiple transports through various bindings
	- The portType element defines a single operation
	- usually one way
	- usually we make a request and response
- binding: protocol and data formats for operations and messages defined for particular port type
- port: combination of binding and network address, providing target address of service communication
- service: collection of related end points encompassing service def in file. Service maps the binding to port


In a normal day to day life example:

WSDL: When we go to a restaurant we see the Menu Items, those are the WSDL's.

Proxy Classes: Now after seeing the Menu Items we make up our Mind (Process our mind on what to order): So, basically we make Proxy classes based on WSDL Document.

SOAP: Then when we actually order the food based on the Menu's: Meaning we use proxy classes to call upon the service methods which is done using SOAP.

### What is WCF?
Windows Communication Foundation.  It's a framework for building service-oriented applications.  Using WCF, you can send data as asynchronous messages from one service endpoint to another.  A service endpoint can be part of a continuously available service hosted by IIS or it can be a service hosted in an application.  An endpoint can be a client of a service that requests data from a service endpoint.

Or in other words, it's a framework for building service oriented applications that send data as messages from one service endpoint to another.

consists of 3 things:
WCF service: What is the service and what it is providing
WCF Service Host: Where is the service hosted
 - IIS, Self, and WAS hosting
Service Client: Who is the client of the service

These are properties of endspoints in WCF.

https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/endpoints-addresses-bindings-and-contracts

Address: Indicates where the endpoint can be found. The address uniquely identifies the endpoint and tells potential consumers of the service where it is located. It is represented in the WCF object model by the EndpointAddress class. An EndpointAddress class contains: Uri, identity

Binding: How a client can comunicate with the endpoint. The transport protocol to use (for example, TCP or HTTP).
The encoding to use for the messages (for example, text or binary). The necessary security requirements (for example, SSL or SOAP message security).

Contract: Identifies the operations available.
Couple off top of my head is data, operations, service contracts... too sleepy

Where is our endpoints
How to communicate with our endpoints
What operations are available at the endpoints?

Service contracts: Describe which operations the client can perform on the service.

Data contracts: Define which data types are passed to and from the service

### What are the 6 REST principles?

REST stands for representational state transfer and it is an architectural framework that deals with HTTP to communicate over the web. 

Off the top of my head it is:
- Statelessness
	- a request contains everything it needs.
	- each request from the client should contain all the information necessary to service the request – including authentication and authorization details.
- cacheability
	- after running a common request once, it stores a cache of that request to fetch info required quickly the next time. Generally for safe methods.
- Uniform interface
	- no matter which browser you run the command in, it should display the same result to you
- Layered system
	- each layer should not be to themselves, loosely coupled from one another.
- client-server
	- separation of concern by separating client UI from the server side.
- code on demand


### What are the different HTTP requests? safe, idempotent?
GET, POST, PUT, DELETE, OPTION, HEAD, TRACE.

Safe are GET, HEAD, OPTIONS

Idempotent is everything but POST


### What are some of the important status codes?
common ones are 200 for okay, 201 for created, 400 for bad request, 404 for not found, 500 for internal server error

**418 I am a teapot**


### What is the purpose of a HTTP header?
HTTP headers allow the client and the server to pass additional information with the request or the response. An HTTP header consists of its case-insensitive name followed by a colon ':', then by its value (without line breaks). Leading white space before the value is ignored.

grouped into: general, request, response, entity headers

Accept headers tell the server what media types are acceptable for the response, while content-type headers tell the client what media types are actually being returned.

### What is ASP.NET Core for APIs?


### What is a HttpClient?
HttpClient class provides a base class for sending/receiving the HTTP requests/responses from a URL. It is a supported async feature of .NET framework. HttpClient is able to process multiple concurrent requests. It is a layer over HttpWebRequest and HttpWebResponse. All methods with HttpClient are asynchronous.

```
static asyncTaskCallWebAPIAsync()  
{  
    using(var client = newHttpClient())  
    {  
        //Send HTTP requests from here.  
    }  
}  
```

and from the client defined above you can set base address to be used. And then other HTTP methods like GET

### What the the JS data types?
numbers, string, boolean, null, undefined, objects, symbol

### What is DOM?
Document object model. Think of it as an upside down tree representation of an HTML page. Where let's say the document is at the very top and as we traverse down we have things like HTML then within there we have the head, body, footer. and within body we can have divs, p, and many more elements within. We have this idea of DOM traversal to traverse through the tree to reach our desired elements to edit, add, or remove. Typically traverse through siblings, parents, child of each node. 


### What is Ajax?
Asynchronous JavaScript and XML.  It is not a programing language, it just uses a combination of a browser built-in XMLHttpRequest object (to request data from a web server) and JavaScript and HTML DOM (to display or use the data).

It allows web pages to be updated asynchronously by exchanging data with a web server behind the scenes.

usually uses: new XMLHttpRequest(); and we open() and send() requests

Allows the developer to send http requests from JS and process the results without the browser reloading the page.

An object which is returned by the async function like AJAX.  Promise is used to overcome issues with multiple callbacks and provide better ways to manage success and error conditions.  Promise objects have 3 states:
- pending: async operation is going on
- resolved: async operation has succeeded
- rejected: async operation has failed

### What is a promise?
The Promise object represents the eventual completion (or failure) of an asynchronous operation, and its resulting value.

```
var promise1 = new Promise(function(resolve, reject) {
  setTimeout(function() {
    resolve('foo');
  }, 300);
});
```

it can get ugly with nested promises so a solution to that is fetch.

Fetch API provides a JS interface for accessing and manipulating parts of the Http pipeline for requests and responses using promises.  Fetch also provides a global fetch() method that logically and simply fetches resources asynchronously across the network.

The Promise returned from fetch() won’t reject on HTTP error status even if the response is an HTTP 404 or 500. Instead, it will resolve normally (with ok status set to false), and it will only reject on network failure or if anything prevented the request from completing.

```
fetch('http://example.com/movies.json')
  .then(function(response) {
    return response.json();
  })
  .then(function(myJson) {
    console.log(JSON.stringify(myJson));
  });
```

---

## Week 6: Angular, Typescript
Way too sleepy... seriously.. 2 hrs per each week

### What is TypeScript?
TypeScript is a superset of JS. It contains everything in JS + additional features like specifying a type, it is a compiled language so you can catch errors earlier on without needing to run the application and find errors on the browser. 

### What is a TS module vs NG 
TS module is a file that can contain something like a class or interface that can be exported and imported to other files. 

NG module are files like app.module.ts that is used to load dependencies, services, and bootstrap functionality to load the program. It usually contains an @NgModule decorator that contains all of those dependencies. There must be at least one app.module within an Angular project and it is usually called the root module which will be bootstrapped to launch the application

is a global place for creating, registering, and retrieving AngularJS modules.  All modules that should be available to an application must be registered using this mechanism

module?
### What is Node.js and what do we use it for?
Node.js is a very light web framework used to make web applications. What comes with node is NPM which is the node package manager which is used to install or update library packages that we define within the package.json. Those libraries installed from dependencies are located within the node_module.

### What is Angular?
Angular is a java script based web framework that is used to create SPA applications. It lets us extend HTML's syntax to express our components. Through the usage of data binding and DI it removes a lot of duplication/code we have to write. 

### What is a NG decorator and directive?
Decorators provides additional metadata to whatever it is attached to. Does not alter any of the current code and adds into it. The main types of decorators are:
- class: @NgModule, @component
- property: input, output
- method: @HostLisener
- parameter: @inject


### How do you pass services in your NG application?
We can pass services within the app.module within the @NgModule class providers section. Within the service class itself, we define an @Injectable class that by default provides a providedIn: root that creates a provider for the service in root. Here is where we can define our API call urls that we can later access from the components or wherever else is called. Then to use the service, we import the service at the top, then within the constructor we inject the service to be used within the component. 

### What is inside of an NgModule?
- declarations: for our components
- imports: where we use code from other libraries
- providers: where we have our services known
- bootstrap which defines which file to run at the start


### What are the different data bindings available?
there is one way bindings which includes interpolation, event binding, and property binding. Interpolation is from the component to view, and event and property binding is vice versa. Two way binding is by definin NgModel formatted as a banana in a box. 

### What is the difference between an Observable and Promise?
An observable is similar to a promise, but you continue operations, then when it finishes it notifies you itself. We have to make sure to subscribe the observable to actually have it working. Similar if you are subscribed to a newsletter by email, you would get a newsletter once a week or when some important event happens. Promises is where we have to wait for the action to be finished before we can continue on. 

### How does routing work in an Angular project?
Routing is a way to navigate from one view to another as users perform some action. NgModule provides a service that lets you define navigation path among diff app states and view hierarchies in your app. There could be a app.routing.ts file where you define you default route and other routes that you go to. 

### What is an Angular template and how do you use it?
In AngularJS, template are written with HTML that contains AngularJS specific elements and attributes.  AngularJS combines the template with information from the model and controller to render the dynamic view that a user sees in the browser.

Interpolation allows you to incorporate calculated strings into the text between HTML element tags and within attribute assignments. Template expressions are what you use to calculate those strings.

Angular evaluates all expressions in double curly braces, converts the expression results to strings, and links them with neighboring literal strings. Finally, it assigns this composite interpolated result to an element or directive property.

A template expression produces a value and appears within the double curly braces, {{ }}

### How do you test in Angular?
Similar to xUnit testing in C#, one way to test in Angular is through Jasmine tests. We import all the dependencies we need on top like the components, models, services. Then within the describe we load our declarations, imports, services and etc that we need to test with. Then compile to make our component. And finally use an it to test if what we make is valid. Then we have Karma that displays our tests in the browser and also tells us what we are missing within our tests. if we turn on code coverage when we run our ng test, it will act similarly to sonarCloud by displaying % of code tested and locations that we haven't tested. 


## Extra Questions:

### What are collections in C sharp?
the way how objects are handled by your program. It contains a set of classes to contain elements in generalized manner. Defines a generic implementation of standard structures like linked lists, stacks, queues, dictionaries, hashsets.

Dictionaries are k/v pairs, List is dynamic array, Queues is fifo, stack is LIFO, hashset is unordered collection of unique elements. Prevents duplicates. 

### What are action filters
executes before and after an action method executes. Can create a custom ActionFilter for logging. Sample of making a custom is `void OnActionExecuted(ActionExecutedContext filterContext)`

attributes you can apply to a controller action or entire controller which modifies the way the action is executed. A couple are OutputCache (caches output of controller action for certain time), HandleError (handle errors raised when controller action executes), Authorize (enables you to restrict access to a particular user or role)

Other types of filters are: Authorization filters(IAuthorizationFilter), Action(IActionFilter),Result(IResultFilter), and Exception (IExceptionFilter) attributes. 

They are executed in order listed above. 

Key points:
- allows pre and post processing logic to be applied to action method
- generally used to apply cross cutting concerns like: logging, caching, authorization etc
- can be registered as other filters at gloabl, controller, or action method level
- custom action filters attribute can be created by deriving ActionFilterAttribute class or implementing IActionFilter interface and FilterAttribute abstract class
- Every action filter must override OnActionExecuted, OnActionExecuting, OnResultExecuted, OnResultExecuting methods

### managed and unmanaged
managed code are code that is executable by the CLR. COde that targets the Common language runtime. It provides the metadata necessary for the CLR to provide services such as memory management, cross lanuage integration, code access security, and automatic garbage collection. All code based on IL executes as managed code. Code that executes under the CLI execution environment.

Insulates the program from the machine its running on and creates a secure boundary in which all memory is allocated indirectly and we don't have direct access to machine resources like ports, mem address space, stack etc... idea is to run in a more secure environment. 

umanaged code is compiled to machine code and executed by the OS directly. Has the ability to do damaging and powerful things. 

### how to implement REST
we generally create an ASP.NET Web API Application. Then our project will be split up into subfolders for separation of concerns where we will have the DAL, the controllers, and our library. The controllers is where we define our GET, POST, PUT, DELETE web requests. DAL is what we will use to access data from our database. The models will contain the object oriented logic. 

### what is a service and SOA?
SOA is service oriented architecture which is an architectural approach make use of services available in the network. Services are provided to form applications, through a communication call over the internet. 

Two majors roles are:
- service provider: maintainer of the service and organization that makes available one or more services for others to use. Can publish in registry, together with service contract that specifies nature of the service
- service consumer: can locate service metadata in registry and devleop req. client components to bind and use service

principles: standardized service contract, loose ccoupling, abstraction, reusability, autonomy, discoverability, composability

service orchestration: service might aggregate information and data retrieved from other services or create workflows of services to satisfy the req of a given service consumer. 

service choreography: coordinated interaction of services without a single point of control

### what is the lifecycle of MVC and HTTP?
for mvc
- Routing: routes url to its controller and action
- Url routing module intercepts request: it then wraps up current HttpContext in an HttpContextWrapper object.
- mvc handler executes: will call BeginProcessRequest method of httpAsyncHandler async. A new controller gets created from ControllerFactory
- Controller executes: controller is called and its action call requested by user
- render view method called: where we return a view

user from browser -> req -> routing -> mvc handler -> controller -> action execution -> view result -> view engine -> view -> response -> user

### What are the ABC's for WSDL?
- web service description language.
- A stands for address: where is the service?
	- expressed in the wsdl:service section and links wsdl:binding to concrete service endpoint address
- B stands for binding: How do I talk to the service?
	- expressed in wsdl:binding section and binds wsdl:portType contract description to a concrete transport, envelope and associated policies
	- tells us how we find the services or using which protocols finds the services (SOAP, HTTP, TCT...)
- C stands for contract: what can the service do for me?
	- expressed in wsdl:portType, wsdl:message and wsdl:type sections and describes types, messages, message exchange patterns and operations
	- agreement between consumer and service providers that explains what params the service expects and what return value it gives. 

### Tag Helper vs HTML Helper again

## Tell me about yourself?
- 