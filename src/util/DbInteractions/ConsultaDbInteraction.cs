using src.Models;

namespace src.Utils.DbInteractions
{
    public class ConsultaDbInteraction : IDbInteraction
    {
        const string DbTableName = "Agendamento";
        public IEnumerable<ConsultaModel> SELECT_LIKE(string table, ConsultaModel obj)
        {
            return SELECT_WHERE<ConsultaModel>(DbTableName, "medicoID=" +obj.medicoID+ " OR pacienteID=" + obj.pacienteID + " OR data=convert(datetime, '" + obj.data.ToString("yyyy-MM-dd HH:mm:ss") + "' , 20)" );
        }

        public void UPDATE(ConsultaModel obj)
        {
            base.UPDATE<ConsultaModel>(DbTableName, obj);
        }

        public void INSERT(ConsultaModel obj)
        {
            base.INSERT<ConsultaModel>(DbTableName, obj);
        }

        public IEnumerable<ConsultaModel> SELECT_ALL()
        {
            return base.SELECT_ALL<ConsultaModel>(DbTableName);
        }

        public ConsultaModel SELECT_EQUALS(int id)
        {
            return base.SELECT_EQUALS<ConsultaModel>(DbTableName, id);
        }

        public void DELETE(int id)
        {
            base.DELETE(DbTableName, id);
        }
    }
}