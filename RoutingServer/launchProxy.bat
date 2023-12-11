@Echo off
set "currentDir=%cd%"
cd /d "%currentDir%\RoutingServer\bin\Debug\"
powershell Start-Process -FilePath "RoutingServer.exe" -Verb runAs
pause