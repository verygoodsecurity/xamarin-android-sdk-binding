[![license](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/verygoodsecurity/vgs-collect-android/blob/master/LICENSE)

# VGS Xamarin Android Binding library
Binding library for VGS Collect Android SDK


> **_NOTE:_**  VGS does not support Xamarin. This demo is just an example of how VGS Collect SDK can be integrated into your application.


## Content
* <b>VGSCollectBindingLibrary</b> - Android Binding Library
* <b>AndroidSample</b> - Sample of the Xamarin Android project with VGS collect library integrated

## Dependencies
### VGSCollectBindingLibrary
* Xamarin.Kotlin.StdLib 1.3.50.1
* Xamarin.AndroidX.AppCompat 1.1.0
* Square.OkHttp3 4.2.2
* Xamarin.Kotlin.StdLib.Jdk8 1.3.50.1

### AndroidSample
* Xamarin.Android.Support.Design 28.0.0.3
* Xamarin.AndroidX.AppCompat 1.1.0
* Xamarin.AndroidX.Legacy.Support.Core.UI 1.0.0
* Xamarin.AndroidX.Lifecycle.LiveData 2.2.0
* Xamarin.Google.Android.Material 1.1.0-rc3
* Xamarin.Kotlin.StdLib 1.3.50.1
* Xamarin.Android.Support.Annotations 28.0.0.3
* Square.OkHttp3 4.2.2
* Xamarin.Kotlin.StdLib.Jdk8 1.3.50.1

## How to build Android Sample
1. Open Visual Studio
2. Choose configuration
3. Run build
4. It may be needed to install required Android SDK

Compiled library Build also available under <b>{Project_root}/dll</b> folder

## How to integrate compiled library
1. In the target Xamarin Android project right click on References
2. Add Reference
3. Switch to .Net Assembly tab
4. Choose compiled dll from the file system

## License
VGSCollect Android SDK is released under the MIT license. [See LICENSE](https://github.com/verygoodsecurity/vgs-collect-android/blob/master/LICENSE) for details.
