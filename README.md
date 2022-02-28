# LocalAdminSharp
.NET executable to use when dealing with privilege escalation on Windows to gain local administrator access. This simple tool creates a new user adds it to the local administrator group; if the user exists it will just be added to the admin group.
You can also edit the code to add a domain user to the local administrator group editing the variable `domain`.

## Build
Open the solution in Visual Studio (tested only on Visual Studio 2019 Community Edition) and compile the EXE for the desired architecture (x86, x64); in the Release mode the PBD file is removed.

## Customize
To create custom user just edit the file `Program.cs` with the desired username, password, group and domain.

## Usage
* Standalone: `.\LocalAdminSharp.exe`
* Chain: use the EXE to be executed from another script/tool (i.e. for privescs)

## Analysis

The PBD file is removed when compiling in Release mode and Windows Defender does not detect it as malicious (yet). Obfuscation should be used after the compilation to avoid easy RE using, for example, dnSpy.
