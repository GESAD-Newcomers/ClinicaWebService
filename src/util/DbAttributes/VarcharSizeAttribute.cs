namespace src.Utils.DbAttributes
{
    public class VarcharSizeAttribute : Attribute
    {  
        public int size { get; set; }

        public VarcharSizeAttribute(int size)
        {
            this.size = size;
        }

    }
}