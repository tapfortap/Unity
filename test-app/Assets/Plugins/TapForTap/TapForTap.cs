/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

using UnityEngine;
using System.Collections;

public class TapForTap : MonoBehaviour
{
    private static ITapForTap tft;
    private static TapForTap tapForTap;
    private static ITapForTapAdView adViewListener;
    private static ITapForTapAppWall appWallListener;
    private static ITapForTapInterstitial interstitialListener;
    
    public static void initialize (string apiKey)
    {    
        if (tapForTap == null) {
            GameObject go = new GameObject ("_TapForTap");
            go.hideFlags = HideFlags.HideAndDontSave;
            DontDestroyOnLoad (go);
            tapForTap = go.AddComponent<TapForTap> ();
            tft = TapForTapFactory.createTapForTap ();
            tft.InitializeWithApiKey (apiKey);
        }        
    }

	public static void initialize (string apiKey, string mode)
    {
        if (tapForTap == null) {
            GameObject go = new GameObject ("_TapForTap");
            go.hideFlags = HideFlags.HideAndDontSave;
            DontDestroyOnLoad (go);
            tapForTap = go.AddComponent<TapForTap> ();
            tft = TapForTapFactory.createTapForTap ();
			tft.SetMode(mode);
            tft.InitializeWithApiKey (apiKey);
        }
    }
    
    public static void setAdViewListener (ITapForTapAdView listener)
    {
        adViewListener = listener;    
    }
    
    public static void setAppWallListener (ITapForTapAppWall listener)
    {
        appWallListener = listener;
    }
    
    public static void setInterstitiallListener (ITapForTapInterstitial listener)
    {
        interstitialListener = listener;
    }
    
    public static void SetYearOfBirth (int yearOfBirth)
    {
        tft.SetYearOfBirth (yearOfBirth);
    }
    
    public static void SetGender (TapForTapGender gender)
    {
        tft.SetGender (gender);    
    }
    
    public static void SetLocation (double latitude, double longitude)
    {
        tft.SetLocation (latitude, longitude);
    }
    
    public static void SetUserAccountId (string userAccountId)
    {
        tft.SetUserAccountId (userAccountId);
    }
    
    public static void CreateAdView (TapForTapVerticalAlignment vertical, TapForTapHorizontalAlignment horizontal)
    {
        tft.CreateAdView (horizontal, vertical);        
    }
    
    public void OnTapAd ()
    {
        if (adViewListener != null) {
            adViewListener.OnTapAd ();
        }
    }
    
    public void OnReceiveAd ()
    {
        if (adViewListener != null) {
            adViewListener.OnReceiveAd ();
        }
    }
        
    public void OnFailToReceiveAd (string reason)
    {
        if (adViewListener != null) {
            adViewListener.OnFailToReceiveAd (reason);
        }
    }
    
    public static void RemoveAdView ()
    {
        tft.RemoveAdView ();
    }
    
    public static void ShowInterstitial ()
    {
        tft.ShowInterstitial ();
    }
    
    public static void PrepareInterstitial ()
    {
        tft.PrepareInterstitial ();    
    }
    
	public void OnInterstitialReceiveAd () {
		if (interstitialListener != null) {
            interstitialListener.OnReceive();
        }
	}

	public void OnInterstitialShow () {
		if (interstitialListener != null) {
            interstitialListener.OnShow();
        }
	}

	public void OnInterstitialTap () {
		if (interstitialListener != null) {
            interstitialListener.OnTap();
        }
	}

    public void OnInterstitialDismissed ()
    {
        if (interstitialListener != null) {
            interstitialListener.OnDismiss ();
        }
    }
    
	public void OnInterstitialFailed (string reason)
    {
        if (interstitialListener != null) {
            interstitialListener.OnFail (reason);
        }
    }

    public static void ShowAppWall ()
    {
        tft.ShowAppWall ();
    }
    
    public static void PrepareAppWall ()
    {
        tft.PrepareAppWall ();    
    }
    
	public void OnAppWallReceiveAd () {
		if (interstitialListener != null) {
            interstitialListener.OnReceive();
        }
	}

	public void OnAppWallShow () {
		if (interstitialListener != null) {
            interstitialListener.OnShow();
        }
	}

	public void OnAppWallTap () {
		if (interstitialListener != null) {
            interstitialListener.OnTap();
        }
	}

    public void OnAppWallDismissed ()
    {
        if (appWallListener != null) {
            appWallListener.OnDismiss ();    
        }
    }

    public void OnAppWallFailed (string reason)
    {
        if (appWallListener != null) {
            appWallListener.OnFail (reason);
        }
    }
}
