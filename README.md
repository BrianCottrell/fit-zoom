# FitZoom
FitZoom project for the 2016 Code Healthy with OpenShift Challenge.

## Inspiration
We wanted to bring the world of VR into our daily workout routine. Our goal was to combine fitness and entertainment by creating an immersive VR experience that could be enjoyed while exercising. In addition we also wanted to use the experience as a means of encouraging riders to reach their fitness goals and track their progress from both within and outside of the application. 
## What it does
Fitzoom provides the visual display of a winding river on a distant planet, which the rider can navigate by pedaling a connected exercise bike, while constantly tracking their workout progress.

![Profile Image](http://i.imgur.com/b5XV2ti.png)

First, the rider creates an account when they connect their [VirZOOM Exercise Bike](http://virzoom.com/) to their [HTC Vive](https://www.htcvive.com/us/) VR headset. The user information is then passed to the FitZoom app along with the rider's history, which is then used to create a personalized set of fitness goals displayed on a profile panel at the start of the workout session.

![Workout Image](http://i.imgur.com/LHuWTrk.png)

As the rider travels down the winding river, they are presented with several different paths to choose from, each with makings to indicate how each choice will affect their workout. The rider can also track their progress towards their goals on a workout panel that displays their current velocity, ride time, distance, and calories burnt.

![Alert Image](http://i.imgur.com/uiBdvCW.png)

Whenever the the rider reaches a milestone, an alert panel pops up with a notification and when they reach the end of the path, the workout information is saved to a server on OpenShift where it can then be accessed through rest API endpoints and displayed on a website like the one in this project.
## How I built it
We chose to accomplish our objectives using the [HTC Vive](https://www.htcvive.com/us/) to provide the VR experience and the [VirZOOM Exercise Bike](http://virzoom.com/) as a safe and effective way to exercise while using the VR headset. We built the VR application in Unity using C# and connected it to the excercise bike using the VIRZoom sdk. We set up a Node.js server with a Mongo database on OpenShift to store and manage user data and connected it to the VR application through REST API endpoints. Our server also hosts a web application for viewing user fitness data. 
## Challenges I ran into
Most of us did not have any experience with Unity or the VIRZoom sdk, which had issues of it's own that we had to work through with the help of the company's engineering team. When trying to get started on OpenShift the server was having issues, which caused all of our builds to fail. We found out later that the development team was working on a solution, and we were eventually able to deploy the project. 
## Accomplishments that I'm proud of
Creating an innovative functioning project using numerous technologies that we had never previously worked with. This was our first time building a VR application as well as our experience with VirZOOM exercise bike. We were also able to get an OpenShipt environment up an running for the first time. 
## What I learned
We learned how to create a and run a VR application using Unity and connect it to a remote server and database to make our project data available to other applications. We learned how to set up a working OpenShift development environment, allowing us to repeatedly update the project and have those updates go live within seconds. We also learned how to search through logs and build or deployment errors to debug the project using the OpenShift platform.
## What's next for FitZoom
We plan to create additional scenes and landscapes for the rider to pass through to keep the workouts interesting. We would also like to connect and combine our data with other devices such as wearable fitness trackers to provide a more complete overview of the user's daily physical activity.
## Testing Instructions
Since we are using publicly available, but not common, third party hardware, testing will depend on what tools are available.

Testing with:

VirZOOM bike and HTC Vive:

Install the latest version of Unity and ensure that the bike and VR set are connected, then run theFitZoom.exe application on the github repository.

HTC Vive Only:

1. Download or clone the project from github https://github.com/BrianCottrell/fit-zoom and install the latest version of Unity.

2. Open and run the project in Unity while wearing the headset either have hands on the keys and remember the controls or have another person control the keyboard. 

3. When the application loads, hold the enter and backspace keys to dismiss the start screen.

4. Navigate the application by using the spacebar to move forward and the "A" or "D" keys at the same time as the left or right arrows to turn.
Use the arrow keys to look up, down, left, or right.

Computer Only:

1. Download or clone the project from github https://github.com/BrianCottrell/fit-zoom and install the latest version of Unity.

2. Open and run the project in Unity.

3. When the application loads, hold the enter and backspace keys to dismiss the start screen.

4. Navigate the application by using the spacebar to move forward and the "A" or "D" keys at the same time as the left or right arrows to turn.
Use the arrow keys to look up, down, left, or right.

When you reach the end of the path, your fitness data is automatically sent to the OpenShift server.
To view the data, visit the project website
http://nodejs-mongodb-example-fit-zoom.0ec9.hackathon.openshiftapps.com/
If you have a VirZOOM exercise bike, enter your VirZoom account name, otherwise log in with the name:
azinicus
which is loaded into the application when no VirZOOM is detected.

The OpenShift application code can also be found here:
https://github.com/BrianCottrell/fit-shift
