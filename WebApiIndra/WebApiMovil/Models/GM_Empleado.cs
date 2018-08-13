using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class GM_Empleado
    {
        [DataMember]
        public int IdEmpleado { get; set; }

        [DataMember]
        public string NomEmpleado { get; set; }

        [DataMember]
        public string TelfEmpleado { get; set; }

        [DataMember]
        public string DirfEmpleado { get; set; }

        [DataMember]
        public int IdTipofEmpleado { get; set; }
    }
}