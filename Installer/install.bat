@echo off
set filename=install.bat
set title=LEonard Installer
set version=2022-11-07
set description=Put latest development binaries, data, test code, and 3rd Party code into C:\LEonard

echo.
echo *** %title% ***   File: %filename%  Rev: %version%
echo =============================================================================================
echo Description: %description%
echo.

set LEonardRoot=C:\LEonard
echo This script takes the code located here in %CD%
echo And puts it in: %LEonardRoot%
echo.

set choice=n
set /p choice=Place latest in %LEonardRoot%? y/[n] 

if %choice%==y (
    rem bin and UR directories are mirrored to this source directory
    rem Recipes\Testing are only copied from here to root\Recipes\Testing if new files or newer dates than what is there
    robocopy LEonard\bin %LEonardRoot%\LEonard\bin /MIR
    robocopy DB %LEonardRoot%\DB /XO /S
    robocopy Config %LEonardRoot%\Config /XO /S
    robocopy Code %LEonardRoot%\Code /XO /S
    robocopy 3rdParty %LEonardRoot%\3rdParty /XO /S
    echo.
    echo Operation complete.
) else (
    echo.
    echo Operation Skipped.
)
