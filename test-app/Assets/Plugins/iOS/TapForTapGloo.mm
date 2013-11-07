/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

#import "TFTTapForTap.h"

extern UIViewController* UnityGetGLViewController();

UIViewController* applicationViewController = nil;
UIView* applicationView = nil;

@interface TFTUnityBannerDelegate : NSObject <TFTBannerDelegate>
@end

@implementation TFTUnityBannerDelegate

- (void) tftBannerDidReceiveAd:(TFTBanner *)banner {
    UnitySendMessage("_TapForTap", "OnReceiveAd", "");
}

- (void) tftBanner:(TFTBanner *)banner didFail:(NSString *)reason {
    UnitySendMessage("_TapForTap", "OnFailToReceiveAd", [reason cStringUsingEncoding:NSUTF8StringEncoding]);
}

- (void) tftBannerWasTapped:(TFTBanner *)banner {
    UnitySendMessage("_TapForTap", "OnTapAd", "");
}

@end

@interface TFTUnityAppWallDelegate : NSObject <TFTAppWallDelegate>
@end

@implementation TFTUnityAppWallDelegate

- (void)tftAppWallDidReceiveAd:(TFTAppWall *)interstitial {
    UnitySendMessage("_TapForTap", "OnAppWallReceiveAd", "");
}

- (void) tftAppWall:(TFTAppWall *)appWall didFail:(NSString *)reason {
    UnitySendMessage("_TapForTap", "OnAppWallFailed", [reason cStringUsingEncoding:NSUTF8StringEncoding]);
}

- (void)tftAppWallDidShow:(TFTAppWall *)appWall {
    UnitySendMessage("_TapForTap", "OnAppWallShow", "");
}

- (void)tftAppWallWasTapped:(TFTAppWall *)appWall {
    UnitySendMessage("_TapForTap", "OnAppWallTap", "");
}

- (void) tftAppWallWasDismissed:(TFTAppWall *)appWall {
    UnitySendMessage("_TapForTap", "OnAppWallDismissed", "");
}

@end

@interface TFTUnityInterstitialDelegate : NSObject <TFTInterstitialDelegate>
@end

@implementation TFTUnityInterstitialDelegate

- (void)tftInterstitialDidReceiveAd:(TFTInterstitial *)interstitial {
    UnitySendMessage("_TapForTap", "OnInterstitialReceiveAd", "");
}

- (void) tftInterstitial:(TFTInterstitial *)interstitial didFail:(NSString *)reason {
    UnitySendMessage("_TapForTap", "OnInterstitialFailed", [reason cStringUsingEncoding:NSUTF8StringEncoding]);
}

- (void)tftInterstitialDidShow:(TFTInterstitial *)interstitial {
    UnitySendMessage("_TapForTap", "OnInterstitialShow", "");
}

- (void)tftInterstitialWasTapped:(TFTInterstitial *)interstitial {
    UnitySendMessage("_TapForTap", "OnInterstitialTap", "");
}

- (void) tftInterstitialWasDismissed:(TFTInterstitial *)interstitial {
    UnitySendMessage("_TapForTap", "OnInterstitialDismissed", "");
}

@end

TFTBanner *banner = nil;
TFTInterstitial *interstitial = nil;
TFTAppWall *appWall = nil;

extern "C" void initializeWithApiKey(char* apiKeyArray) {

    applicationView = UnityGetGLViewController().view;
    applicationViewController = UnityGetGLViewController();

    NSString* apiKey = [NSString stringWithUTF8String:apiKeyArray];

    [TFTTapForTap performSelector: @selector(setPlugin:) withObject: @"unity"];
    [TFTTapForTap performSelector: @selector(setPluginVersion:) withObject: @"1.3.1"];

    [TFTTapForTap initializeWithAPIKey:apiKey];
}

extern "C" void setYearOfBirth(uint32_t yearOfBirth) {
    [TFTTapForTap setYearOfBirth:yearOfBirth];
}

