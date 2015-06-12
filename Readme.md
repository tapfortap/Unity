# Unity - SDK Implementation #

##  General Information ##

Integrating Tap for Tap into your Unity Project is really easy! Follow the steps below to get started.

# Instructions (Unity) #

##  Step 1: Add Tap for Tap to Your Project.

- Download the [Tap for Tap Unity Plugin](https://github.com/tapfortap/Unity/archive/master.zip).

- Unzip the archive.

- Import the TapForTapUnity.unitypackage:
    - Go to Assets -> Import Package -> Custom Package...

    - Leave all files selected and click `Import`

## Step 2 - Add Your API Key to Your AndroidManifest.xml

In your Assets find the file `AndroidManifest.xml` under `Assets/Plugins/Android` and look for the following meta tag:

```xml
<meta-data
    android:name="com.tapfortap.API_KEY"
    android:value="MY_API_KEY"/>
```

Replace `MY_API_KEY` with your Tap for Tap API key which can be found on the [account](https://tapfortap.com/manage/account) page.


## Step 3 - Initialize the SDK

To initialize TapForTap, call the following code and replace `YOUR_API_KEY` with your personal API Key.

```
TapForTap.initialize("YOUR_API_KEY");
```

## Step 4 - Display Ads

### Banners

Banners are not yet supported.

### Break Interstitials

Showing an break interstitial is easy.

- First make sure you have initialized the TapForTap SDK as described in step 3.

- Call `Interstitial.loadBreakInterstitial()` to create a new Break Interstitial. The method returns an Interstitial - make sure to store it as you will need it later to show the Interstitial once it has loaded.

```csharp
		var interstitial = Interstitial.loadBreakInterstitial();
```

- Subscribe to the `interstitialDidReceiveAdd` event from the InterstitialListener. Because of JNI limitaions there is currently only one default Listener, which can be accessed by calling `TapForTap.getInterstitialListener()`.

```csharp
		TapForTap.getInterstitialListener().interstitialDidReceiveAd += () => {
			Debug.Log ("Interstitial is ready!");
			interstitial.show(); 
		};
```

### Achievement and Rescue Interstitials

Achievement and Rescue interstitials work similarly to Break interstitials. You should use these at points in your application where you'd like to reward the user, or to allow them to continue playing by watching an advertisement.


Call `loadAchievementInterstitial` or `loadRescueInterstitial`:

```csharp
    interstitial = Interstitial.loadRescueInterstitial ("Need a Boost?", "My App", "Watch a short message", "Free boost", "http://yourdomain.com/app_logo.png", "Tap for your free boost!");

```

```csharp
    interstitial = Interstitial.loadAchievementInterstitial ("You beat the level!", "a free gift!", "http://yourdomain.com/app_logo.png");
```

## Step 7 - Send Optional Information About Your Users
If you have information about your users that your privacy policy allows you to share with us,
you can improve performance and revenue by passing it along.
We accept year of birth, gender, location, and the account ID of user's on your system.

```csharp
TapForTap.setGender(<MALE or FEMALE>);
TapForTap.setYearOfBirth(<year>);
TapForTap.setLocation(<location>);
TapForTap.setUserAccountId(<accountId>);
```
Where gender is `either` `Gender.male` or `Gender.female`, `age` is a positive integer, `location` is two doubles (double latitude, double longitude), and user `account ID`s are strings.

**Note:** If you are using Tap for Tap's [monetization](/doc/monetization) program passing this information can greatly increase your revenue.
