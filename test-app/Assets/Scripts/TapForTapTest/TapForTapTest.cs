/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

using UnityEngine;

public class TapForTapTest : MonoBehaviour
{
    private bool isShowInterstitial = false;
    private bool isShowAppWall = false;
    private bool showCorners = true;
    private int turn = 0;
    private TapForTapAppWallListener appWallListener;
    private TapForTapInterstitialListener interstitialListener;
    
    public void Start ()
    {
        TapForTap.initialize ("acb9e550dda1679b29401d26edb4f23b");
        
        TapForTap.setAdViewListener (new TapForTapAdViewListener ());
        
        appWallListener = new TapForTapAppWallListener ();
        TapForTap.setAppWallListener (appWallListener);
        
        interstitialListener = new TapForTapInterstitialListener ();
        TapForTap.setInterstitiallListener (interstitialListener);
        
        TapForTap.PrepareAppWall ();
        TapForTap.PrepareInterstitial ();
        TapForTap.SetYearOfBirth (1990);
        TapForTap.SetGender (TapForTapGender.MALE);
        TapForTap.SetLocation (1.23, 4.56);
        TapForTap.SetUserAccountId ("My test user account id");
        
        InvokeRepeating ("UpdateAds", 0.0f, 3.0f);
    }
    
    public void UpdateAds ()
    {    
        if (isShowInterstitial) {
            isShowInterstitial = false;
            TapForTap.ShowInterstitial ();
            turn = 0;
        } else if (isShowAppWall) {
            isShowAppWall = false;
            TapForTap.ShowAppWall ();
            turn = 0;
        }
        
        if (appWallListener.isDismissed () && interstitialListener.isDismissed ()) {
            switch (turn) {
            case 0:
                if (showCorners) {
                    TapForTap.CreateAdView (TapForTapVerticalAlignment.TOP, TapForTapHorizontalAlignment.LEFT);
                } else {
                    TapForTap.CreateAdView (TapForTapVerticalAlignment.TOP, TapForTapHorizontalAlignment.CENTER);
                }
                break;
            case 1:
                if (showCorners) {
                    TapForTap.CreateAdView (TapForTapVerticalAlignment.TOP, TapForTapHorizontalAlignment.RIGHT);
                } else {
                    TapForTap.CreateAdView (TapForTapVerticalAlignment.CENTER, TapForTapHorizontalAlignment.RIGHT);
                }
                break;
            case 2:
                if (showCorners) {
                    TapForTap.CreateAdView (TapForTapVerticalAlignment.BOTTOM, TapForTapHorizontalAlignment.RIGHT);
                } else {
                    TapForTap.CreateAdView (TapForTapVerticalAlignment.BOTTOM, TapForTapHorizontalAlignment.CENTER);
                }
                break;
            case 3:
                if (showCorners) {
                    TapForTap.CreateAdView (TapForTapVerticalAlignment.BOTTOM, TapForTapHorizontalAlignment.LEFT);
                } else {
                    TapForTap.CreateAdView (TapForTapVerticalAlignment.CENTER, TapForTapHorizontalAlignment.LEFT);
                }
                break;
            case 4:
                TapForTap.CreateAdView (TapForTapVerticalAlignment.CENTER, TapForTapHorizontalAlignment.CENTER);
                if (showCorners) {
                    isShowInterstitial = false;
                    isShowAppWall = true;
                } else {
                    isShowInterstitial = true;
                    isShowAppWall = false;
                }
                showCorners = !showCorners;
                break;
            }
            turn++;
        }
    }
}

