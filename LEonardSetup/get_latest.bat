@echo off
set filename=get_latest.bat
set title=LEonard Get Latest
set version=2022-11-14
set description=Pulls latest development binaries, data, test code, and 3rdParty code into this directory

echo.
echo *** %title% ***   File: %filename%  Rev: %version%
echo =============================================================================================
echo Description: %description%
echo.

echo Your Registry Root is:
REG QUERY "HKCU\SOFTWARE\Lecky Engineering\LEonard" /v LEonardRoot

set LEonardRootDev=C:\Users\nedlecky\GitHub\LEonard
echo This script pulls latest from : %LEonardRootDev%
echo And places it here in your current directory: %CD%
echo.

set choice=n
set /p choice=Get latest from %LEonardRoot%? y/[n] 

if %choice%==y (
    rmdir /s /q LEonard
    rmdir /s /q LEonardClient
    rmdir /s /q Config
    rmdir /s /q Code
    rmdir /s /q 3rdParty
    rem Mirrors in the LEonard bin to LEonard
    rem Gets all of LEonardClient including source but no obj
    robocopy %LEonardRootDev%\LEonard\bin\Release LEonard /MIR
    robocopy %LEonardRootDev%\LEonardClient LEonardClient /MIR /XD %LEonardRootDev%\LEonardClient\obj
    robocopy %LEonardRootDev%\Config Config /MIR
    robocopy %LEonardRootDev%\Code Code /MIR
    robocopy %LEonardRootDev%\3rdParty 3rdParty /MIR
    echo.
    echo Operation complete.
) else (
    echo.
    echo Operation Skipped.
)
