using System.Runtime.Serialization;
using src.Interaces;

namespace src.Models
{
    [DataContract]
    public class ConsultaModel : IDbObject
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int medicoID { get; set; }
        [DataMember]
        public int pacienteID { get; set; }
        [DataMember]
        public DateTime data { get; set; }
        [DataMember]
        public string ?relatorio { get; set; }
        [DataMember]
        public bool realizada { get; set; }

        public (string keys, string values) toDbInsert()
        {
            string keys = "( medicoID, pacienteID, data, relatorio, realizada )",
                   values = "( " + medicoID + ", " +pacienteID + ", convert(datetime, '" + data.ToString("yyyy-MM-dd HH:mm:ss") + "', 20), '" + relatorio ?? "" + "', " + (realizada ? 1 : 0) + " )";

            return (keys, values);        
        }

        public string toDbUpdate()
        {
            return "medicoID="+medicoID+ " , pacienteID="+pacienteID+" , data=convert(convert(datetime, '" +data.ToString("yyyy-MM-dd HH:mm:ss") + "', 20) , relatorio='"+ relatorio ?? " " + "' , realizada="+ (realizada ? 1 : 0);
        }

        int IDbObject.id() { return id; }
    }
}