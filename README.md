# Guide
In your root directory exec command : 
* Install : ``dotnet new --install ./``
* Uninstall : ``dotnet new --uninstall ./``

Template generation : 
* --aggregate, aggregate name of bounded context, e.g : User
* --name, bounded context, e.g : SeedRoad.UsersManagement
* --output, directory of solution, **should be named as github repository**, e.g : users-management
* --allow-scripts, allow post creation initialization script to run

Command example for creation of user-management microservice :  
``dotnet new seed-road --aggregate User --name SeedRoad.UsersManagement --output users-management --allow-scripts yes``
dotnet new seed-road --aggregate GardenTeam --name SeedRoad.GardenTeamManagement --output garden-team --allow-scripts yes