# nuget-references-problem

I'm not sure what exactly the expected behaviour is. However, based on this [.NET Core 2 example](https://docs.microsoft.com/en-us/dotnet/core/tutorials/consuming-library-with-visual-studio?tabs=csharp), I'm assuming that it works for "the normal" .NET as well.

In general the problem is that the required assemblies from NuGet packages referenced by the class Library `LibWithRef` are not copied into the output folder of the console application `NuGetRefTest`.

According to this [article by Scott Hanselman](https://www.hanselman.com/blog/ReferencingNETStandardAssembliesFromBothNETCoreAndNETFramework.aspx), as well as issues on GitHub (like microsoft/msbuild#1582), there are problems when combining .NET Standard and .NET Framework. However, in this example the class library as well as console application both target .NET Framework 4.6.1.

## Reproduce Error by

Clone this repository, build the solution and run it. I do get an `TypeInitializationException` with an inner exception of type `DllNotFoundException`.

Comparing the output folder of the console application `NuGetRefTest` with the class library output folder `LibWithRef` shows that some assemblies are missing while others are available.

Available:

 - Emgu.CV.UI.dll
 - Emgu.CV.World.dll
 - ZedGraph.dll
 
Missing:
 
 - Emgu.CV.UI.GL.dll
 - OpenTK.dll
 - OpenTK.GLControl.dll
 - x64/cvextern.dll
 - x64/opencv_ffmpeg310_64.dll
 - x86/cvextern.dll
 - x86/opencv_ffmpeg310.dll
 
## Workarounds

 1. Add NuGet package to console application (while keeping it in class library as well). - This works and solves the problem, but is not what I expect to see.
 2. Add `<RestoreProjectStyle>PackageReference</RestoreProjectStyle>` to the console application's csproj file. - Rebuilding and running it shows the same error.
 
