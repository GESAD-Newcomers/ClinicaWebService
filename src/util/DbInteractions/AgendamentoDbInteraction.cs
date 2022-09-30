using src.Models;

namespace src.Utils.DbInteractions
{
    public class AgendamentoDbInteraction : IDbInteraction
    {
        const string DbTableName = "Agendamentos";
        public IEnumerable<AgendamentoModel> SELECT_LIKE(AgendamentoModel obj)
        {
            return SELECT_WHERE<AgendamentoModel>(DbTableName, "medicoID=" +obj.medicoID+ " OR pacienteID=" + obj.pacienteID + " OR data=convert(datetime, '" + obj.data.ToString("yyyy-MM-dd HH:mm:ss") + "' , 21)" );
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

        public IEnumerable<AgendamentoModel> SELECT_BETWEEN(DateTime d1, DateTime d2)
        {
            return SELECT_WHERE<AgendamentoModel>(DbTableName, $"data between convert(datetime, '{d1.ToString("yyyy-MM-dd HH:mm:ss")}', 21) AND convert(datetime, '{d2.ToString("yyyy-MM-dd HH:mm:ss")}', 21)");
        }
        public IEnumerable<AgendamentoModel> SELECT_BETWEEN(int id, string col,DateTime d1, DateTime d2)
        {
            return SELECT_WHERE<AgendamentoModel>(DbTableName, $"data between convert(datetime, '{d1.ToString("yyyy-MM-dd HH:mm:ss")}', 21) AND convert(datetime, '{d2.ToString("yyyy-MM-dd HH:mm:ss")}', 21) AND ${col}=${id}");
        }
    }
}