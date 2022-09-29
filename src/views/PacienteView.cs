using System.Runtime.Serialization;
using src.Enums;
using src.Interaces;

namespace src.Views
{
    [DataContract]
    public class PacienteView
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public Sexo sexo { get; set; }
    }
}