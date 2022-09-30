using System.Linq;
using src.Interaces;
using src.Models;
using src.Utils.DbInteractions;
using src.Views;

public class Service : IService
{
    private readonly MedicoDbInteraction mDb = new MedicoDbInteraction();
    private readonly PacienteDbInteraction pDb = new PacienteDbInteraction();
    private readonly AgendamentoDbInteraction aDb = new AgendamentoDbInteraction();
    private readonly ConsultaDbInteraction cDb = new ConsultaDbInteraction();

    public List<MedicoView> acharMedico(MedicoView medico)
    {
        if(medico.id != null)
        {
            var list = new List<MedicoView>();
            list.Add(MedicoView.fromModel(mDb.SELECT_EQUALS(medico.id ?? 0)));

            return list; //{};
        }

        var tM = mDb.SELECT_LIKE(MedicoModel.fromView(medico));

        return (from x in tM
              select MedicoView.fromModel(x)).ToList();
    }

    public List<PacienteView> acharPaciente(PacienteView paciente)
    {
        if(paciente.id != null)
        {
            var list = new List<PacienteView>();
            list.Add(PacienteView.fromModel(pDb.SELECT_EQUALS(paciente.id ?? 0)));

            return list; //{};
        }

        var tP = pDb.SELECT_LIKE(PacienteModel.fromView(paciente));

        return (from x in tP
              select PacienteView.fromModel(x)).ToList();

    }

    public bool addMedico(MedicoView medico)
    {
        // TODO: Verificar a existencia de paciente igual
        if(true)
        {
            mDb.INSERT(MedicoModel.fromView(medico));

            return true;
        }
        return false;
    }

    public bool addPaciente(PacienteView paciente)
    {
        // TODO: Verificar a existencia de paciente igual
        if(true)
        {
            pDb.INSERT(PacienteModel.fromView(paciente));

            return true;
        }
        return false;
    }

    public bool agendarConsulta(int medicoID, int pacienteID, DateTime data)
    {
        // TODO: Verificar a existencia de outras consutlas nesse horario
        if(true)
        {
            aDb.INSERT(new AgendamentoModel(0, medicoID, pacienteID, data));

            return true;
        }
        return false;
    }

    public void alterarMedico(MedicoView medico)
    {
        MedicoModel m = MedicoModel.fromView(medico);

        mDb.UPDATE(m);
    }

    public void alterarPaciente(PacienteView paciente)
    {
        PacienteModel p = PacienteModel.fromView(paciente);

        pDb.UPDATE(p);
    }

    public void delMedico(int id)
    {
        mDb.DELETE(id);
    }

    public void delPaciente(int id)
    {
        pDb.DELETE(id);
    }

    public void realizarConsulta(AgendamentoView agendamento, bool realizada, string? relatorio)
    {
        aDb.DELETE(agendamento.id ?? 0);

        var a = AgendamentoModel.fromView(agendamento);

        cDb.INSERT(new ConsultaModel(a.id, a.medicoID, a.pacienteID, a.data,realizada, relatorio));
    }

    public List<ConsultaView> todasConsultas(int medicoID, DateTime inicio, DateTime fim)
    {
        var tC = cDb.SELECT_BETWEEN(medicoID, "medicoID", inicio, fim);

        return (from x in tC select ConsultaView.fromModel(x)).ToList();
    }

    public List<AgendamentoView> todosAgendamentosMed(int medicoID, DateTime inicio, DateTime fim)
    {
        var tA = aDb.SELECT_BETWEEN(medicoID, "medicoID", inicio, fim);

        return (from x in tA select AgendamentoView.fromModel(x)).ToList();
    }

    public List<AgendamentoView> todosAgendamentosPaci(int pacienteID, DateTime inicio, DateTime fim)
    {
        var tA = aDb.SELECT_BETWEEN(pacienteID, "pacienteID", inicio, fim);

        return (from x in tA select AgendamentoView.fromModel(x)).ToList();
    }

    public List<MedicoView> todosMedicos()
    {
        var tM = mDb.SELECT_ALL();

        return (from x in tM
              select MedicoView.fromModel(x)).ToList();
    }

    public List<PacienteView> todosPacientes()
    {
        var tP = pDb.SELECT_ALL();

        return (from x in tP
              select PacienteView.fromModel(x)).ToList();
    }
}