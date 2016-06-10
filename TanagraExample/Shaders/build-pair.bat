@echo off

echo [Vert]
glslangValidator.exe -G -o %1.vert.spv %1.vert
if errorlevel 1 goto err

echo [Frag]
glslangValidator.exe -G -o %1.frag.spv %1.frag
if errorlevel 1 goto err

goto eof

:err
echo error code %errorlevel% :(
rem pause

:eof