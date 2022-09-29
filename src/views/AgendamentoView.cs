using System.Runtime.Serialization;
using src.Enums;
using src.Interaces;

namespace src.Views
{
    [DataContract]
    public class AgendamentoView
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public MedicoView medico { get; set; }
        [DataMember]
        public PacienteView paceinte { get; set; }
        [DataMember]
        public DateTime data { get; set; }
    }
}