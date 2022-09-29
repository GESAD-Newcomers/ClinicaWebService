using System.Runtime.Serialization;
using src.Interaces;

namespace src.Views
{
    [DataContract]
    public class ConsultaView
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public MedicoView medico { get; set; }
        [DataMember]
        public PacienteView paceinte { get; set; }
        [DataMember]
        public DateTime data { get; set; }
        [DataMember]
        public string ?relatorio { get; set; }
        [DataMember]
        public bool realizada { get; set; }
    }
}