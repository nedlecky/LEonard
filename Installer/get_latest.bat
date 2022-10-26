@echo off
set filename=get_latest.bat
set title=LEonard Get Latest
set version=2022-10-26
set description=Pulls latest development binaries, data, test code, UR code, and Gocator code into this directory

echo.
echo *** %title% ***   File: %filename%  Rev: %version%
echo =============================================================================================
echo Description: %description%
echo.

echo Your Registry Root is:
REG QUERY HKEY_CURRENT_USER\SOFTWARE\LEonard\ /v LEonardRoot

set LEonardRoot=C:\Users\nedlecky\GitHub\LEonard
echo This script pulls latest from : %LEonardRoot%
echo And places it in %CD%
echo.

set choice=n
set /p choice=Get latest from %LEonardRoot%? y/[n] 

if %choice%==y (
    rmdir /s /q LEonard
    rmdir /s /q DB
    rmdir /s /q Config
    rmdir /s /q Code
    rmdir /s /q UR
    rmdir /s /q Gocator
    robocopy %LEonardRoot%\LEonard\bin LEonard\bin /MIR
    robocopy %LEonardRoot%\DB DB /MIR
    robocopy %LEonardRoot%\Config Config /MIR
    robocopy %LEonardRoot%\Code Code /MIR
    robocopy %LEonardRoot%\UR UR /MIR
    robocopy %LEonardRoot%\Gocator Gocator /MIR
    echo.
    echo Operation complete.
) else (
    echo.
    echo Operation Skipped.
)
