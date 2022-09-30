using System.Runtime.Serialization;
using src.Enums;
using src.Interaces;

namespace src.Views
{
    [DataContract]
    public class PacienteView
    {
        [DataMember]
        public int? id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public Sexo sexo { get; set; }

        public PacienteView(int? id, string name, Sexo sexo)
        {
            this.sexo=sexo;
            this.name=name;
            this.id=id;
        }

        public PacienteView(){}

        public static PacienteView fromModel(src.Models.PacienteModel paciente) => new PacienteView(paciente.id,
                                                                                    paciente.name,
                                                                                    (Sexo)paciente.sexo);
    }
}