# Lego Data Set Loader

This repository contains code meant to automate the loading of [Rebrickable's](https://rebrickable.com) Lego data set to SQL Server.

[Rebrickable](https://rebrickable.com) makes a full data set of all Lego parts, sets, minifigs, etc. available for public use, and it makes an excellent data set for examples. It is available for download [here](https://rebrickable.com/downloads).

## Using the Repository

This code contains both a database schema (using SQL Server naming practices), code to upload the data, and the data itself.

### Deploying the Database Schema

First, ensure that [Flyway](https://flywaydb.org) is installed an on your path (or you are using the Docker container).

Second, create a database named `Lego` on the SQL Server of your choice.

Third, update the `/src/flyway/flyway.conf` file with the appropriate url, user name, and password. Note that Flyway uses JDBC connections, so your SQL Server URL will look like the following:

```
flyway.url=jdbc:sqlserver://localhost:1433;databaseName=Lego;encrypt=true;trustServerCertificate=true
```

Next, execute the migration using the following command:

```
flyway -configFiles="../flyway/conf/flyway.conf" -locations="filesystem:../flyway/sql" migrate
```

> Note: this command was executed from the `./src/LegoDataSetLoader` path, but can be executed from anywhere by adjusting the paths in the command.

You should see some output from Flyway indicating the migrations have been successfully run.

### Running the Data Loader

First, initialize the User Secrets store in the `./src/LegoDataSetLoader/LegoDataSetLoader.Program` folder by running the following command:

```
dotnet user-secrets init
```

After a brief moment, you should get feedback that the User Secrets store is initialized.

Next, add your connection string to the User Secrets store using something like the following:

```
dotnet user-secrets set "ConnectionStrings:Default" "Server=localhost;Database=Lego;User Id=<your user id here>;Password=<your password here>"
```

The User Secrets store is a great way to store sensitive data outside of an `app.settings.json` file. You can read more about the User Secrets store [here](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows).

Now, you should be ready to run the application. In the same path, run the following commands:

```
dotnet restore
dotnet build
dotnet run
```

The program should run for a couple minutes (depending on the speed of your machine and the SQL Server).

You can check the progress by running the following query while connected to your database:

```sql
SELECT o.name,
  ddps.row_count 
FROM sys.indexes AS i
  INNER JOIN sys.objects AS o ON i.OBJECT_ID = o.OBJECT_ID
  INNER JOIN sys.dm_db_partition_stats AS ddps ON i.OBJECT_ID = ddps.OBJECT_ID
  AND i.index_id = ddps.index_id 
WHERE i.index_id < 2  AND o.is_ms_shipped = 0 ORDER BY o.NAME 
```