@echo off

echo [Vert]
glslangValidator.exe -G -o texture.vert.spv texture.vert
if errorlevel 1 goto err

echo [Frag]
glslangValidator.exe -G -o texture.frag.spv texture.frag
if errorlevel 1 goto err

goto eof

:err
echo nonzero error code %errorlevel%
rem pause

:eof