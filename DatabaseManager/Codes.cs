namespace DatabaseManager
{
    //CLASS EXAMPLE FOR TABLE WITH 2 COLS - id AND code
    public class Codes : DataModel
    {
        //USE CONSTRUCTOR TO INITIALIZE PROPERTIES IN CLASS
        public Codes(int id, string code)
        {
            Id = id;
            Code = code;
        }
        public int Id { get; }
        public string Code { get; }
    }
}