using System.ServiceModel;
using src.Views;

namespace src.Interaces
{
    [ServiceContract]
    public interface IService
    {
        //? Medico actions

        [OperationContract]
        public bool addMedico(MedicoView medico);
        [OperationContract]
        public void alterarMedico(MedicoView medico);
        [OperationContract]
        public void delMedico(int id);
        [OperationContract]
        public List<MedicoView> acharMedico(MedicoView medico);
        [OperationContract]
        public List<MedicoView> todosMedicos();
    
        //? Paciente actions

        [OperationContract]
        public bool addPaciente(PacienteView paciente);
        [OperationContract]
        public void alterarPaciente(PacienteView paciente);
        [OperationContract]
        public void delPaciente(int id);
        [OperationContract]
        public List<PacienteView> acharPaciente(PacienteView paciente);
        [OperationContract]
        public List<PacienteView> todosPacientes();
        [OperationContract]
        
        //? Operations
        
        public bool agendarConsulta(int medicoID, int pacienteID, DateTime data);
        [OperationContract]
        public void realizarConsulta(AgendamentoView agendamento, bool realizada, string? relatorio);
        [OperationContract]
        public List<ConsultaView> todasConsultas (int medicoID, DateTime inicio, DateTime fim);
        [OperationContract]
        public List<AgendamentoView> todosAgendamentosMed(int medicoID, DateTime inicio, DateTime fim);
        [OperationContract]
        public List<AgendamentoView> todosAgendamentosPaci(int pacienteID, DateTime inicio, DateTime fim);

    }




}