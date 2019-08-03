# VersionUpdateOnBuild
 Set PlayerSettings.bundleVersion OnPreprocessBuild

![](Assets/Packages/VersionUpdateOnBuild/Docs/VersionUpdateOnBuild.gif)


# Install
Download a `.unitypackage` file from [Release page](https://github.com/fuqunaga/VersionUpdateOnBuild/releases).

# Parameters
config VersionUpdateOnBuildParameter.asset at inspector.
- <b>ignoreDevelopmentBuild:</b> if true, VersionUpdateOnBuild won't run at development build.
- <b>format:</b> version strings.
magic word: "%[datetime_format]%" -> DateTime.Now.ToString([datetime_format]).
