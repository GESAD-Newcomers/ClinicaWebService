using System.Runtime.Serialization;
using src.Enums;
using src.Interaces;

namespace src.Views
{
    [DataContract]
    public class MedicoView 
    {
        [DataMember]
        public int? id { get; set; }
        [DataMember]

        public string name { get; set; }
        [DataMember]
        public Especialidades especialidade { get; set; }

        public MedicoView(int? id, string name, Especialidades especialidade)
        {
            this.especialidade=especialidade;
            this.name=name;
            this.id=id;
        }

        public MedicoView(){}

        public static MedicoView fromModel(src.Models.MedicoModel medico) => new MedicoView(medico.id,
                                                                                            medico.name,
                                                                                            (Especialidades)medico.especialidade);
    }
}