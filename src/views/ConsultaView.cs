using System.Runtime.Serialization;
using src.Interaces;
using src.Utils.DbInteractions;

namespace src.Views
{
    [DataContract]
    public class ConsultaView
    {
        [DataMember]
        public int? id { get; set; }
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

        public ConsultaView(int? id, MedicoView medico, PacienteView paciente, DateTime data, bool realizada, string? relatorio)
        {
            this.medico=medico;
            this.paceinte=paciente;
            this.id=id;
            this.data=data;
            this.relatorio=relatorio;
            this.realizada=realizada;
        }

        public ConsultaView(){}
        public static ConsultaView fromModel(src.Models.ConsultaModel consulta){

            MedicoDbInteraction mDb = new MedicoDbInteraction();
            PacienteDbInteraction pdb = new PacienteDbInteraction();

            return new ConsultaView(consulta.id, 
                                    MedicoView.fromModel(mDb.SELECT_EQUALS(consulta.medicoID)),
                                    PacienteView.fromModel(pdb.SELECT_EQUALS(consulta.pacienteID)),
                                    consulta.data,
                                    consulta.realizada,
                                    consulta.relatorio);
        }
    }
}