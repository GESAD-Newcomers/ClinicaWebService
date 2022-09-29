using System.Runtime.Serialization;
using src.Enums;
using src.Interaces;

namespace src.Models
{
    [DataContract]
    public class AgendamentoModel : IDbObject
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int medicoID  { get; set; }
        [DataMember]
        public int pacienteID { get; set; }
        [DataMember]
        public DateTime data { get; set; }

        public (string keys, string values) toDbInsert()
        {
            string keys = "( medicoID, pacienteID, data )",
                   values = "( " + medicoID + ", " +pacienteID + ", convert(datetime, '" + data.ToString("yyyy-MM-dd HH:mm:ss") + "', 20))";

            return (keys, values);
        }

        public string toDbUpdate()
        {
            return "medicoID="+medicoID+ " , pacienteID="+pacienteID+" , data=convert(datetime, '"+data.ToString("yyyy-MM-dd HH:mm:ss")+"', 20)";
        }

        int IDbObject.id() { return id; }
    }
}