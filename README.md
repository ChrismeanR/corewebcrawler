## Web crawler by Christine Romano

### Install instructions
Prerequisites ~~(Most are optional since it is a self contained executable)~~:
> We''ll be running this in command line
1. GitTools (commandline, gui, basic knowledge of it)
2. **.NET Core Sdks** (UBuntu install instruction guide: https://docs.microsoft.com/en-us/dotnet/core/install/linux-package-manager-ubuntu-1904 )
- Ubuntu **(Only need to run this once)**: 
```wget -q https://packages.microsoft.com/config/ubuntu/19.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```
3. Ubuntu (Install .NET core SDK) 
```sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-3.1 
```
4. Ubuntu: (Install .NET core Runtime) 
```sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-runtime-3.1 
```
> (If running via docker compose) 
- Docker for Windows (or Mac)
> (If running code locally or running the test project) 
- Visual Studio Community or VS Code (2019 versions)

### Running the project (dotnetcore)
How to do the things:

Change directory into project location [Where you host your local repos]
- Clone repository ```git clone git@github.com:ChrismeanR/corewebcrawler.git```
- Change directory into project location ```cd corewebcrawler\WebCrawler.CoreConsoleApp```
- Build ```dotnet build```
- Run ```dotnet run```
- You'll see the output at this step.
- Publish (if you want the executable directly)
- ```dotnet publish ``` This will create an executable based on the users operating system.
- Navigate to ```./bin/[configuration]/[framework]/[runtime]/publish/ ``` relative wherever you stored your local clone.
(example: ```~\bin\Debug\netcoreapp3.1\WebCrawler.CoreConsoleApp.exe```)


### Run the Tests
Trigger test cases by:
In order to view this in action, the user will need VS Code or VS community edition (both free). I am unsure how to run tests independently via dotnet commands (see note below).
- In IDE (VSCode or VS Community), open solution, select ```Test``` from the top toolbar/navigation
- Choose ```Run All Tests```
- Test explorer will run all the tests pointed back to the console app and Assert some of the methods in there. 
#### ^^ This I've been unable to get running via commands like the above steps. 


## If running program with docker-compose (Requires Docker Desktop):
*Find the correct install for your machine here: https://hub.docker.com/*

Change directory into project location [Where you host your local repos]
- Clone repository ```git clone git@github.com:ChrismeanR/corewebcrawler.git```
- Change directory into project location ```cd corewebcrawler```
- In your console, type ```docker-compose up``` and it will display the console app information.



## Not implemented:
#### Docker Implementation: In docker container:
```docker build WebCrawler.CoreConsoleApp```

## Gotchas:
- Docker and case sensitivity
- Docker on Windows, How to Docker with .NetCore non web projects
- Using .net core for, realistically, the third time.
- Used .Net Core since it is cross platform. 
- Creating the solution improperly, so it could not be packaged into executable. View the original here: ```https://github.com/ChrismeanR/WebCrawler```
- Not knowing, with ease, how to publish up the test project for easy red/green test visibility.
- Ran out of time perfecting the output, it's' not perfect, left todo's' commented in the code where I'd' like to change