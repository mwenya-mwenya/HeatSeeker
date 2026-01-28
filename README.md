# HeatSeeker

A cross‑platform .NET MAUI game built for Windows, Android, and more.
HeatSeeker is a lightweight, fast‑loading mobile/desktop game built with .NET MAUI. It’s designed to run across multiple platforms using a single shared codebase, with platform‑specific enhancements where needed. The project uses MAUI Shell for navigation, XAML for UI, and C# for game logic.

🧱 Project Structure
<pre>``` 
HeatSeeker
 |-bin
 |-obj
 |-Platforms
 |-Properties
 |-Resources
 |-App.xaml
 |-App.xaml.cs
 |-AppShell.xaml
 |-AppShell.xaml.cs
 |-GlobalXmlns.cs
 |-HeatSeeker.csproj
 |-HeatSeeker.csproj.user
 |-HeatSeeker.sln
 |-MainPage.xaml
 |-MainPage.xaml.cs
 |-MauiProgram.cs
 |- |-Debug
 |- |- |-net9.0-android
 |- |- |-net9.0-ios
 |- |- |-net9.0-maccatalyst
 |- |- |-net9.0-windows10.0.19041.0
 |- |-Debug
 |- |-HeatSeeker.csproj.nuget.dgspec.json
 |- |-HeatSeeker.csproj.nuget.g.props
 |- |-HeatSeeker.csproj.nuget.g.targets
 |- |-project.assets.json
 |- |-project.nuget.cache
 |- |- |-net9.0-android
 |- |- |-net9.0-ios
 |- |- |-net9.0-maccatalyst
 |- |- |-net9.0-windows10.0.19041.0
 |- |-Android
 |- |-iOS
 |- |-MacCatalyst
 |- |-Tizen
 |- |-Windows
 |- |- |-Resources
 |- |- |-AndroidManifest.xml
 |- |- |-MainActivity.cs
 |- |- |-MainApplication.cs
 |- |- |-Resources
 |- |- |-AppDelegate.cs
 |- |- |-Info.plist
 |- |- |-Program.cs
 |- |- |-AppDelegate.cs
 |- |- |-Entitlements.plist
 |- |- |-Info.plist
 |- |- |-Program.cs
 |- |- |-Main.cs
 |- |- |-tizen-manifest.xml
 |- |- |-app.manifest
 |- |- |-App.xaml
 |- |- |-App.xaml.cs
 |- |- |-Package.appxmanifest
 |- |-launchSettings.json
 |- |-AppIcon
 |- |-Fonts
 |- |-Images
 |- |-Raw
 |- |-Splash
 |- |-Styles
 |- |- |-appicon.svg
 |- |- |-appiconfg.svg
 |- |- |-OpenSans-Regular.ttf
 |- |- |-OpenSans-Semibold.ttf
 |- |- |-dotnet_bot.png
 |- |- |-AboutAssets.txt
 |- |- |-splash.svg
 |- |- |-Colors.xaml
 |- |- |-Styles.xaml
.gitattributes
.gitignore
HeatSeeker.sln
README.md
  ```</pre>

⚙️ Requirements
- .NET 9 SDK (or the version your project targets)
- Visual Studio 2022 with:
- .NET MAUI workload
- Android SDKs
- Windows App SDK
- Windows 11 for WinUI builds

🚀 Running the Project
Windows
Select the Windows Machine target in Visual Studio and press Run.
Android
- Start an Android emulator
- Select Android Emulator as the target
- Run the project
MacCatalyst / iOS
Requires macOS + Xcode.

🧩 Future Enhancements
- Additional game screens
- Sound effects and animations
- Cross‑platform save system
- Improved UI styling and themes

