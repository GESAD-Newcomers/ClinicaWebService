using src.Models;

namespace src.Utils.DbInteractions
{
    public class PacienteDbInteraction : IDbInteraction
    {
        const string DbTableName = "Pacientes";
        public IEnumerable<PacienteModel> SELECT_LIKE(string table, PacienteModel obj)
        {
            return SELECT_WHERE<PacienteModel>(DbTableName, "name like '%" +obj.name+ "%' OR sexo=" + obj.sexo );
        }

        public void UPDATE(PacienteModel obj)
        {
            base.UPDATE<PacienteModel>(DbTableName, obj);
        }

        public void INSERT(PacienteModel obj)
        {
            base.INSERT<PacienteModel>(DbTableName, obj);
        }

        public IEnumerable<PacienteModel> SELECT_ALL()
        {
            return base.SELECT_ALL<PacienteModel>(DbTableName);
        }

        public PacienteModel SELECT_EQUALS(int id)
        {
            return base.SELECT_EQUALS<PacienteModel>(DbTableName, id);
        }

        public void DELETE(int id)
        {
            base.DELETE(DbTableName, id);
        }
    }
}