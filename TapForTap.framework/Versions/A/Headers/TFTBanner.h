//
//  Copyright (c) 2013 Tap for Tap. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "TFTTypes.h"

@class TFTBanner;

@protocol TFTBannerDelegate <NSObject>
@optional
- (void)tftBannerDidReceiveAd:(TFTBanner *)banner;
- (void)tftBanner:(TFTBanner *)banner didFail:(NSString *)reason;
- (void)tftBannerWasTapped:(TFTBanner *)banner;
@end

@interface TFTBanner : UIView
@property (nonatomic, weak) id<TFTBannerDelegate> delegate;
@property (nonatomic, assign) BOOL autoRollover;
@property (nonatomic, assign) BOOL forceLoad;

//Unity Support
@property (nonatomic, assign) TFTTypeBannerClientRef *bannerClient;
@property(nonatomic, assign) TFTBannerDidReceiveAdCallback didReceiveAd;
@property(nonatomic, assign) TFTBannerDidFailCallback didFail;
@property(nonatomic, assign) TFTBannerWasTappedCallback wasTapped;
//End Unity Support

+ (TFTBanner *)bannerWithFrame:(CGRect)frame delegate:(id<TFTBannerDelegate>)delegate;
+ (TFTBanner *)bannerWithFrame:(CGRect)frame;

- (id)initWithFrame:(CGRect)frame delegate:(id<TFTBannerDelegate>)delegate;
- (void) startShowingAds;
- (void) stopShowingAds;
- (void) resumeShowingAds;
- (void) showBanner;
- (void) hideBanner;
- (void) showNewAd;

@end
