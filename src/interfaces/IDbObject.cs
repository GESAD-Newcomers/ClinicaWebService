using System.Security.Cryptography.X509Certificates;
namespace src.Interaces
{
    public interface IDbObject
    {
        public (string keys, string values) toDbInsert();
        public string toDbUpdate();
        public int id();
    }


}