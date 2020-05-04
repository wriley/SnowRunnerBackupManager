#!/bin/bash

rm -f download/SnowRunnerBackupManager.zip
zip -j download/SnowRunnerBackupManager.zip SnowRunnerBackupManager/bin/Release/SnowRunnerBackupManager.exe SnowRunnerBackupManager/bin/Release/ICSharpCode.SharpZipLib.dll SnowRunnerBackupManager/bin/Release/Newtonsoft.Json.dll
