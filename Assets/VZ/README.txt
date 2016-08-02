VIRZOOM SDK 1.0

RELEASE NOTES

   1.0
   - Initial release

DESCRIPTION

The VirZOOM SDK allows you to quickly create and adapt games that talk to the VirZOOM Bike Controller. It provides access to all the sensor data from the bike, including speed, pedal direction, buttons, resistance setting, and heartrate. It also includes a high-level player controller, using our patent-pending motion controls, that combine the bike sensors with your head movement to comfortably move through large VR worlds.

Please see http://virzoom.com/support for SDK documentation, and http://virzoom.com/forums/forum-20.html for SDK discussion. Usage of this SDK and the VirZOOM Bike Controller is governed by the License Agreement at http://virzoom.com/eula.htm.

Compatible with Unity 5.4.0+ and Oculus Rift, HTC Vive, and Playstation VR.

SETUP

The VirZOOM SDK requires your project to be setup for Virtual Reality and needs a few other customized settings.

   1. For Windows builds, in BuildSettings set architecture to x86_64
   
   2. In PlayerSettings 
      
      a. set Api Compatibility Level to .NET 2.0 (not Subset)

      b. check Virtual Reality Supported 

      c. add your VR device to the list of VR SDKs

   3. Copy or merge Assets/StreamingAssets/InputManager.asset into your ProjectSettings/InputManager.asset

TEST SCENE

   1. Open Assets/VZ/Scenes/test.unity and hit Play

   2. Get on the bike, put on your VR headset, and hold the L and R triggers to calibrate

   3. Pedal to move forward, lean to turn

MORE INFO

   1. Find the SDK documentation section at http://virzoom.com/support

   1. See VirZOOM's talk at UNITE 2015 (https://www.youtube.com/watch?v=nHLIQjL6Rho)

   2. Join our SDK forum discussion at https://virzoom.com/forums/forum-27.html
