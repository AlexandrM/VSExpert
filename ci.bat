md ASE.Expert.VS.Setup
copy ASE.Expert.VS.Setup.2012\bin\Release\*.dll ASE.Expert.VS.Setup\*.*
copy ASE.Expert.VS.Setup.2012\bin\Release\*.AddIn ASE.Expert.VS.Setup\*.*
copy ASE.Expert.VS.Setup.2012\bin\Release\ASE.Expert.VS.Setup.2012.exe ASE.Expert.VS.Setup\*.*

"d:\Program Files\7-Zip\7z.exe" a ASE.Expert.VS.7z ASE.Expert.VS.Setup

copy /b 7zsd.sfx+config.txt+ASE.Expert.VS.7z ASE.Expert.VS.SETUP.exe

del ASE.Expert.VS.7z
del ASE.Expert.VS.Setup\*.* /Q
rd ASE.Expert.VS.Setup

ASE.Expert.VS.SETUP.exe