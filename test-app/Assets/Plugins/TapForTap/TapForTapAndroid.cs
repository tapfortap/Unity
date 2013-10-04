/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

#if UNITY_ANDROID
using UnityEngine;
using System.Collections;

public class TapForTapAndroid : ITapForTap
{
    public void InitializeWithApiKey (string apiKey)
    {
		AndroidJavaClass tftu = new AndroidJavaClass ("com.tapfortap.unity.TapForTapUnity");
        tftu.CallStatic ("initializeWithApiKey", apiKey);
    }
    
    public void SetYearOfBirth (int yearOfBirth)
    {
        AndroidJavaClass tft = new AndroidJavaClass ("com.tapfortap.TapForTap");
        tft.CallStatic ("setYearOfBirth", yearOfBirth);
    }
    
    public void SetGender (TapForTapGender gender)
    {
        AndroidJavaClass tftu = new AndroidJavaClass ("com.tapfortap.unity.TapForTapUnity");
        tftu.CallStatic ("setGender", (int)gender);
    }
    
    public void SetLocation (double latitude, double longitude)
    {
        AndroidJavaClass tftu = new AndroidJavaClass ("com.tapfortap.unity.TapForTapUnity");
        tftu.CallStatic ("setLocation", latitude, longitude);
    }
    
    public void SetUserAccountId (string userAccountId)
    {
        AndroidJavaClass tft = new AndroidJavaClass ("com.tapfortap.TapForTap");
        tft.CallStatic ("setUserAccountId", userAccountId);
    }
    
    public void CreateAdView (TapForTapHorizontalAlignment horizontal, TapForTapVerticalAlignment vertical)
    {
        AndroidJavaClass tftu = new AndroidJavaClass ("com.tapfortap.unity.TapForTapUnity");
        tftu.CallStatic ("createAdView", (int)horizontal, (int)vertical);
    }
    
    public void RemoveAdView ()
    {
        AndroidJavaClass tftu = new AndroidJavaClass ("com.tapfortap.unity.TapForTapUnity");
        tftu.CallStatic ("removeAdView");
    }
    
    public void PrepareInterstitial ()
    {
        AndroidJavaClass tftu = new AndroidJavaClass ("com.tapfortap.unity.TapForTapUnity");
        tftu.CallStatic ("prepareInterstitial");
    }
    
    public void ShowInterstitial ()
    {
        AndroidJavaClass tftu = new AndroidJavaClass ("com.tapfortap.unity.TapForTapUnity");
        tftu.CallStatic ("showInterstitial");
    }
    
    public void PrepareAppWall ()
    {
        AndroidJavaClass tftu = new AndroidJavaClass ("com.tapfortap.unity.TapForTapUnity");
        tftu.CallStatic ("prepareAppWall");
    }
    
    public void ShowAppWall ()
    {
        AndroidJavaClass tftu = new AndroidJavaClass ("com.tapfortap.unity.TapForTapUnity");
        tftu.CallStatic ("showAppWall");
    }
    
    public void SetMode (string mode)
    {
        AndroidJavaClass tft = new AndroidJavaClass ("com.tapfortap.TapForTap");
        tft.CallStatic ("setEnvironment", mode);
    }
    
    private static AndroidJavaObject getContext ()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
        return unityPlayer.GetStatic<AndroidJavaObject> ("currentActivity");
    }
}

#endif
