"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe" ../Shearnie.Net.sln /rebuild Release

..\.nuget\nuget pack Shearnie.Net.csproj -IncludeReferencedProjects -Prop Configuration=Release
..\.nuget\nuget push Shearnie.Net.1.8.nupkg

pause
