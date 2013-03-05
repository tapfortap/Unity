/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

using UnityEngine;

public class TapForTapFactory
{
    public static ITapForTap createTapForTap ()
    {
#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
        	return new TapForTapAndroid();
		} else {
			return new TapForTapNull();
		}
#elif UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			return new TapForTapiOS();
		} else {
			return new TapForTapNull();
		}
#else
        return new TapForTapNull();
#endif
    }
}

