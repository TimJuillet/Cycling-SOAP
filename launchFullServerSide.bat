@Echo off
set "currentDir=%cd%"
cd /d "%currentDir%\RoutingServer"
start "" launchProxy.bat
start "" launchServ.bat