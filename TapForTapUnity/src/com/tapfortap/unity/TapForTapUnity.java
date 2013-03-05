/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

package com.tapfortap.unity;

import android.location.Location;
import android.util.DisplayMetrics;
import android.widget.FrameLayout.LayoutParams;
import android.widget.RelativeLayout;

import com.tapfortap.AdView;
import com.tapfortap.AdView.AdViewListener;
import com.tapfortap.AppWall;
import com.tapfortap.AppWall.AppWallListener;
import com.tapfortap.Interstitial;
import com.tapfortap.Interstitial.InterstitialListener;
import com.tapfortap.TapForTap;
import com.tapfortap.TapForTap.Gender;
import com.unity3d.player.UnityPlayer;

public class TapForTapUnity {

	private static AdView adView;
	private static RelativeLayout layout;
	private static AppWallListener appWallListener;
	private static InterstitialListener interstitialListener;
	
	public static void setGender(int gender) {
		switch(gender) {
			case 0:
				TapForTap.setGender(Gender.MALE);
				break;
			case 1:
				TapForTap.setGender(Gender.FEMALE);
				break;
			default:
				TapForTap.setGender(Gender.NONE);
				break;
		}
	}
	
    public static void initializeWithApiKey(String apiKey) {
        TapForTap.plugin = "unity";
        TapForTap.pluginVersion = "1.2.0";
        TapForTap.initialize(UnityPlayer.currentActivity, apiKey);
    }
    
	public static void setLocation(double latitude, double longitude) {
		Location location = new Location("");
		location.setLatitude(latitude);
		location.setLongitude(longitude);
		TapForTap.setLocation(location);
	}

	public static void createAdView(int horizontalAlignemnt, int verticalAlignment) {
		removeAdView();
		showAd(horizontalAlignemnt, verticalAlignment);
	}
	
	private static void showAd(final int horizontalAlignemnt, final int verticalAlignment) {
		UnityPlayer.currentActivity.runOnUiThread(new Runnable() {

			@Override
			public void run() {
				
				layout = new RelativeLayout(UnityPlayer.currentActivity);
				RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.MATCH_PARENT);
				UnityPlayer.currentActivity.addContentView(layout, layoutParams);
			
		    	
		    	// Setup the adView
		        DisplayMetrics metrics = UnityPlayer.currentActivity.getResources().getDisplayMetrics();
		        int width = (int)(320 * metrics.density);
		        int height = (int) (50 * metrics.density);

		        RelativeLayout.LayoutParams viewLayoutParams = new RelativeLayout.LayoutParams(width, height);
		        
		        switch(horizontalAlignemnt) {
		        	case 1:
		        		viewLayoutParams.addRule(RelativeLayout.ALIGN_PARENT_LEFT);
		        		break;
		        	case 2:
		        		viewLayoutParams.addRule(RelativeLayout.CENTER_HORIZONTAL);
		        		break;
		        	case 3:
		        		viewLayoutParams.addRule(RelativeLayout.ALIGN_PARENT_RIGHT);
		        		break;
		        	default:
		        		viewLayoutParams.addRule(RelativeLayout.CENTER_HORIZONTAL);
		        		break;
		        }
		        
		        switch(verticalAlignment) {
	        		case 1:
		        		viewLayoutParams.addRule(RelativeLayout.ALIGN_PARENT_TOP);
		        		break;
		        	case 2:
		        		viewLayoutParams.addRule(RelativeLayout.CENTER_VERTICAL);
		        		break;
		        	case 3:
		        		viewLayoutParams.addRule(RelativeLayout.ALIGN_PARENT_BOTTOM);
		        		break;
		        	default:
		        		viewLayoutParams.addRule(RelativeLayout.ALIGN_PARENT_BOTTOM);
		        		break;
		        		
	        }
		        adView = new AdView(UnityPlayer.currentActivity);
				adView.setListener(getAdViewListener());
		        adView.setLayoutParams(viewLayoutParams);
		        
		        layout.addView(adView);
			}
		});
	}
	
	public static void removeAdView() {
		UnityPlayer.currentActivity.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				if(adView != null) {
					adView.setListener(null);
					adView = null;
				}
				if(layout != null) {
					layout.removeAllViews();
				}
			}
		});
	}
	
	private static AdViewListener getAdViewListener() {
		return new AdViewListener() {
			
			@Override
			public void onTapAd() {
				UnityPlayer.UnitySendMessage("_TapForTap", "OnTapAd", "");
			}
			
			@Override
			public void onReceiveAd() {
				UnityPlayer.UnitySendMessage("_TapForTap", "OnReceiveAd", "");
				
			}
			
			@Override
			public void onFailToReceiveAd(String reason) {
				UnityPlayer.UnitySendMessage("_TapForTap", "OnFailToReceiveAd", reason);				
			}
		};
	}
	
	public static void prepareAppWall() {
		AppWall.prepare(UnityPlayer.currentActivity);
		setAppWallListener();
	}
	
	public static void showAppWall() {
		AppWall.show(UnityPlayer.currentActivity);
		setAppWallListener();
	}
	
	public static void prepareInterstitial() {
		Interstitial.prepare(UnityPlayer.currentActivity);
		setInterstitialListener();
	}
	
	public static void showInterstitial() {
		Interstitial.show(UnityPlayer.currentActivity);
		setInterstitialListener();
	}
	
	synchronized private static void setAppWallListener() {
		if(appWallListener == null ) {
			appWallListener = new AppWallListener() {
				@Override
				public void onDismiss() {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnAppWallDismissed", "");
				}
                
                @Override
				public void onFail(String reason) {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnAppWallFailed", reason);
				}
			};
			AppWall.setListener(appWallListener);
		}
	}
	
	synchronized private static void setInterstitialListener() {
		if(interstitialListener == null ) {
			interstitialListener = new InterstitialListener() {
				@Override
				public void onDismiss() {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnInterstitialDismissed", "");
				}
                @Override
				public void onFail(String reason) {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnInterstitialFailed", reason);
				}
			};
			Interstitial.setListener(interstitialListener);
		}
	}
}
