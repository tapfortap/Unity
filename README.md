# Tap for Tap Unity Plugin (Coming Soon!)

Want to use Tap for Tap with Unity? We got you covered on Android and iOS.

## Preamble
This Unity plugin was built and tested against Unity 3.5.

### Minimum Requirements
#### iPhone
  - An OS X machine running Lion (10.7)
  - iOS 6.0 SDK

## Integration
If you don't have the plugin yet then head over to the [no link](need url).

Installing the Tap for Tap Unity Plugin is easy. This isn't a Unity tutorial so we 
assume that you have a Unity project already set up and working. All you need to 
do is import the TapForTap.unitypackage into your app. Then follow the steps below
for Android and iOS

### Configuring Tap for Tap for iOS
- Add the AdSupport framework.

### Configuring Tap for Tap for Android

1. Add the following permissions Unity's AndroidManifest.xml
  `<uses-permission android:name="android.permission.INTERNET" />`
  `<uses-permission android:name="android.permission.READ_PHONE_STATE" />`
  `<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />`
  `<uses-permission android:name="android.permission.ACCESS_WIFI_STATE" />`
  `<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />`
2. Include the TapForTap activity in Unity's AndroidManifest.xml  
  `<activity android:name="com.tapfortap.TapForTapActivity"/>`

Congratulations, you are done. You should now be able to call into the Tap for Tap library
and begin displaying ads.

## API Documentation
The C# API lets you create, place, and remove Tap for Tap ad views,
interstitals and app walls and set various optional information about your users
to help us with targetting. Please make sure your privacy policy allows this
before giving us their personal information.

### Tap for Tap API

#### public static void initialize(string apiKey)
This must be called once before any other TapForTap calls can be made.

Usage:

```cs
  TapForTap.initialize("MY API KEY");
```

#### public static void setAdViewListener(ITapForTapAdView listener)
Sets the AdViewListener that will receive the callbacks. See [IAdViewListener](#IAdViewListener)
for more details and available callback methods.

Usage:

```cs
  TapForTap.setAdViewListener(myAdViewListener);
```

#### public static void setAppWallListener(ITapForTapAppWall listener) 
#### public static void setInterstitiallListener(ITapForTapInterstitial listener) 

#### public static void SetYearOfBirth(int yearOfBirth)
#### public static void SetGender(TapForTapGender gender)
#### public static void SetLocation(double latitude, double longitude)
#### public static void SetUserAccountId(string userAccountId)

#### public static void CreateAdView(TapForTapHorizontalAlignment horizontal, TapForTapVerticalAlignment vertical)
#### public static void RemoveAdView()

#### public static void ShowInterstitial()
#### public static void PrepareInterstitial()

#### public static void ShowAppWall()
#### public static void PrepareAppWall()

### IAdViewListener

### IAppWallListener

### IInterstitialListener

======

## [Back To Documentaion](http://tapfortap.github.com/Documentation/) ##

### *Support* ###
Things don't always go according to plan. If you hit a snag somewhere and need a hand don't hesitate to get in touch with us at [support@tapfortap.com](mailto:support@tapfortap.com) or on Zendesk [here](https://tapfortap.zendesk.com/anonymous_requests/new).

### *License* ###
Licensed under the terms of the MIT License.

Copyright &copy; 2012 Tap for Tap Promotions Inc.
