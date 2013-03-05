/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

#import "TapForTap.h"

extern UIViewController* UnityGetGLViewController();

UIViewController* applicationViewController = nil;
UIView* applicationView = nil;

@interface TapForTapUnityAdViewDelegate : NSObject <TapForTapAdViewDelegate>
@end

@implementation TapForTapUnityAdViewDelegate

- (UIViewController *) rootViewController {
    return applicationViewController;
}

- (void) tapForTapAdViewWasTapped: (TapForTapAdView *)adView {
    UnitySendMessage("_TapForTap", "OnTapAd", "");
}

- (void) tapForTapAdViewDidReceiveAd: (TapForTapAdView *)adView {
    UnitySendMessage("_TapForTap", "OnReceiveAd", "");
}

- (void) tapForTapAdView: (TapForTapAdView *)adView didFailToReceiveAd: (NSString *)reason {
    UnitySendMessage("_TapForTap", "OnFailToReceiveAd", [reason cStringUsingEncoding:NSUTF8StringEncoding]);
}

@end

@interface TapForTapUnityAppWallDelegate : NSObject <TapForTapAppWallDelegate>
@end

@implementation TapForTapUnityAppWallDelegate

- (void) tapForTapAppWallWasDismissed {
    UnitySendMessage("_TapForTap", "OnAppWallDismissed", "");
}

- (void) tapForTapAppWallFailedToDownload: (NSString *) reason {
    UnitySendMessage("_TapForTap", "OnAppWallFailed", [reason cStringUsingEncoding:NSUTF8StringEncoding]);
}

@end

@interface TapForTapUnityInterstitialDelegate : NSObject <TapForTapInterstitialDelegate>
@end

@implementation TapForTapUnityInterstitialDelegate

- (void) tapForTapInterstitialWasDismissed {
    UnitySendMessage("_TapForTap", "OnInterstitialDismissed", "");
}

- (void) tapForTapInterstitialFailedToDownload: (NSString *) reason {
    UnitySendMessage("_TapForTap", "OnInterstitialFailed", [reason cStringUsingEncoding:NSUTF8StringEncoding]);
}

@end

TapForTapAdView* adView = nil;
TapForTapUnityAdViewDelegate* adViewDelegate = nil;
TapForTapUnityAppWallDelegate* appWallDelegate = nil;
TapForTapUnityInterstitialDelegate* interstitialDelegate = nil;


extern "C" void initializeWithApiKey(char* apiKeyArray) {
    
    applicationView = UnityGetGLViewController().view;
    applicationViewController = UnityGetGLViewController();
    
    NSString* apiKey = [NSString stringWithUTF8String:apiKeyArray];
    
    [TapForTap performSelector: @selector(_setPlugin:) withObject: @"unity"];
    [TapForTap performSelector: @selector(_setPluginVersion:) withObject: @"1.2.0"];
    
    [TapForTap initializeWithAPIKey:apiKey];
}

extern "C" void setYearOfBirth(uint32_t yearOfBirth) {
    [TapForTap setYearOfBirth:yearOfBirth];
}

extern "C" void setGender(uint32_t gender) {
    if (gender == 0)
    {
        [TapForTap setGender:MALE];
    } else if(gender == 1)
    {
        [TapForTap setGender:FEMALE];
    } else
    {
        [TapForTap setGender:NONE];
    }
}

extern "C" void setLocation(double_t latitudeDouble, double_t longitudeDouble) {
    CLLocationDegrees latitude = latitudeDouble;
    CLLocationDegrees longitude = longitudeDouble;
    
    CLLocation *location = [[CLLocation alloc] initWithLatitude:latitude longitude:longitude];
    
    [TapForTap setLocation:location];
    
    [location release];
}

extern "C" void setUserAccountId(char* userAccountIdArray) {
    NSString* userAcountId = [NSString stringWithUTF8String:userAccountIdArray];
    [TapForTap setUserAccountID:userAcountId];
}

extern "C" void setMode(char* modeArray) {
    NSString* mode = [NSString stringWithUTF8String:modeArray];
    if ([mode isEqualToString:@"development"])
    {
        [TapForTap performSelector: @selector(_setEnvironment:) withObject: @"development"];
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
    
    adView = [[TapForTapAdView alloc] initWithFrame:CGRectMake(xCoordinate, yCoordinate, width, height)];
    adViewDelegate = [[TapForTapUnityAdViewDelegate alloc] init];
    [adView setDelegate:adViewDelegate];
    [applicationView addSubview: adView];
}


extern "C" void removeAdView() {
    [adView stopLoadingAds];
    [adView removeFromSuperview];
    [adView release];
    [adViewDelegate release];
    adViewDelegate = nil;
    adView = nil;
}

extern "C" void createAdView(uint32_t horiztonalAligment, uint32_t verticalAlignment) {
    removeAdView();
    showAd(horiztonalAligment, verticalAlignment);
}

void setInterstitialDelegate(void) {
    if(interstitialDelegate == nil) {
        interstitialDelegate = [[TapForTapUnityInterstitialDelegate alloc] init];
        [TapForTapInterstitial setDelegate: interstitialDelegate];
    }
}

extern "C" void prepareInterstitial(void) {
    [TapForTapInterstitial prepare];
    setInterstitialDelegate();
}

extern "C" void showInterstitial(void) {
    UIViewController *applicationViewController = applicationViewController = [[[UIApplication sharedApplication] keyWindow] rootViewController];
    [TapForTapInterstitial showWithRootViewController:applicationViewController];
    setInterstitialDelegate();
}

void setAppWallDelegate(void) {
    if(appWallDelegate == nil) {
        appWallDelegate = [[TapForTapUnityAppWallDelegate alloc] init];
        [TapForTapAppWall setDelegate: appWallDelegate];
    }
}

extern "C" void prepareAppWall(void) {
    [TapForTapAppWall prepare];
    setAppWallDelegate();
}


extern "C" void showAppWall(void) {
    UIViewController *applicationViewController = applicationViewController = [[[UIApplication sharedApplication] keyWindow] rootViewController];
    [TapForTapAppWall showWithRootViewController:applicationViewController];
    setAppWallDelegate();
}

extern "C" void dipose() {
    removeAdView();
}
