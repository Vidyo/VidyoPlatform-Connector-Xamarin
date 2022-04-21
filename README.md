# VidyoPlatform Connector Xamarin

## Clone Repository
git clone https://github.com/Vidyo/vidyoplatform-connector-xamarin.git

## Overview
VidyoConnector-xamarin is a Xamarin Forms cross platform application which contains three projects:
1. VidyoConnector         : Portable Class Library (PCL) containing shared code that can be used in Xamarin.iOS and Xamarin.Android (and more).
2. VidyoConnector.iOS     : iOS application which leverages the VidyoConnector PCL in building it's UI.
3. VidyoConnector.Android : Android application which leverages the VidyoConnector PCL in building it's UI.

## Acquire VidyoClient iOS and Android SDKs
> Note: Highlighted steps are very important because samples already contain configurations specified below and both SDK packages are linked as relative folders located in VidyoConnector-xamarin directory.

1. Download VidyoPlatform iOS SDK package: https://static.vidyo.io/22.1.0.30/package/VidyoClient-iOSSDK.zip
2. **Move the unzipped VidyoClient-iOSSDK folder to the /vidyoplatform-connector-xamarin/ directory.**
3. Download VidyoPlatform Android SDK package: https://static.vidyo.io/22.1.0.30/package/VidyoClient-AndroidSDK.zip
4. **Move the unzipped VidyoClient-AndroidSDK folder to the /vidyoplatform-connector-xamarin/ directory.**

> Note: VidyoClient SDK version **22.1.0.30** is required.

#### Important update for Android ####
VidyoClient depends on Kotlin Library starting from 21.6 version. 
Please add Kotlin Std Lib [Xamarin.Kotlin.StdLib] via NuGet dependency manager.

#### Important update for iOS ####
VidyoClient depends on Banuba SDK means you have to add it anyways. 
Banuba depends on "Photos" system framework so you have to extend the list:

#### 22.x Updates
- Android: 
        (1) Kotlin Std Lib [add Xamarin.Kotlin.StdLib]
        (2) only one dependency file VidyoClient.aar [AndroidAarLibrary]
- iOS: 
        (1) Banuba framework 
        (2) add -lc++ 
        (3) libsrtp.a change to libsrtp2.a 
        (4) list Photos framework

### Connect Credentials

For demo purposes please check ViewModel.cs C# file and modify connect credetials:

        string _portal = "*.platform.vidyo.io"; // Insert valid Portal FQDN e.g.: *.platform.vidyo.io
        string _roomKey = ""; // Insert valid RoomKey e.g.: 8huaP05z6Z
        string _displayName = "Xamarin User"; // Insert your Display Name
        string _roomPin = ""; // Insert valid roomPin e.g.: Res$!dfs45

Documentation: https://vidyo.github.io/vidyoplatform.github.io

## Importing VidyoClient iOS SDK

> Important Note: the below steps are already performed in the VidyoConnector.iOS  project in the VidyoConnector solution. These instructions are intended to show how a developer would import the library into their own application. Therefore, do not perform these steps in this application, which would lead to duplicated libraries and compilation errors. For this sample, please make sure you have placed the SDK in the right folder and then skip to the "Build and Run Application" section.

To use the VidyoClient SDK in a Xamarin.iOS app, perform the following steps: 

#### macOS

1.  In the Solution pad, right-click on the Xamarin.iOS project and select "Add" > "Add Existing Folder".
2.  In the file-selection dialog, browse to project subdirectory "VidyoClient-iOSSDK".
3.  Click "Open" to finish the file selection.
4.  Under "Choose files to include in the project", click the checkbox to the left of "VidyoClient-iOSSDK > include > csharp" and select "OK". 
5.  In the Solution pad, right-click on the Xamarin.iOS project and select "Add" > "Add Native Reference".
6.  In the file-selection dialog, browse to project subdirectory "VidyoClient-iOSSDK/lib/ios".
7.  From that directory, select all 6 static library files "lib*.a", framework "VPX.framework" and at Banuba folder "BNBEffectPlayerC".
8.  Click "Open" to finish the file selection.
9.  In the Solution pad, expand the new "Native References" folder in the project; right-click "libVidyoClient"; and choose "Properties".
10. In that "Properties" pad, go to the "Frameworks" field.
11. Enter the following list of iOS frameworks from Apple:  AudioToolbox AVFoundation CoreLocation CoreMedia SystemConfiguration UIKit Photos
12. In the Solution pad, expand the new "Native References" folder in the project; right-click "BNBEffectPlayerC"; and choose "Properties".
13. Select Kind Dropdown -> Framework and under Linker Flags add: -lc++

