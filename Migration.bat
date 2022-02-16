@echo off

:SCRIPT
    :: Extract date fields - language dependent 
	setlocal enabledelayedexpansion

	set hour=%time:~0,2%
	if "%hour:~0,1%" == " " set hour=0%hour:~1,1%
	set min=%time:~3,2%
	if "%min:~0,1%" == " " set min=0%min:~1,1%
	set secs=%time:~6,2%
	if "%secs:~0,1%" == " " set secs=0%secs:~1,1%
	set year=%date:~-4%
	set month=%date:~3,2%
	if "%month:~0,1%" == " " set month=0%month:~1,1%
	set day=%date:~0,2%
	if "%day:~0,1%" == " " set day=0%day:~1,1%	
	
    set datetime=%year%%month%%day%_%hour%%min%%secs%
	set migrationid=%year%%month%%day%%hour%%min%%secs%
	
	set dirScript=Tradeforce.Migrate\Migrations
	set Arquivo=%datetime%_%2.cs
	set Script=%dirScript%\%Arquivo%

	echo using FluentMigrator;>%Script%
	echo.>> %Script%
	echo namespace Tradeforce.Migrate.Migrations>> %Script%
	echo {>> %Script%
	echo     [Migration(%migrationid%)]>> %Script%
	echo     public class %2 : Migration>> %Script%
	echo     {>> %Script%
	echo         private const string Table = "";>> %Script%
	echo.>> %Script%
	echo         public override void Up()>> %Script%
	echo         {>> %Script%
	echo         }>> %Script%
	echo.>> %Script%
	echo         public override void Down()>> %Script%
	echo         {>> %Script%
	echo         }>> %Script%
	echo     }>> %Script%
	echo }>> %Script%

	echo.
	echo. Arquivo criado: %Arquivo%
goto FIM

:FIM
	echo. Finalizado
