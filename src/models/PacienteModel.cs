using System.Runtime.Serialization;
using src.Enums;
using src.Interaces;

namespace src.Models
{
    [DataContract]
    public class PacienteModel : IDbObject
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int sexo { get; set; }

        public (string keys, string values) toDbInsert()
        {
            string keys = "( name, sexo )",
            values = "( '" + name + "' , " + sexo + " )";

            return (keys, values);
        }

        public string toDbUpdate()
        {
            return "name='" + name + "' , sexo=" + sexo;
        }

        int IDbObject.id() { return id; }

    }
}