#### Windows

1. In the solution toolbar, find "Show All Files" option and select it.
2. In the solution window, expand grayed "VidyoClient-iOSSDK" folder to "include > csharp", right-click on "csharp" folder and choose "Include in Project" option.
3. In the solution window, right-click on the Xamarin.iOS project and select "Add Native Reference" > "Add Native Static Library"
4. In the file-selection dialog, browse to project subdirectory“VidyoClient-iOSSDK/lib/ios”
5. From that directory, add one by one  all 6 static library files `lib*.a`. You have to do it 6 times as multi-include may not be allowed.
6. In the solution window, right-click on the Xamarin.iOS project and select "Add Native Reference" > "Add Native Framework Library"
7. In the folder-selection dialog, browse to project subdirectory“VidyoClient-iOSSDK/lib/ios”
8. Select VPX.framework folder. Click OK.
9. In the Solution pad, expand the new "Native References" folder in the project; right-click "libVidyoClient"; and choose "Properties".
10. In that "Properties" pad, go to the "Frameworks" field.
11. Enter the following list of iOS frameworks from Apple: AudioToolbox AVFoundation CoreLocation CoreMedia SystemConfiguration UIKit Photos
12. In the Solution pad, expand the new "Native References" folder in the project; right-click "BNBEffectPlayerC"; and choose "Properties".
13. Select Kind Dropdown -> Framework and under Linker Flags add: -lc++

## Importing VidyoClient Android SDK
> Note: the below steps are already performed in the VidyoConnector.Android project in the VidyoConnector solution. These instructions are intended to show how a developer would import the library into their own application. Therefore, do not perform these steps in this application, which would lead to duplicated libraries and compilation errors. For this sample, please make sure you have placed the SDK in the right folder and then skip to the "Build and Run Application" section.

To use the VidyoClient SDK in a Xamarin.Android app, perform the following steps:

#### macOS

1. In the Solution pad, right-click on the Xamarin.Android project and select "Add" > "Add Existing Folder".
2. In the file-selection dialog, browse to project subdirectory "VidyoClient-AndroidSDK".
3. Click "Open" to finish the file selection.
4. Under "Choose files to include in the project", click the checkbox to the left of "VidyoClient-Android" and select "OK". 
5. In the Solution pad, expand the new "VidyoClient-AndroidSDK/lib/android" folder in the project.
6. Right-click on "VidyoClient.aar" and choose "Properties".
7. In that "Properties" pad, go to the "Build action" field and populate it with "AndroidAarLibrary".

#### Windows

1. In the solution toolbar, find "Show All Files" option and switch it.
2. In the solution window, expand grayed "VidyoClient-AndroidSDK" folder to "include > csharp", right-click on "csharp" folder and choose "Include in Project" option.
3. In the solution window, expand grayed "VidyoClient-AndroidSDK" folder to "lib > android", right-click on "android" folder and choose "Include in Project" option.
4. In the solution window, expand "android" folder, right-click on "VidyoClient.aar" and choose "Properties".
5. In that "Properties" window, go to the "Build action" field and populate it with "AndroidAarLibrary".

## Build and Run Application
1. Open VidyoConnector.sln in either Visual Studio or Xamarin Studio version 6.3 or later.
2. Set either VidyoConnector.iOS or VidyoConnector.Android as the Startup Project, depending on which type of device you want to load the application to.
3. Connect an iOS or Android device to the computer via USB.
4. Select the iOS or Android device as the build target of the application.
5. Build and run the application on the iOS or Android device.

