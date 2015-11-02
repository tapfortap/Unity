//
//  Copyright (c) 2013 Tap for Tap. All rights reserved.
//

#import <Foundation/Foundation.h>

#define TFTDebugLog(s, ...) do { \
                                if ([TFTLog debug]) {\
                                    NSLog(@"Debug: <%@:%@:%d> %@", NSStringFromClass([self class]), NSStringFromSelector(_cmd), __LINE__, [NSString stringWithFormat:(s), ##__VA_ARGS__]); \
                                } \
                            } while(0)

#define TFTWarningLog(s, ...) do { \
                                  if ([TFTLog warning]) {\
                                      NSLog(@"Warning: <%@:%@:%d> %@", NSStringFromClass([self class]), NSStringFromSelector(_cmd), __LINE__, [NSString stringWithFormat:(s), ##__VA_ARGS__]); \
                                  } \
                              } while(0)

#define TFTErrorLog(s, ...) do { \
                                if ([TFTLog error]) {\
                                    NSLog(@"Error <%@:%@:%d> %@", NSStringFromClass([self class]), NSStringFromSelector(_cmd), __LINE__, [NSString stringWithFormat:(s), ##__VA_ARGS__]); \
                                } \
                            } while(0)

@interface TFTLog : NSObject
+ (BOOL)debug;
+ (BOOL)warning;
+ (BOOL)error;
@end
