/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

using UnityEngine;

public class TapForTapAdViewListener : ITapForTapAdView
{
    public void OnTapAd ()
    {
        Debug.Log ("Called my OnTapAd");
    }

    public void OnReceiveAd ()
    {
        Debug.Log ("Called my OnReceiveAd");
    }

    public void OnFailToReceiveAd (string reason)
    {
        Debug.Log ("Called my OnFailToReceiveAd" + reason);
    }
}
