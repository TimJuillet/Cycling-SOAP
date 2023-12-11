@Echo off
set "currentDir=%cd%"
cd /d "%currentDir%\ProxyCacheSwagg\bin\Release\"
powershell Start-Process -FilePath "ProxyCacheSwagg.exe" -Verb runAs
pause