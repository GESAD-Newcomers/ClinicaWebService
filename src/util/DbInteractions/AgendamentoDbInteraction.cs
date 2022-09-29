using src.Models;

namespace src.Utils.DbInteractions
{
    public class AgendamentoDbInteraction : IDbInteraction
    {
        const string DbTableName = "Agendamentos";
        public IEnumerable<AgendamentoModel> SELECT_LIKE(string table, AgendamentoModel obj)
        {
            return SELECT_WHERE<AgendamentoModel>(DbTableName, "medicoID=" +obj.medicoID+ " OR pacienteID=" + obj.pacienteID + " OR data=convert(datetime, '" + obj.data.ToString("yyyy-MM-dd HH:mm:ss") + "' , 20)" );
        }

        public void UPDATE(AgendamentoModel obj)
        {
            base.UPDATE<AgendamentoModel>(DbTableName, obj);
        }

        public void INSERT(AgendamentoModel obj)
        {
            base.INSERT<AgendamentoModel>(DbTableName, obj);
        }

        public IEnumerable<AgendamentoModel> SELECT_ALL()
        {
            return base.SELECT_ALL<AgendamentoModel>(DbTableName);
        }

        public AgendamentoModel SELECT_EQUALS(int id)
        {
            return base.SELECT_EQUALS<AgendamentoModel>(DbTableName, id);
        }

        public void DELETE(int id)
        {
            base.DELETE(DbTableName, id);
        }
    }
}