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
        public MedicoView alterarMedico(MedicoView medico);
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
        public PacienteView alterarPaciente(PacienteView paciente);
        [OperationContract]
        public void delPaciente(int id);
        [OperationContract]
        public List<PacienteView> acharPaciente(PacienteView paciente);
        [OperationContract]
        public List<PacienteView> todosPacientes();
        [OperationContract]
        
        //? Operations
        
        public bool agendarConsulta(MedicoView medico, PacienteView paciente, DateTime data);
        [OperationContract]
        public bool realizarConsulta();
        [OperationContract]
        public List<ConsultaView> todasConsultas (MedicoView medico, DateTime inicio, DateTime fim);
        [OperationContract]
        public List<AgendamentoView> todosAgendamentos(MedicoView medico, DateTime inicio, DateTime fim);
        [OperationContract]
        public List<AgendamentoView> todosAgendamentos(PacienteView paciente, DateTime inicio, DateTime fim);

    }




}