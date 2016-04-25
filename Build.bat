Del *.nupkg
Del Bin\*DropboxExplorer*.*
Timeout 1
"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" /t:rebuild "DropBoxExplorer.sln" /property:Configuration=Release;Platform="Any CPU"
Timeout 1
Nuget.exe pack DropBoxExplorer\DropboxExplorer.csproj
