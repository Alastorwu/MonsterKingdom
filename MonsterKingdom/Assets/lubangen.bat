set WORKSPACE=..\..

set LUBAN_DLL=%WORKSPACE%\Luban\Tools\Luban\Luban.dll
set CONF_ROOT=%WORKSPACE%\Luban\DataTables

dotnet %LUBAN_DLL% ^
    -t client ^
    -c cs-bin ^
    -d bin  ^
    --conf %CONF_ROOT%\luban.conf ^
    -x outputCodeDir=Scripts\Gen ^
    -x outputDataDir=StreamingAssets\GenerateDatas\bytes ^
    -x pathValidator.rootDir=.. ^
    -x l10n.provider=default ^
    -x l10n.textFile.path=*@%WORKSPACE%\Luban\DataTables\Datas\l10n\texts.json ^
    -x l10n.textFile.keyFieldName=key

pause