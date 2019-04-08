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


### How do you perform unit tests in a .Net application?
In a .Net application we can perform xUnit tests that follows this AAA process. 
1. Arrange: where we arrange the necessary data or things we'll need to act upon
2. Act: where we use the things in arrange and plug into the methods we plan to test
3. Assert: we do some form of checks to assert if the results of the act is true or false

We can use a [Fact] or [Theory] attribute where fact takes no method arguments. Theory expects one or more DataAttribute instances to provide values for the method arguments. 

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

### What is ADO.NET? Connected and Disconnected architecture?
Connected architecture is where we are constantly connected to a database to retrieve data. We gennerally start with opening a connection. Then we execute some command.ExecuteReader() that returns a DataReader for SELECT queries. We then process the results and finally close the connection when finished. 

Disconnected is where we open a connection to the database to grab what we need and store it into some variable to be used. We want to minimize the amount of time the connection spends open since it costs resources to keep open(although faster). We open a connection, then we fill a dataSet by using the DataAdapter. Then we close thc onnection and process results which contains our dataset that containes some DataTable with its rows and columns. 


### What is Entity Framework?
Entity framework is an ORM which stands for Object Relational Mapping that enables .NET devs to work with a db using .NET objects. Our .NET project usually consists of a UI, BLL, and DAL and Entity Framework would go within the DAL. What it does is to save data stored in properties of business entities and retrieves data from the db and converts to business entity objects automatically. 

Another definition is: a tool that simplifies mapping between objects in your software to the tables and columns of a relational db. Takes care of creating db connections and executing commands as well as taking query results and auto materializing those results in your app objects. It also keeps track of changes to those objects and when instructed persist those changes back to the db for you. 

Features it contains:
- cross-platform can run on many OS like windows, linux, mac
- Modelling: creates an EDM (entity data model) with get and set properties of different data types
- Querying: allows usage of LINQ to retrieve data from underlying db. 
- Allows you to execute INSERT, UPDATE, DELETE commands to db based on changes occured to your entities when you call SaveChanges() or SaveChangesAsync()
- Allows set of migration commands that can be executed. 


### What is the difference between IEnumerable and IQueryable?
`IQueryable<T>` takes expression objects instead of delegates IQueryable inherits from IEnumerable, so can do anything IEnumerable can do
IQueryable<T> allows for out of memory things like a remote datasource, such as a db or web service

IEnumerable<T> is great for working with sequences that are iterated in-memory. Useful when your collection is loaded using LINQ or Entity framework and you want to apply filter on the collection. (e.g. using .Where())

The main thing is where the filter is applied. IQueryable has the filter on db side and IEnumerable has on client side. If working in-memory IEnumerable is better. If connected to a db then IQueryable is better as it reduced network traffic and uses power of SQL language. 


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
Tag helpers are attached to HTML elements inside your razor views and can help you write markup easier to read than HTML helpers. Tag helpers target standarf HTML elements and provide server side attributes for the elements. Tag helpers inclides things like `asp-for`, which extracts the name of the specified model property into rendered HTML. 

HTML helpers are invoked as methods that are mixed with HTML inside your Razor views. VS provides intellisense support when writing HTML helpers, as their parameters are all strings. Example are the LabelFor and TextBoxFor HTML helpers.


### What is a dependency injection and its types?
Dependency injection is a software design pattern which is a technique to achieve inversion of control between classes and their dependencies. Dependency is any object that another object requires. So to achieve DI we make use of an interface to abstract the dependency implementation. Registering the dependency in a service container(IServiceProvider) that are registered in the app's Startup.ConfigureServices method. Or injecting of the services into the constructor of the class where it's used. 