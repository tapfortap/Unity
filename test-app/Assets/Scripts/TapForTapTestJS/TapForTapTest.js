/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

#pragma strict

var turn = 0;
var showCorners = false;

function Start ()
    {
        TapForTap.initialize ("YOUR API KEY");
        
        TapForTap.SetYearOfBirth (1990);
        TapForTap.SetGender (TapForTapGender.MALE);
        TapForTap.SetLocation (1.23, 4.56);
        TapForTap.SetUserAccountId ("My test user account id");
        TapForTap.ShowInterstitial();
        InvokeRepeating ("UpdateAds", 0.0f, 3.0f);
    }
    
    function UpdateAds ()
    {    
        
            switch (turn) {
            case 0:
                if (showCorners) {
                    TapForTap.CreateAdView (0, 0);
                } else {
                    TapForTap.CreateAdView (0, 1);
                }
                break;
            case 1:
                if (showCorners) {
                    TapForTap.CreateAdView (0, 2);
                } else {
                    TapForTap.CreateAdView (1, 2);
                }
                break;
            case 2:
                if (showCorners) {
                    TapForTap.CreateAdView (2, 2);
                } else {
                    TapForTap.CreateAdView (2, 1);
                }
                break;
            case 3:
                if (showCorners) {
                    TapForTap.CreateAdView (2, 0);
                } else {
                    TapForTap.CreateAdView (1, 0);
                }
                break;
            case 4:
                TapForTap.CreateAdView (1, 1);
                showCorners = !showCorners;
                turn = 0;
                break;
            }
            turn++;
    }