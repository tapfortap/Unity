# Tap for Tap Unity Plugin

For more information about Tap for Tap visit [https://tapfortap.com](https://tapfortap.com)

For documentation on how to use the Unity plugin visit the [Tap for Tap documentation portal](https://tapfortap.com/doc/plugins/Unity).

# Unity  Build Instructions 

1. Install Unity
2. Set the following environment variables:
  - For Android
      - `ANDROID_SDK="PATH TO ANDROID SDK"` (ie. `/usr/local/android/`) 
      - `ANDROID_TARGET="ANDROID TARGET SDK"` (ie. `17`)
  - For iOS
      - `IOS_TARGET="IPHONE TARGET SDK"` (ie. `iphoneos6.1`)
  - For Unity
      - `UNITY_SDK="PATH TO YOUR UNITY SDK"` (ie. `/Applications/Unity/`)
3. Run `release.sh`

1.3.0 / 2013-03-05
==================
### General
- Add three new callbacks to app-walls and interstitials
  - OnReceive
      - Called when a new ad is finished downloading
  - OnShow
  	  - Called when an ad is shown
  - On Tap
  	  - Called when the user taps the ad

### Android
- Update TapForTap.jar to 3.0.5

### iOS
- Update libTapForTap.a to 3.0.5

1.2.0 / 2013-03-05
==================
### Android
- Update TapForTap.jar to 2.2.0

### iOS
- Update libTapForTap.a to 2.2.0

1.1.0 / 2013-01-30
==================

General
=======
* Move Tap for Tap files from Script/ to Plugin/ so UnityScript programs can use TapForTap
* Implemented a TapForTapNull if platform is neither iOS or Android

Android
=======
* Updated to Tap for Tap Android SDK 2.1.1

iOS
===
* Updated to Tap for Tap iOS SDK 2.1.1
* Fixed a potential invalid memory release 

1.0.0 / 2012-12-18
==================
- First release
