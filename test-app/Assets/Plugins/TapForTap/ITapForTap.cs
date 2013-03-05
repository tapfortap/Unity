/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

public interface ITapForTap
{
    void InitializeWithApiKey (string apiKey);
    
    void SetYearOfBirth (int yearOfBirth);

    void SetGender (TapForTapGender gender);

    void SetLocation (double latitude, double longitude);

    void SetUserAccountId (string userAccountId);
    
    void CreateAdView (TapForTapHorizontalAlignment horizontal, TapForTapVerticalAlignment vertical);

    void RemoveAdView ();
    
    void PrepareAppWall ();

    void PrepareInterstitial ();
    
    void ShowInterstitial ();

    void ShowAppWall ();
    
    void SetMode (string mode);
}


