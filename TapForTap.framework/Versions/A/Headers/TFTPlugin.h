//
//  TFTPlugin.h
//  TapForTap
//
//  Created by Leon Müller on 2015-08-26.
//  Copyright (c) 2015 Tap for Tap. All rights reserved.
//

#ifndef TapForTap_TFTPlugin_h
#define TapForTap_TFTPlugin_h

@protocol TFTPlugin <NSObject>
@required
- (void)initialize;
- (NSString *) getPluginName;
- (NSString *) getVersion;

@end

#endif
