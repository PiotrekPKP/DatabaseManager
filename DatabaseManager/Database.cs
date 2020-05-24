namespace DatabaseManager
{
    internal static class Database
    {
        private static void Main(string[] args)
        {
            //INITIALIZING DATABASE CONNECTION
            if (!DbManager.Initialize("localhost", "tests", "root", "")) return; //SERVER ERROR
            
            //GETTING FROM TABLE EXAMPLE
            //((Codes)DbManager.Execute("SELECT * FROM codes")[i]).Code; //GIVES THE ith ITEM's Code PROPERTY
            
            //INSERTING INTO TABLE EXAMPLE
            //DbManager.PerformAction("INSERT INTO codes VALUES ('id', 'code')"); //INSERTS id AND code INTO codes TABLE
            
            //UPDATING TABLE VARIABLES EXAMPLE
            //DbManager.PerformAction("UPDATE codes SET code='code' WHERE id='id'"); //UPDATES code VARIABLE IN codes TABLE WHERE id VARIABLE EQUALS id
            
            //DELETING ROW FROM TABLE EXAMPLE
            //DbManager.PerformAction("DELETE FROM codes WHERE id='id'"); //DELETES ROW FROM codes TABLE WHERE id VARIABLE EQUALS id
        }
    }
}