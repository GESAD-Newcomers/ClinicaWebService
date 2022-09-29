namespace src.Utils.DbAttributes
{
    public class ForeignKeyAttribute : Attribute
    { 
        public string table { get; set; }
        public string column { get; set; }

        public ForeignKeyAttribute(string table, string column)
        {
            this.table = table;
            this.column = column;
        }
     }
}