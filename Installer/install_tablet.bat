@echo off
set filename=install_tablet.bat
set title=LEonardTablet Installer
set version=2022-06-23
set description=Put latest development binaries, test recipes, UR, and Gocator code into c:\LEonardTablet

echo.
echo *** %title% ***   File: %filename%  Rev: %version%
echo =============================================================================================
echo Description: %description%
echo.

set LEonardRoot=C:\LEonardTablet
echo This script puts the latest code in: %LEonardRoot%
echo.

set choice=n
set /p choice=Place latest in %LEonardRoot%? y/[n] 

if %choice%==y (
    rem bin and UR directories are mirrored to this source directory
    rem Recipes\Testing are only copied from here to root\Recipes\Testing if new files or newer dates than what is there
    robocopy LEonardTablet\bin %LEonardRoot%\LEonardTablet\bin /MIR
    rem robocopy Recipes\Testing %LEonardRoot%\Recipes\Testing /XO
    robocopy Recipes %LEonardRoot%\Recipes /XO
    robocopy UR %LEonardRoot%\UR /MIR
    robocopy Gocator %LEonardRoot%\Gocator /MIR
    echo.
    echo Operation complete.
) else (
    echo.
    echo Operation Skipped.
)
