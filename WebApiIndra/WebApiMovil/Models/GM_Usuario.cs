using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class GM_Usuario
    {
        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public string NameUsuario { get; set; }

        [DataMember]
        public string EmaUsuario { get; set; }

        [DataMember]
        public string PasUsuario { get; set; }

        [DataMember]
        public int IdEmpleado { get; set; }

        [DataMember]
        public string NomEmpleado { get; set; }

        [DataMember]
        public int IdRol { get; set; }

        [DataMember]
        public string NomRol { get; set; }
        
    }
}