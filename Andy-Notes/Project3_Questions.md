# Possible Project 3 Questions
here I will make my feeble attempts at answering these questions

## Questions
1. If you had a chance to talk to the batch for next iteration, what would you tell them?
	- apply authorization for each of the apis
	- make the code more loosely coupled
	- forecast needs a lot more work. Making more classes/interfaces
2. So, did you run into any issues when you working with Selection/Forecast when you were trying to set up environments for development and testing purposes?
	- generally at beginning it was trying to have the 3 services being able to speak to the Selection/Forecast services and grabbing necessary information from them.
	- then it was trying to figure out how to switch from testing with Docker to Visual Studios
	- possible problems when trying to use Serilog (not sure about this since I never touched it)
3. Related to AD, Queues, microservices etc..., not covered in training, what was your approach to learning about it, and being proficient eenough to integrate it into your project?
	- Mainly using the internet to Google necessary stuff we needed to know. 
		- Microsoft website was good to explain things, and StackOverflow for the more common questions people had
4. What steps did you take to implement Authentication?
	- Danny would know best for this
	- I think it was to set up an Azure AD account
		- We used MSAL for auth
		- needed to provide a client and etc 
		- can't remember what else
5. Do you have validation on all of the tiers of your application?
	- no? But if it's in term of testing then it at least passes the 50% minimum on SonarCloud
6. how are you ensuring that that data is going to be persisted?
	- we used MongoDB for our microservices and PostgreSql for our two api services
7. Why exactly did you use MongoDb and PostGresDB?
	- MongoDb: MongoDB uses JSON-like documents to store schema-free data. In MongoDB, collections of documents do not require a predefined structure and columns can vary for different documents.
	- PostgreSql: emphasis on extensibility and standards compliance. PostgreSQL is ACID-compliant, transactional, has updatable and materialized views, triggers, and foreign keys. It also supports functions and stored procedures.
8. Microservices questions, with a microservice architecture, how are you dealing with services that are going down in production?
	- Graceful Service Degradation
		- can isolate failures and achieve graceful service degradation as components fail separately. 
			- For example, during an outage customers in a photo sharing application maybe cannot upload a new picture, but they can still browse, edit and share their existing photos.
	- Change management
		- majority of failures caused from changes in a live system
			- can implement change management strategies and automatic rollouts.
			- when you deploy new code, or you change some configuration, you should apply these changes to a subset of your instances gradually, monitor them and even automatically revert the deployment if you see that it has a negative effect on your key metrics
	- Safe Healing
		- when an application can do the necessary steps to recover from a broken state
			- implemented by an external system that watches the instances health and restarts them when they are in a broken state for a longer period
	- more found here: https://blog.risingstack.com/designing-microservices-architecture-for-failure/
9. Think out loud how you would approach deploying this application on to the cloud, we are using
one application, and we want to switch to your microservices application?
	- ??? I guess our app will provide a redirect to the microservice application? like how we have this overall interface and then go to housing or selection
10. Lets say you've already built this microservides applcations, how to transition from legacy application, to this already built microservices application in production?
	- https://kublr.com/blog/how-to-modernize-legacy-applications-for-a-microservices-based-deployment/
	- Don’t Rewrite, Refactor!
		- refactor everything with the goal of splitting legacy apps into microservices and connecting these microservices into one platform, such as Docker or Kubernetes.
			- Plan a controlled move, Limit disruption to your app pool, Choose your application delivery platform, Prioritize your components, Stay away from data unification
11. did you use any tools or what best practices for getting feedback on the current state of your project and using that to improve your development practices?
	- SonarCloud provided quick feedback on code smells, duplication, code that needs testing
	- used Azure Pipelines to make sure project is able to be built successfully and all other pipeline tasks passes to make app deployable
12. Gather any metrics on the quality of your code?
	- SonarCloud, Jasmine Code Coverage
13. Run through linter, test code coverage?
	- yes? for sure used ng lint for Angular side
14. I had a few questions, the charts, there are a lot of different charting frameworks, which did you choose, why?
	- used ng2-charts since it's a combination of chart.js and angular together. Chart.js is one of the most popular js chart library being used now
15. What was the process for learning how this charting framework worked?
	- reading documentation and then playing around with how the chart worked through prototyping
16. In terms of microsoervices, what do we have in terms of tracing through errors during productiosn?
How would people maintaining this application in production, how would they be able to treage issues?
	- viewing the errors through logging. Not too sure on this since I wasn't too involved with logging
17. What tools or frameworks would you suggest as part of the architecutre to handle maintainability during production?
	- ??? is this related to microservices architecture where we split our application up into a lot of services that works with one another? Then it's easier to manage each individual services when things goes wrong or we just need to update a small piece of the app?
18. I am assuming that you've got some inter-service communication mgoing on, so imagine that you've
got a huge application with dozens of micro application running, how do you use Zuul to treage stack traces and hundreds of concurrent users?
	- I'll just assume this question asks how would our site handle a whole bunch of users at the same time. 
	- make site more efficient so that requests doesn't take too long, get faster cloud services, idk
19. how did you get things setup without the online db and deployed version up and running?
	- mainly testing to make sure everything works locally and then when we can start trying to deploy our site, we test to make sure it works in production as well. 
20. What did you guys do in terms of running the team using Scrum, what Scrum practices?
	- task board through pivotal tracker, daily standups, mini sprints
21. If I start one more instance for a service, how are you handling load balancing?
	- I'll assume this is related to poller/heartbeat timer where after x amount of time we grab information from our microservices.
22. How did you handle merge conflicts in Git and GitHub?
	- whoever pushes after previous person had to deal with it. hahahaha. 
	- generally some communication with person who you are having the merge conflict with so that you don't get rid of needed functionality.
		- and make sure code still works after applying those merges