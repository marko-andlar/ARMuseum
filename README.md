# ARMuseum
Simple AR Museum app.

# Editor Set Up
Add Vuforia 10.13 to the project and you are good to go (https://developer.vuforia.com/downloads/SDK).

# Before building
Click on Window -> Asset Management -> Addressables -> Groups. Then Build -> New Build -> Default Build Script.
This fixes Addressables MissingMethodException.

# Implemented Features
* Splash screen logo
* Screen safe area
* Main scene with main menu
* AR scene with image tracking
* Bird info canvas
* Screen transition
* Android support
* Addressables (for loading bird model prefabs)

# Missing features
* Design
* Dynamic bird info content
* Internationalization
* Quiz with random questions and score

# Known issues
* Safe area not working when app rotation is set to landscape (auto rotation enabled until it is fixed)

# Builds
* Android (.apk): https://easyupload.io/pvp4hw
