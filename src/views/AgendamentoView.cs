using System.Runtime.Serialization;
using src.Enums;
using src.Interaces;
using src.Utils.DbInteractions;

namespace src.Views
{
    [DataContract]
    public class AgendamentoView
    {
        [DataMember]
        public int? id { get; set; }
        [DataMember]
        public MedicoView medico { get; set; }
        [DataMember]
        public PacienteView paceinte { get; set; }
        [DataMember]
        public DateTime data { get; set; }

        public AgendamentoView(int? id, MedicoView medico, PacienteView paciente, DateTime data)
        {
            this.medico=medico;
            this.paceinte=paciente;
            this.id=id;
            this.data=data;
        }

        public AgendamentoView(){}

        public static AgendamentoView fromModel(src.Models.AgendamentoModel agendamento){

            MedicoDbInteraction mDb = new MedicoDbInteraction();
            PacienteDbInteraction pdb = new PacienteDbInteraction();

            return new AgendamentoView(agendamento.id, 
                                       MedicoView.fromModel(mDb.SELECT_EQUALS(agendamento.medicoID)),
                                       PacienteView.fromModel(pdb.SELECT_EQUALS(agendamento.pacienteID)),
                                       agendamento.data);
        }
    }
}