typedef const void* TFTTypeRef;
typedef const void* TFTTypeBannerClientRef;
typedef const void* TFTTypeInterstitialClientRef;
typedef const void* TFTTypeBannerRef;
typedef const void* TFTTypeInterstitialRef;

//Banner
typedef void (*TFTBannerDidReceiveAdCallback)(TFTTypeBannerClientRef bannerClient);
typedef void (*TFTBannerDidFailCallback)(TFTTypeBannerClientRef bannerClient, const char *error);
typedef void (*TFTBannerWasTappedCallback)(TFTTypeBannerClientRef bannerClient);

//Interstitial
typedef void (*TFTInterstitialDidReceiveCallback)(TFTTypeInterstitialClientRef *interstitialClient);
typedef void (*TFTInterstitialDidFailCallback)(TFTTypeInterstitialClientRef *interstitialClient, const char *error);
typedef void (*TFTInterstitialDidShowCallback)(TFTTypeInterstitialClientRef *interstitialClient);
typedef void (*TFTInterstitialWasTappedCallback)(TFTTypeInterstitialClientRef *interstitialClient);
typedef void (*TFTInterstitialWasRewardedCallback)(TFTTypeInterstitialClientRef *interstitialClient);
typedef void (*TFTInterstitialWasDismissedCallback)(TFTTypeInterstitialClientRef *interstitialClient);