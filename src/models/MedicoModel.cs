using System.Runtime.Serialization;
using src.Enums;
using src.Interaces;

namespace src.Models
{
    [DataContract]
    public class MedicoModel : IDbObject
    {
        [DataMember]
        public int? id { get; set; }
        [DataMember]

        public string name { get; set; }
        [DataMember]
        public int especialidade { get; set; }

        public (string keys, string values) toDbInsert()
        {
            string keys = "( name, especialidade )",
                   values = "( '" + name + "' , " + especialidade + " )";

            return (keys, values);
        }

        public string toDbUpdate()
        {
            return "name='" + name + "' , espacialidade=" + especialidade;
        }

        int IDbObject.id() { return id ?? 0; }

        public MedicoModel(int? id, string name, int espacialidade)
        {
            this.id=id;
            this.name=name;
            this.especialidade=especialidade;
        }

        public MedicoModel(){}


        public static MedicoModel fromView(src.Views.MedicoView medico) => new MedicoModel(medico.id,
                                                                                        medico.name, 
                                                                                        ((int)medico.especialidade));

    }
}