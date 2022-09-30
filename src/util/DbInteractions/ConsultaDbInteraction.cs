using src.Models;

namespace src.Utils.DbInteractions
{
    public class ConsultaDbInteraction : IDbInteraction
    {
        const string DbTableName = "Consultas";
        public IEnumerable<ConsultaModel> SELECT_LIKE(ConsultaModel obj)
        {
            return SELECT_WHERE<ConsultaModel>(DbTableName, "medicoID=" +obj.medicoID+ " OR pacienteID=" + obj.pacienteID + " OR data=convert(datetime, '" + obj.data.ToString("yyyy-MM-dd HH:mm:ss") + "' , 21)" );
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

        public IEnumerable<ConsultaModel> SELECT_BETWEEN(DateTime d1, DateTime d2)
        {
            return SELECT_WHERE<ConsultaModel>(DbTableName, $"data between convert(datetime, '{d1.ToString("yyyy-MM-dd HH:mm:ss")}', 21) AND convert(datetime, '{d2.ToString("yyyy-MM-dd HH:mm:ss")}', 21)");
        }

        public IEnumerable<ConsultaModel> SELECT_BETWEEN(int id, string col,DateTime d1, DateTime d2)
        {
            return SELECT_WHERE<ConsultaModel>(DbTableName, $"data between convert(datetime, '{d1.ToString("yyyy-MM-dd HH:mm:ss")}', 21) AND convert(datetime, '{d2.ToString("yyyy-MM-dd HH:mm:ss")}', 21) AND ${col}=${id}");
        }
    }
}