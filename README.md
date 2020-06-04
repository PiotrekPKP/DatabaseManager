# DatabaseManager

DatabaseManager is C# library for easy usage of MySQL databases.

## Prepare packages

Install Nuget [MySql.Data package](https://www.nuget.org/packages/MySql.Data/) for database connection.

```bash
Install-Package MySql.Data -Version 8.0.20
```

## Prepare project

Rename all namespaces from ```YourApp``` to your app namespace.

Create new class based on your SQL table. It should contain same properties as your table's columns (e.g. when your table has got ```id``` column and ```text``` column your class shoud have Id and Text properties). Remember to extend your class with DataModel.

```csharp
namespace YourApp
{
    public class ExampleClass : DataModel
    {      
        public ExampleClass(string propertyName, int secondProperty)
        {
            PropertyName = propertyName;
            SecondProperty = secondProperty;
        }
        public string PropertyName { get; }
        public int SecondProperty { get; }
    }
}
```

Add SQL table support to DbManager.cs file. Replace "table_name" with your table's name, ExampleClass with class equivalent to your table and pass arguments casted properly (e.g. ```x[0].ToString()``` and ```int.Parse(x[1].ToString())```).

```csharp
"table_name" => result.AsEnumerable()
                    .Select(x => new ExampleClass(
                        x[0].ToString(),
                        int.Parse(x[1].ToString())
                    ))
                    .ToArray(),
```

## Usage

For initializing database connection and checking if it works properly (returns when server error occurred) use:
```csharp
if (!DbManager.Initialize("host", "dbname", "user", "password")) return;
```

For getting data from table (gives the ith row's property - column named 'PropertyName') use:
```csharp
((ExampleClass)DbManager.Execute(query)[i]).PropertyName;
```

For inserting, updating or deleting data from table use:
```csharp
DbManager.PerformAction(query);
```
### Creating query

Replace ```query``` with
```csharp
DbManager.CreateQuery(query, "@parameter", parameterValue);
```
Example
```csharp
DbManager.CreateQuery("SELECT * FROM table WHERE column=@value AND columnTwo=@valueTwo", "@value", value, "@valueTwo", valueTwo);
```
