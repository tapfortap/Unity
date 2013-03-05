/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

public interface ITapForTapAdView
{
    void OnTapAd ();

    void OnReceiveAd ();

    void OnFailToReceiveAd (string reason);
}