extern "C" void setGender(uint32_t gender) {
    if (gender == 0)
    {
        [TFTTapForTap setGender:MALE];
    } else if(gender == 1)
    {
        [TFTTapForTap setGender:FEMALE];
    } else
    {
        [TFTTapForTap setGender:NONE];
    }
}

extern "C" void setLocation(double_t latitudeDouble, double_t longitudeDouble) {
    CLLocationDegrees latitude = latitudeDouble;
    CLLocationDegrees longitude = longitudeDouble;

    CLLocation *location = [[CLLocation alloc] initWithLatitude:latitude longitude:longitude];

    [TFTTapForTap setLocation:location];

    [location release];
}

extern "C" void setUserAccountId(char* userAccountIdArray) {
    NSString* userAcountId = [NSString stringWithUTF8String:userAccountIdArray];
    [TFTTapForTap setUserAccountId:userAcountId];
}

extern "C" void setMode(char* modeArray) {
    NSString* mode = [NSString stringWithUTF8String:modeArray];
    if ([mode isEqualToString:@"development"])
    {
        [TFTTapForTap performSelector: @selector(setEnvironment:) withObject: @"development"];
    }

}

void showAd(uint32_t horiztonalAligment, uint32_t verticalAlignment) {

    CGRect rect = [applicationView bounds];
    float viewHeight = rect.size.height;
    float viewWidth = rect.size.width;

    uint32_t width = 320;
    uint32_t height = 50;

    uint32_t xCoordinate = 0;
    uint32_t yCoordinate = 0;

    switch (horiztonalAligment) {
        case 1:
            xCoordinate = 0;
            break;
        case 2:
            xCoordinate = (viewWidth - width) / 2;
            break;
        case 3:
            xCoordinate = (viewWidth - width);
            break;
        default:
            xCoordinate = (viewWidth - width) / 2;
            break;
    }

    switch (verticalAlignment) {
        case 1:
            yCoordinate = 0;
            break;
        case 2:
            yCoordinate = (viewHeight - height) / 2;
            break;
        case 3:
            yCoordinate = (viewHeight - height);
            break;
        default:
            yCoordinate = (viewHeight - height);
            break;
    }

    banner = [[TFTBanner bannerWithFrame:CGRectMake(xCoordinate, yCoordinate, width, height) delegate:[[TFTUnityBannerDelegate alloc] init]] retain];
    [applicationView addSubview: banner];
}


extern "C" void removeAdView() {
    [banner stopShowingAds];
    [banner removeFromSuperview];
    banner.delegate = nil;
    [banner release];
    banner = nil;
}

extern "C" void createAdView(uint32_t horiztonalAligment, uint32_t verticalAlignment) {
    removeAdView();
    showAd(horiztonalAligment, verticalAlignment);
}

TFTInterstitial* getInterstitial() {
    if (interstitial == nil) {
        interstitial = [[TFTInterstitial interstitialWithDelegate:[[TFTUnityInterstitialDelegate alloc] init]] retain];
    }
    return interstitial;
}

extern "C" void prepareInterstitial(void) {
    [getInterstitial() load];
}

extern "C" void showInterstitial(void) {
    UIViewController *vc = [[[UIApplication sharedApplication] keyWindow] rootViewController];
    [getInterstitial() showWithViewController:vc];
}

TFTAppWall* getAppWall() {
    if (appWall == nil) {
        appWall = [[TFTAppWall appWallWithDelegate:[[TFTUnityAppWallDelegate alloc] init]] retain];
    }
    return appWall;
}

extern "C" void prepareAppWall(void) {
    [getAppWall() load];
}


extern "C" void showAppWall(void) {
    UIViewController *vc = [[[UIApplication sharedApplication] keyWindow] rootViewController];
    [getAppWall() showWithViewController:vc];
}

extern "C" void dipose() {
    removeAdView();
    [interstitial release];
    [appWall release];
    interstitial = nil;
    appWall = nil;
}
