/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

using UnityEngine;
using System.Collections;

public class TapForTapNull : ITapForTap
{
    public void InitializeWithApiKey (string apiKey)
    {
		Debug.Log("Tap for Tap InitializeWithApiKey");
    }
    
    public void SetYearOfBirth (int yearOfBirth)
    {
		Debug.Log("Tap for Tap SetYearOfBirth");
    }
    
    public void SetGender (TapForTapGender gender)
    {
		Debug.Log("Tap for Tap SetGender");
    }
    
    public void SetLocation (double latitude, double longitude)
    {
		Debug.Log("Tap for Tap SetLocation");
    }
    
    public void SetUserAccountId (string userAccountId)
    {
		Debug.Log("Tap for Tap SetUserAccountId");
    }
    
    public void CreateAdView (TapForTapHorizontalAlignment horizontal, TapForTapVerticalAlignment vertical)
    {
		Debug.Log("Tap for Tap CreateAdView");
    }
    
    public void RemoveAdView ()
    {
		Debug.Log("Tap for Tap RemoveAdView");
    }
    
    public void PrepareInterstitial ()
    {
		Debug.Log("Tap for Tap PrepareInterstitial");
    }
    
    public void ShowInterstitial ()
    {
		Debug.Log("Tap for Tap ShowInterstitial");
    }
    
    public void PrepareAppWall ()
    {
		Debug.Log("Tap for Tap PrepareAppWall");
    }
    
    public void ShowAppWall ()
    {
		Debug.Log("Tap for Tap ShowAppWall");
    }
    
    public void SetMode (string mode)
    {
		
    }
}
