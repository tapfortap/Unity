#!/bin/sh

VERSION="1.2.0"
UNITY_BIN="/Applications/Unity/Unity.app/Contents/MacOS"

cd "$(dirname $0)"

ANDROID_FILE=TapForTapUnity/src/com/tapfortap/unity/TapForTapUnity.java
IOS_FILE=test-app/Assets/Plugins/iOS/TapForTapGloo.mm

# Update the Plugin Version numbers in the native files
sed -i '' "s/.*TapForTap.pluginVersion.*/        TapForTap.pluginVersion = \"$VERSION\";/" $ANDROID_FILE
sed -i '' "s/.*TapForTap performSelector: @selector(_setPluginVersion:).*/    [TapForTap performSelector: @selector(_setPluginVersion:) withObject: @\"$VERSION\"];/" $IOS_FILE

cd "$(dirname $0)"
ROOT_PATH=`pwd`
EXPORT_PATH="$ROOT_PATH"/release
ASSET_PATH=Assets/Plugins
PROJECT_PATH="$ROOT_PATH"/test-app

rm -rf release
mkdir release

if [ -f update_native_libraries ];
then
	./update_native_libraries
fi

TapForTapUnity/release.sh
cp TapForTapUnity/release/* test-app/Assets/Plugins/Android
"$UNITY_BIN"/Unity -batchmode -quit \
-logFile export.log \
-projectPath "$PROJECT_PATH" \
-exportPackage "$ASSET_PATH" "$EXPORT_PATH"/TapForTap-Unity-"$VERSION".unitypackage
cd release
zip TapForTap-Unity-$VERSION.zip ./*
rm -rf *.unitypackage
