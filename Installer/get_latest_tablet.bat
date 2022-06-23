@echo off
set filename=get_latest_tablet.bat
set title=LEonardTablet Get Latest
set version=2022-06-23
set description=Pulls latest development binaries, recipes, UR, and Gocator code into this directory

echo.
echo *** %title% ***   File: %filename%  Rev: %version%
echo =============================================================================================
echo Description: %description%
echo.

echo Your Registry Root is:
REG QUERY HKEY_CURRENT_USER\SOFTWARE\LEonardTablet\ /v LEonardTabletRoot

set LEonardRoot=C:\Users\nedlecky\GitHub\LEonard
echo This script pulls latest from : %LEonardRoot%
echo.

set choice=n
set /p choice=Get latest from %LEonardRoot%? y/[n] 

if %choice%==y (
    rmdir /s /q LEonardTablet
    rmdir /s /q Recipes
    rmdir /s /q UR
    rmdir /s /q Gocator
    robocopy %LEonardRoot%\LEonardTablet\bin LEonardTablet\bin /MIR
    robocopy %LEonardRoot%\Recipes Recipes /MIR
    robocopy %LEonardRoot%\UR UR /MIR
    robocopy %LEonardRoot%\Gocator Gocator /MIR
    echo.
    echo Operation complete.
) else (
    echo.
    echo Operation Skipped.
)
