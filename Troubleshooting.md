# Troubleshooting Common Problems Getting Started

## Launching Android Emulator freezes your Mac with OS X 10.9 (Mavericks)

Running Android Emulators in with an x86 CPU/ABI setting can make them dramatically more responsive. To get support for this architecture, you will need the [Intel HAXM driver for your platform](http://software.intel.com/en-us/articles/intel-hardware-accelerated-execution-manager/).

Unfortunately, there was an issue with an older release of HAXM and OS X 10.9 (Mavericks). When you launched an x86 Android device, you could experience a full system freeze/crash, requiring a hard reset. If you are experiencing this issue, Intel has released a hotfix for the Hardware Accelerated Execution Manager that resolves it.

[http://software.intel.com/en-us/articles/intel-hardware-accelerated-execution-manager/](http://software.intel.com/en-us/articles/intel-hardware-accelerated-execution-manager/)

## Application crashes immediately after deploying to Android Emulator.

If you have multiple Android SDK versions installed, there is a rare chance that apps can be built in a way that will crash immediately after you start them. This appears to be related to deploying to an emulator running an SDK version older than the lastest you have installed. If you encounter this error, as a quick fix, you can simply tell it to not use the latest SDK version to build.

To do this in Xamarin Studio, right-click your Android project and choose Tools->Edit File. This will open the file to see the raw XML.

In Visual Studio, right-click your Android project and choose Unload Project. After it is unloaded, you can right-click and choose "Edit YourProject.csproj" to see the raw XML.

Once you are editing the project XML, find the `AndroidUseLatestPlatformSdk` property and set it to `False` to fix the issue.

    <AndroidUseLatestPlatformSdk>False</AndroidUseLatestPlatformSdk>

Save the changes to your project file. Xamarin Studio will automatically load the changes. In Visual Studio, right-click the unloaded project and choose "Reload Project".
