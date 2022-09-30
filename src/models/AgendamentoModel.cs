using System.Runtime.Serialization;
using src.Enums;
using src.Interaces;

namespace src.Models
{
    [DataContract]
    public class AgendamentoModel : IDbObject
    {
        [DataMember]
        public int? id { get; set; }
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

        int IDbObject.id() { return id ?? 0; }

        public AgendamentoModel(int? id, int medicoID, int pacienteID, DateTime data)
        {
            this.data=data;
            this.id=id;
            this.pacienteID=pacienteID;
            this.medicoID=medicoID;
        }

        public AgendamentoModel(){}

        public static AgendamentoModel fromView(src.Views.AgendamentoView agendamento) => new AgendamentoModel(agendamento.id,
                                                                                                    agendamento.medico.id ?? 0, 
                                                                                                    agendamento.paceinte.id ?? 0, 
                                                                                                    agendamento.data);
    }
}