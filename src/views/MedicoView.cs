using System.Runtime.Serialization;
using src.Enums;
using src.Interaces;

namespace src.Views
{
    [DataContract]
    public class MedicoView 
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]

        public string name { get; set; }
        [DataMember]
        public Especialidades especialidade { get; set; }
    }
}