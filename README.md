## Web crawler by Christine Romano

### Install instructions
Prerequisites: 
- Docker for Windows (or Mac)
- Visual Studio Community or VS Code (2019 versions)
- GitTools
- .NET Core Sdks



### Running the project
How to do the things:

Change directory into project location [Where you host your local repos]
- Clone repository ```git clone git@github.com:ChrismeanR/corewebcrawler.git```
- Change directory into project location ```cd WebCrawler.CoreConsoleApp```
- Build ```dotnet build```
- Run ```dotnet run```
- You'll see the output at this step.
- Publish (if you want the executable directly)
- ```dotnet publish ``` This will create an executable based on the users operating system.
- Navigate to ```./bin/[configuration]/[framework]/[runtime]/publish/ ``` relative wherever you stored your local clone.


### Run the Tests
Trigger test cases by:
#### This I've been unable to get running via commands like the above steps. 

## Not implemented:


#### Docker Implementation: In docker container:
```docker build WebCrawler.CoreConsoleApp```

## gotchas:
- docker and case sensitivity
- using .net core for, realistically, the third time
- creating the solution improperly, so it could not be packaged into executable.
- Not knowing, with ease, how to publish up the test project for easy red/green test visibility.