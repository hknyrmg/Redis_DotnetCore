Redis_DotnetCore

Description
This repository contains a sample project showcasing the usage of .NET Core 7 and Redis for efficient data caching and retrieval.

Prerequisites
Before running this project, make sure you have the following installed on your machine:

.NET Core 7 SDK
Redis


Installation
Clone this repository to your local machine.

git clone https://github.com/your-username/repository-name.git

Navigate to the project directory.
cd repository-name
Restore the project dependencies.
dotnet restore


Configuration
Open the appsettings.json file and update the Redis connection string as per your Redis server configuration.

{
  "Redis": {
    "ConnectionString": "your-redis-connection-string"
  }
}

Usage
Build the project.

dotnet build


Run the project.
dotnet run

Open your web browser and navigate to https://localhost:5001 to access the sample application.


License
This project is licensed under the MIT License.

Acknowledgements
Microsoft .NET Core
Redis
