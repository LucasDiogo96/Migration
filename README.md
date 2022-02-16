# Migration

## Purpouse
> The migration project has the purpose of managing the changes made to the database.

## Type of application
 > Console application.

## Built With
- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/5.0)
- [.Fluent Migrator](https://fluentmigrator.github.io/api/index.html)

## Creating a migration

1 -  Open the command line inside the root of the project

2 - Execute the following command:

```bash
.\Migration.bat new {MigrationName}
```

3 - This command will generate a file in the folder Migration.Sample >> Migrations.

4 - Add file to the solution.

5 - Add the SQL to be executed.


## How to Run

To run the application you can use the following command in the prompt command inside of the project folder.

1 - Go to the directory where the api project is.
```bash
cd src\Migration.Sample
```
2 - After this, restore the packages.
```bash
dotnet restore
```
3 - Set the SQL Server connection string in the env variables
```bash
 CONN_STRING  = {{Azure app configuration connection string}}
```
4 - Finally.
```bash
dotnet run
```

