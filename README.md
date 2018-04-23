# GTNav
The implementation of a fully-functional campus navigation app for iOS and Android systems.

### Features:
- Search for many specific locations on GT Campus
- Compare bus and walk times
- Color-coded map of bus locations along different routes
- Integrated with Google Maps for walking directions

### Installation Instructions:
1) Download the Visual Studio IDE with the Xamarin plugin, found at https://www.visualstudio.com/xamarin/.
2) Clone this repository to your local machine.
3) Plug in an Android device and put it in developer mode. A more detailed guide on this can be found here: https://www.digitaltrends.com/mobile/how-to-get-developer-options-on-android/.
4) Open the GTNav.sln file in Visual Studio.
5) Rebuild and deploy the project.
6) Run the application by clicking the green play button in the top left of Visual Studio.

### Unimportant issues that show up:
- TargetFrameWorkVersion for the parts does not equal the TargetFrameWorkVersion for the project. This should not cause any issues but will show up when building.
- Other issues that show up pertain to the Mac portion of the project, which isn't implemented at the moment.