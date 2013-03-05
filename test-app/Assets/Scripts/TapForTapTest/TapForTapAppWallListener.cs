/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

using UnityEngine;

public class TapForTapAppWallListener : ITapForTapAppWall
{
    bool dismissed = true;
    
    public void OnDismiss ()
    {
        Debug.LogError ("Called my AppWall OnDismiss");
        dismissed = true;
    }
	
	public void OnFail (string reason)
    {
        Debug.LogError ("Failed to download AppWall because:" + reason);
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
