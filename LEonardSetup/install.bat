@echo off
set filename=install.bat
set title=LEonard Installer
set version=2022-11-14
set description=Put latest development binaries, example, and 3rd Party code into C:\LEonard

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
    rem LEonard and LEonardClient binaries are mirror copied
    rem Others are only copied if newer
    robocopy LEonard %LEonardRoot%\LEonard /MIR
    robocopy LEonardClient %LEonardRoot%\LEonardClient /MIR
    robocopy 3rdParty %LEonardRoot%\3rdParty /XO /S
    robocopy Code %LEonardRoot%\Code /XO /S
    robocopy Config %LEonardRoot%\Config /XO /S
    echo.
    echo Operation complete.
) else (
    echo.
    echo Operation Skipped.
)
