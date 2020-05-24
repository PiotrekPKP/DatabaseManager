namespace DatabaseManager
{
    internal static class Database
    {
        private static void Main(string[] args)
        {
            //INITIALIZING DATABASE CONNECTION
            if (!DbManager.Initialize("host", "dbname", "user", "password")) return; //SERVER ERROR
            
            //GETTING FROM TABLE EXAMPLE
            //((ExampleClass)DbManager.Execute("SELECT * FROM codes")[i]).StringPropertyName; //GIVES THE ith ITEM's StringPropertyName PROPERTY
            
            //INSERTING INTO TABLE EXAMPLE
            //DbManager.PerformAction("INSERT INTO table VALUES ('valueOne', 'valueTwo')"); //INSERTS valueOne AND valueTwo INTO table TABLE
            
            //UPDATING TABLE VARIABLES EXAMPLE
            //DbManager.PerformAction("UPDATE table SET valueOne='valueOne' WHERE valueTwo='valueTwo'"); //UPDATES valueOne VARIABLE IN table TABLE WHERE valueTwo VARIABLE EQUALS valueTwo
            
            //DELETING ROW FROM TABLE EXAMPLE
            //DbManager.PerformAction("DELETE FROM table WHERE valueOne='valueOne'"); //DELETES ROW FROM table TABLE WHERE valueOne VARIABLE EQUALS valueOne
        }
    }
}