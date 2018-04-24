# GTNav
The implementation of a fully-functional campus navigation app for iOS and Android systems.

## Release Notes (v 1.0.0)

### Features:
- Support for numerous on-campus locations through an autocompleting search
- Approximate walk times from device location to specified destination can be fetched
- Approximate travel times by campus shuttle from device location to specified destination can be fetched
- Map overlay displays Red, Blue, and Green routes, as well as current bus locations for each
- One-touch comparision between walk and ride times between device location and destination
- Integeration of Google Maps for directions

### Bugs and Limitations:
- Altering TargetFrameworkVersion tends to cause build errors in Develop mode
- In the event of a failed HTTP request, bus locations may fail to update periodically. Close and reopen to fix
- Directions to certain bus stops may not be available

## Install Guide

### Prerequisites:

As the application is not yet available through the Google Play store, it is necessary to build it from source. To do this, the Visual Studio IDE with the Xamarin plugin are needed. You can get it here: https://www.visualstudio.com/xamarin/

### Download Instructions:

To obtain the project files, clone this project into a local directory with git commmand:

git clone https://github.com/nhazelton/GTNav.git

Alternatively, download a .zip archive of the project using Github's Clone or Download link above

### Build Instructions:

With the Visual Studio IDE (with Xamarin plugin) and project source on hand, open Visual Studio and load GTNav.sln. Once the environment finishes setting up, locate the menu bar at the top of the screen and choose Build -> Clean Solution. The console will begin outputting build information. When the clean operation finishes, choose Build -> Build Solution (if this returns errors, then try Build -> Rebuild Solution several times). When the console reports that the build or rebuild has succeded, then the application is ready to be run.

### Installation Instructions:

To install the software, an Android device is needed (see the next paragraph for emulation instructions if none is available). Before attempting to install the application, ensure that the Solution deploy settings are correct: right click on Solution 'GTNav' in Solution Explorer, select Properties, select Single startup project radio button in Startup Project, and select GTNav.Droid. Now connect the Android device to the computer, making sure that USB debugging is enabled (to do this, see https://www.embarcadero.com/starthere/xe5/mobdevsetup/android/en/enabling_usb_debugging_on_an_android_device.html) Then, near the top, click the dropdown next to the green play button and select your connected Android device. Now click the green play button itself and the deploy will begin.

If no Android device is available, then the application can be run using an Android virtual emulator instead. By default, Visual Studio comes with an Accelerated Nougat Android emulator. If needed, new emulators can be created by clicking the Android Emulator Manager (AVD) button just to the right of the green play button dropdown. Once an emulator is established, it behaves as though it were a connected Android device and can be deployed to.

### Run Instructions:

Once the project has been deployed, it will remain on the connected Android device as an application. It can be relaunched in its current state at any time by selecting it from the device's applications menu.

### Troubleshooting:

#### What to do if ...


