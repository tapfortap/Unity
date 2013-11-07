#!/bin/sh

set -x

VERSION="1.3.1"
UNITY_BIN="$UNITY_SDK/Unity.app/Contents/MacOS"

cd "$(dirname $0)"

ANDROID_FILE=TapForTapUnity/src/com/tapfortap/unity/TapForTapUnity.java
IOS_FILE=test-app/Assets/Plugins/iOS/TapForTapGloo.mm

# Update the Plugin Version numbers in the native files
sed -i '' "s/.*TapForTap.PLUGIN_VERSION.*/        TapForTap.PLUGIN_VERSION = \"$VERSION\";/" $ANDROID_FILE
sed -i '' "s/.*TFTTapForTap performSelector: @selector(setPluginVersion:).*/    [TFTTapForTap performSelector: @selector(setPluginVersion:) withObject: @\"$VERSION\"];/" $IOS_FILE

cd "$(dirname $0)"
ROOT_PATH=`pwd`
EXPORT_PATH="$ROOT_PATH"/release
ASSET_PATH=Assets/Plugins
PROJECT_PATH="$ROOT_PATH"/test-app

rm -rf release
mkdir release

TapForTapUnity/release.sh
cp TapForTapUnity/release/* test-app/Assets/Plugins/Android
"$UNITY_BIN"/Unity -batchmode -quit \
-logFile export.log \
-projectPath "$PROJECT_PATH" \
-exportPackage "$ASSET_PATH" "$EXPORT_PATH"/TapForTap-Unity-"$VERSION".unitypackage
