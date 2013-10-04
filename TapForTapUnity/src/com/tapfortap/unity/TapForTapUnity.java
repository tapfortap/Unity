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

import com.tapfortap.Banner;
import com.tapfortap.Banner.BannerListener;
import com.tapfortap.AppWall;
import com.tapfortap.AppWall.AppWallListener;
import com.tapfortap.Interstitial;
import com.tapfortap.Interstitial.InterstitialListener;
import com.tapfortap.TapForTap;
import com.tapfortap.TapForTap.Gender;
import com.unity3d.player.UnityPlayer;

import android.util.Log;

public class TapForTapUnity {

	private static Banner banner;
	private static AppWall appWall;
	private static Interstitial interstitial;
	private static RelativeLayout layout;

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
        TapForTap.PLUGIN = "unity";
        TapForTap.PLUGIN_VERSION = "1.3.0";
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

				if (layout == null) {
					layout = new RelativeLayout(UnityPlayer.currentActivity);
					RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.MATCH_PARENT);
					UnityPlayer.currentActivity.addContentView(layout, layoutParams);
				}

		    	// Setup the banner
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
	        	removeAdView();
		        banner = Banner.create(UnityPlayer.currentActivity, getBannerListener());
		        banner.setLayoutParams(viewLayoutParams);

		        layout.addView(banner);
			}
		});
	}

	public static void removeAdView() {
		UnityPlayer.currentActivity.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				if(banner != null) {
					banner.setListener(null);
					banner = null;
				}
				if(layout != null) {
					layout.removeAllViews();
				}
			}
		});
	}

	private static BannerListener getBannerListener() {
		return new BannerListener() {

			@Override
			public void bannerOnReceive(Banner banner) {
				UnityPlayer.UnitySendMessage("_TapForTap", "OnReceiveAd", "");

			}

			@Override
			public void bannerOnFail(Banner banner, String reason, Throwable throwable) {
				UnityPlayer.UnitySendMessage("_TapForTap", "OnFailToReceiveAd", reason);
			}

			@Override
			public void bannerOnTap(Banner banner) {
				UnityPlayer.UnitySendMessage("_TapForTap", "OnTapAd", "");
			}
		};
	}

	public static void prepareAppWall() {
		getAppWall().load();
	}

	public static void showAppWall() {
		getAppWall().show();
	}

	private static synchronized AppWall getAppWall() {
		if (appWall == null) {
			appWall = AppWall.create(UnityPlayer.currentActivity, new AppWallListener() {
				@Override
				public void appWallOnReceive(AppWall appWall) {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnAppWallReceiveAd", "");
				}

				@Override
				public void appWallOnFail(AppWall appWall, String reason, Throwable throwable) {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnAppWallFailed", reason);
				}

				@Override
				public void appWallOnShow(AppWall appWall) {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnAppWallShow", "");
				}

				@Override
				public void appWallOnTap(AppWall appWall) {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnAppWallTap", "");
				}

				@Override
				public void appWallOnDismiss(AppWall appWall) {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnAppWallDismissed", "");
				}
			});
		}
		return appWall;
	}

	public static void prepareInterstitial() {
		getInterstitial().load();
	}

	public static void showInterstitial() {
		getInterstitial().show();
	}

	private static synchronized Interstitial getInterstitial() {
		if (interstitial == null) {
			interstitial = Interstitial.create(UnityPlayer.currentActivity, new InterstitialListener() {
				@Override
				public void interstitialOnReceive(Interstitial interstitial) {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnInterstitialReceiveAd", "");
				}

				@Override
				public void interstitialOnFail(Interstitial interstitial, String reason, Throwable throwable) {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnInterstitialFailed", reason);
				}

				@Override
				public void interstitialOnShow(Interstitial interstitial) {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnInterstitialShow", "");
				}

				@Override
				public void interstitialOnTap(Interstitial interstitial) {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnInterstitialTap", "");
				}

				@Override
				public void interstitialOnDismiss(Interstitial interstitial) {
					UnityPlayer.UnitySendMessage("_TapForTap", "OnInterstitialDismissed", "");
				}
			});
		}
		return interstitial;
	}
}
