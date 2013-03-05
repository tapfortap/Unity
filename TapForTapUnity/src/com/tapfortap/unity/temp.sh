#!/bin/sh

set -x

VERSION=1.4.0

sed -i '' "s/.*TapForTap.pluginVersion.*/        TapForTap.pluginVersion = \"$VERSION\"/" TapForTapUnity.java