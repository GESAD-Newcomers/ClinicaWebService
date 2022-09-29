using src.Interaces;
using src.Views;

public class Service : IService
{
    public List<MedicoView> acharMedico(MedicoView medico)
    {
        throw new NotImplementedException();
    }

    public List<PacienteView> acharPaciente(PacienteView paciente)
    {
        throw new NotImplementedException();
    }

    public bool addMedico(MedicoView medico)
    {
        throw new NotImplementedException();
    }

    public bool addPaciente(PacienteView paciente)
    {
        throw new NotImplementedException();
    }

    public bool agendarConsulta(MedicoView medico, PacienteView paciente, DateTime data)
    {
        throw new NotImplementedException();
    }

    public MedicoView alterarMedico(MedicoView medico)
    {
        throw new NotImplementedException();
    }

    public MedicoView alterarPaciente(PacienteView paciente)
    {
        throw new NotImplementedException();
    }

    public void delMedico(int id)
    {
        throw new NotImplementedException();
    }

    public void delPaciente(int id)
    {
        throw new NotImplementedException();
    }

    public bool realizarConsulta()
    {
        throw new NotImplementedException();
    }

    public List<ConsultaView> todasConsultas(MedicoView medico, DateTime inicio, DateTime fim)
    {
        throw new NotImplementedException();
    }

    public List<AgendamentoView> todosAgendamentos(MedicoView medico, DateTime inicio, DateTime fim)
    {
        throw new NotImplementedException();
    }

    public List<AgendamentoView> todosAgendamentos(PacienteView paciente, DateTime inicio, DateTime fim)
    {
        throw new NotImplementedException();
    }

    public List<MedicoView> todosMedicos()
    {
        throw new NotImplementedException();
    }

    public List<PacienteView> todosPacientes()
    {
        throw new NotImplementedException();
    }

    PacienteView IService.alterarPaciente(PacienteView paciente)
    {
        throw new NotImplementedException();
    }
}