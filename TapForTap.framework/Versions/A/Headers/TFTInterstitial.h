//
//  Copyright (c) 2013 Tap for Tap. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "TFTTypes.h"

@class TFTInterstitial;

@protocol TFTInterstitialDelegate <NSObject>
@optional
- (void)tftInterstitialDidReceiveAd:(TFTInterstitial *)interstitial;
- (void)tftInterstitial:(TFTInterstitial *)interstitial didFail:(NSString *)reason;
- (void)tftInterstitialDidShow:(TFTInterstitial *)interstitial;
- (void)tftInterstitialWasTapped:(TFTInterstitial *)interstitial;
- (void)tftInterstitialWasDismissed:(TFTInterstitial *)interstitial;
- (void)tftInterstitialWasRewarded:(TFTInterstitial *)interstitial;
@end

@protocol TFTInterstitialAdManager <NSObject>
@property (assign, nonatomic, readonly) BOOL readyToShow;
@property (readonly, nonatomic) NSMutableDictionary *params;

- (void)load;
- (void)showWithViewController:(UIViewController *) viewController;
- (void)showAndLoadNextWithViewController:(UIViewController *)viewController;

- (void)wrapperDidReceiveAd;
- (void)wrapperDidFailToReceiveAdWithReason:(NSString *)reason;
- (void)wrapperAdDidShow;
- (void)wrapperAdWasTapped;
- (void)wrapperAdWasDismissed;
- (void)wrapperAdWasRewarded;
@end

@protocol TFTProviderDelegate <NSObject>

- (void)tftProviderDidReceiveAd;
- (void)tftProviderDidFailToReceiveAdWithReason:(NSString *)reason;
- (void)tftProviderAdDidShow;
- (void)tftProviderAdWasTapped;
- (void)tftProviderAdWasDismissed;
- (void)tftProviderAdWasRewarded;

@end

@interface TFTInterstitial : NSObject <TFTInterstitialDelegate, TFTProviderDelegate>
+ (TFTInterstitial *)interstitial __attribute__((deprecated));
+ (TFTInterstitial *)interstitialWithDelegate:(id<TFTInterstitialDelegate>) delegate __attribute__((deprecated));

- (void)load __attribute__((deprecated));
- (BOOL)readyToShow;
- (void)showWithViewController:(UIViewController *)viewController;
- (void)showAndLoadWithViewController:(UIViewController *)viewController;

//Unity Support
@property (nonatomic, assign) TFTTypeInterstitialClientRef *interstitialClient;
@property (nonatomic, assign) TFTInterstitialDidReceiveCallback didReceiveAd;
@property (nonatomic, assign) TFTInterstitialDidFailCallback didFail;
@property (nonatomic, assign) TFTInterstitialDidShowCallback didShow;
@property (nonatomic, assign) TFTInterstitialWasTappedCallback wasTapped;
@property (nonatomic, assign) TFTInterstitialWasRewardedCallback wasRewarded;
//End Unity Support

// Use this for loading screens or waiting periods.  Example: waiting for the first level
+ (TFTInterstitial *)loadBreakInterstitialWithDelegate:(id<TFTInterstitialDelegate>)delegate;

+ (TFTInterstitial *)loadBreakInterstitialWithCallbackOnReceivedAd: (void (^)(TFTInterstitial *interstitial))receivedAdBlock
                                                       onAdDidFail: (void (^)(TFTInterstitial *interstitial, NSString *reason))failedAdBlock
                                                       onAdDidShow: (void (^)(TFTInterstitial *interstitial))shownAdBlock
                                                     onAdWasTapped: (void (^)(TFTInterstitial *interstitial))tappedAdBlock
                                                  onAdWasDismissed: (void (^)(TFTInterstitial *interstitial))dismissedAdBlock;

// Use this when the user needs to earn a way to continue.  Example: to earn a new life
+ (TFTInterstitial *)loadRescueInterstitialWithTitle: (NSString *)title
                                        brandingText: (NSString *)branding
                                      enticementText: (NSString *)enticement
                                   rewardDescription: (NSString *)rewardDescription
                                          rewardIcon: (NSURL *)iconURL
                                     optInButtonText: (NSString *)optInText
                                            delegate:(id<TFTInterstitialDelegate>)delegate;

+ (TFTInterstitial *)loadRescueInterstitialWithTitle: (NSString *)title
                                        brandingText: (NSString *)branding
                                      enticementText: (NSString *)enticement
                                   rewardDescription: (NSString *)rewardDescription
                                          rewardIcon: (NSURL *)iconURL
                                     optInButtonText: (NSString *)optInText
                                        onReceivedAd: (void (^)(TFTInterstitial *interstitial))receivedAdBlock
                                         onAdDidFail: (void (^)(TFTInterstitial *interstitial, NSString *reason))failedAdBlock
                                         onAdDidShow: (void (^)(TFTInterstitial *interstitial))shownAdBlock
                                       onAdWasTapped: (void (^)(TFTInterstitial *interstitial))tappedAdBlock
                                    onAdWasDismissed: (void (^)(TFTInterstitial *interstitial))dismissedAdBlock
                                     onAdWasRewarded: (void (^)(TFTInterstitial *interstitial))rewardedAdBlock;

// Use these after a goal has been accomplished.  Example: after a level is completed.
+ (TFTInterstitial *)loadAchievementInterstitialWithDescription: (NSString *)description
                                              rewardDescription: (NSString *)rewardDescription
                                                     rewardIcon: (NSURL *)iconURL
                                                       delegate:(id<TFTInterstitialDelegate>)delegate;

+ (TFTInterstitial *)loadAchievementInterstitialWithDescription: (NSString *)description
                                        rewardDescription: (NSString *)rewardDescription
                                               rewardIcon: (NSURL *)iconURL
                                             onReceivedAd: (void (^)(TFTInterstitial *interstitial))receivedAdBlock
                                              onAdDidFail: (void (^)(TFTInterstitial *interstitial, NSString *reason))failedAdBlock
                                              onAdDidShow: (void (^)(TFTInterstitial *interstitial))shownAdBlock
                                            onAdWasTapped: (void (^)(TFTInterstitial *interstitial))tappedAdBlock
                                         onAdWasDismissed: (void (^)(TFTInterstitial *interstitial))dismissedAdBlock;

@end
