//
//  TFTAdProvider.h
//  TapForTap
//
//  Created by Bob Warwick on 2015-02-17.
//  Copyright (c) 2015 Tap for Tap. All rights reserved.
//

#import "TFTPlugin.h"
#import "TFTInterstitial.h"

#ifndef TapForTap_TFTAdProvider_h
#define TapForTap_TFTAdProvider_h

@protocol TFTAdProvider <TFTPlugin> 
@required
@property (retain) id<TFTInterstitialAdManager> delegate;
@property (retain) NSDictionary *params;

- (BOOL)load;
- (void)showWithViewController:(UIViewController *) viewController;
- (void)showAndLoadNextWithViewController:(UIViewController *)viewController;
- (BOOL) isReadyToShow;

@end

#endif
