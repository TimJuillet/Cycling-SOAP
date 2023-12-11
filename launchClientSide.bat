@Echo off
set "currentDir=%cd%"
cd /d "%currentDir%\JavaClient"
call mvn clean install
call mvn exec:java