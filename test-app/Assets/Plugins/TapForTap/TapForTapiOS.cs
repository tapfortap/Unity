/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

#if UNITY_IPHONE

using UnityEngine;
using System.Runtime.InteropServices;

public class TapForTapiOS : ITapForTap 
{
    [DllImport ("__Internal")] private static extern void initializeWithApiKey(string apiKey);
    
    [DllImport ("__Internal")] private static extern void setYearOfBirth(int yearOfBirth);
    [DllImport ("__Internal")] private static extern void setGender(int gender);
    [DllImport ("__Internal")] private static extern void setLocation(double latitude, double longitude);
    [DllImport ("__Internal")] private static extern void setUserAccountId(string userAccountId);
            
    [DllImport ("__Internal")] private static extern void createAdView(int horizontal, int vertical);
    [DllImport ("__Internal")] private static extern void removeAdView();
    
    [DllImport ("__Internal")] private static extern void prepareInterstitial();
    [DllImport ("__Internal")] private static extern void showInterstitial();
    [DllImport ("__Internal")] private static extern void prepareAppWall();
    [DllImport ("__Internal")] private static extern void showAppWall();
    
    [DllImport ("__Internal")] private static extern void setMode(string mode);
    
    public void InitializeWithApiKey(string apiKey)
    {
        initializeWithApiKey(apiKey);
    }
    
    public void SetYearOfBirth(int yearOfBirth)
    {
        setYearOfBirth(yearOfBirth);    
    }
    
    public void SetGender(TapForTapGender gender)
    {
        setGender((int)gender);
    }
    
    public void SetLocation(double latitude, double longitude)
    {
        setLocation(latitude, longitude);
    }
    
    public void SetUserAccountId(string userAccountId)
    {
        setUserAccountId(userAccountId);
    }
    
    public void CreateAdView(TapForTapHorizontalAlignment horizontal, TapForTapVerticalAlignment vertical)
    {
        createAdView((int)horizontal, (int)vertical);
    }
    
    public void RemoveAdView()
    {
        removeAdView();
    }
    
    public void PrepareInterstitial()
    {
        prepareInterstitial();
    }
    
    public void ShowInterstitial()
    {
        showInterstitial();
    }
    
    public void PrepareAppWall()
    {
        prepareAppWall();
    }
    
    public void ShowAppWall()
    {
        showAppWall();
    }
    
    public void SetMode(string mode)
    {
        setMode(mode);
    }
}

#endif
