using src.Models;

namespace src.Utils.DbInteractions
{
    public class MedicoDbInteraction : IDbInteraction
    {
        // protected IEnumerable<MedicoModel> SELECT_LIKE<T>(string table, T obj) where T : iDbInteraction
        // {
        //     throw new NotImplementedException();
        // }

        const string DbTableName = "Medicos";


        public IEnumerable<MedicoModel> SELECT_LIKE( MedicoModel obj)
        {
            return SELECT_WHERE<MedicoModel>("Medicos", "name like '%" +obj.name+ "%' OR especialidade=" + obj.especialidade );
        }

        public void UPDATE(MedicoModel obj)
        {
            base.UPDATE<MedicoModel>(DbTableName, obj);
        }

        public void INSERT(MedicoModel obj)
        {
            base.INSERT<MedicoModel>(DbTableName, obj);
        }

        public IEnumerable<MedicoModel> SELECT_ALL()
        {
            return base.SELECT_ALL<MedicoModel>(DbTableName);
        }

        public MedicoModel SELECT_EQUALS(int id)
        {
            return base.SELECT_EQUALS<MedicoModel>(DbTableName, id);
        }

        public void DELETE(int id)
        {
            base.DELETE(DbTableName, id);
        }
    }
}