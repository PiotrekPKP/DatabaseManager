# DatabaseManager

DatabaseManager is C# library for easy usage of MySQL databases.

## Prepare packages

Install Nuget [MySql.Data package](https://www.nuget.org/packages/MySql.Data/) for database connection.

```bash
Install-Package MySql.Data -Version 8.0.20
```

## Usage

For initializing database connection and checking if it works properly use
```csharp
if (!DbManager.Initialize("host", "dbname", "user", "password")) return; //SERVER ERROR
```

For getting data from table use
```csharp
((ExampleClass)DbManager.Execute("SELECT * FROM codes")[i]).StringPropertyName; //GIVES THE ith ITEM's StringPropertyName PROPERTY
```

For inserting data into table use
```csharp
DbManager.PerformAction("INSERT INTO table VALUES ('valueOne', 'valueTwo')"); //INSERTS valueOne AND valueTwo INTO table TABLE
```

For updating data in table use
```csharp
DbManager.PerformAction("UPDATE table SET valueOne='valueOne' WHERE valueTwo='valueTwo'"); //UPDATES valueOne VARIABLE IN table TABLE WHERE valueTwo VARIABLE EQUALS valueTwo
```

For deleting row from table use
```csharp
DbManager.PerformAction("DELETE FROM table WHERE valueOne='valueOne'"); //DELETES ROW FROM table TABLE WHERE valueOne VARIABLE EQUALS valueOne
```
