/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

using UnityEngine;

public class TapForTapInterstitialListener : ITapForTapInterstitial
{
    bool dismissed = true;
    
	public void OnReceive () {
		Debug.Log ("Called my Interstitial OnReceive");
	}

	public void OnShow () {
		Debug.Log ("Called my Interstitial OnShow");
	}

	public void OnTap() {
		Debug.Log ("Called my Interstitial OnTap");
	}

    public void OnDismiss ()
    {
        Debug.Log ("Called my Interstitial OnDismiss");
        dismissed = true;
    }
	
	public void OnFail (string reason)
    {
        Debug.Log ("Failed to download Interstitial because: " + reason);
        dismissed = true;
    }
    
    public void showing ()
    {
        dismissed = false;
    }
    
    public bool isDismissed ()
    {
        return dismissed;
    }
}

