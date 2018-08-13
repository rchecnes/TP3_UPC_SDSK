using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class GM_Estado
    {
        [DataMember]
        public int IdEstado { get; set; }

        [DataMember]
        public string NomEstado { get; set; }

        [DataMember]
        public string DesEstado { get; set; }
    }
}