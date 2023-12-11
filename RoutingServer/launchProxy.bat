@Echo off
set "currentDir=%cd%"
cd /d "%currentDir%\RoutingServer\bin\Release\"
powershell Start-Process -FilePath "RoutingServer.exe" -Verb runAs
pause